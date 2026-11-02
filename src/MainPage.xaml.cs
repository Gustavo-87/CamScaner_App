using System.Collections.ObjectModel;
using CamScanner.Models;

namespace CamScanner;

public partial class MainPage : ContentPage
{
    public ObservableCollection<Documento> Documentos { get; } = new();

    private Documento? _seleccionado;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    // ================= Hoja inferior (bottom sheet) =================

    private async Task MostrarHojaAsync(View hoja)
    {
        AddSheet.IsVisible = false;
        ItemSheet.IsVisible = false;

        hoja.IsVisible = true;
        Overlay.IsVisible = true;
        hoja.TranslationY = 400;
        await hoja.TranslateToAsync(0, 0, 200, Easing.CubicOut);
    }

    private async Task OcultarHojaAsync()
    {
        if (!Overlay.IsVisible)
            return;

        var hoja = AddSheet.IsVisible ? (View)AddSheet : ItemSheet;
        await hoja.TranslateToAsync(0, hoja.Height, 150, Easing.CubicIn);

        Overlay.IsVisible = false;
        AddSheet.IsVisible = false;
        ItemSheet.IsVisible = false;
    }

    // El botón "atrás" de Android cierra el menú en lugar de salir de la app
    protected override bool OnBackButtonPressed()
    {
        if (Overlay.IsVisible)
        {
            _ = OcultarHojaAsync();
            return true;
        }
        return base.OnBackButtonPressed();
    }

    private async void OnFabClicked(object? sender, EventArgs e) => await MostrarHojaAsync(AddSheet);

    private async void OnOverlayTapped(object? sender, TappedEventArgs e) => await OcultarHojaAsync();

    // ================= Menú "Agregar" =================

    private async void OnTomarFotoTapped(object? sender, TappedEventArgs e)
    {
        await OcultarHojaAsync();
        try
        {
            if (!MediaPicker.Default.IsCaptureSupported)
            {
                await DisplayAlertAsync("Cámara no disponible", "Este dispositivo no permite capturar fotos.", "OK");
                return;
            }

            var permiso = await Permissions.RequestAsync<Permissions.Camera>();
            if (permiso != PermissionStatus.Granted)
            {
                await DisplayAlertAsync("Permiso requerido", "Activa el permiso de cámara para tomar fotos.", "OK");
                return;
            }

            var foto = await MediaPicker.Default.CapturePhotoAsync();
            await GuardarFotoAsync(foto);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", $"No se pudo tomar la foto: {ex.Message}", "OK");
        }
    }

    private async void OnImportarGaleriaTapped(object? sender, TappedEventArgs e)
    {
        await OcultarHojaAsync();
        try
        {
            var fotos = await MediaPicker.Default.PickPhotosAsync(new MediaPickerOptions
            {
                Title = "Selecciona documentos",
                SelectionLimit = 10 // permite importar varias imágenes a la vez
            });

            if (fotos is null)
                return; // el usuario canceló

            foreach (var foto in fotos)
                await GuardarFotoAsync(foto);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Error", $"No se pudo importar la imagen: {ex.Message}", "OK");
        }
    }

    private async void OnNuevoLoteTapped(object? sender, TappedEventArgs e)
    {
        await OcultarHojaAsync();
        await DisplayAlertAsync("Próximamente", "La gestión de lotes se agregará con la base de datos SQLite.", "OK");
    }

    /// <summary>Copia la imagen al almacenamiento de la app y la agrega a la lista.</summary>
    private async Task GuardarFotoAsync(FileResult? foto)
    {
        if (foto is null)
            return; // el usuario canceló

        var carpeta = Path.Combine(FileSystem.AppDataDirectory, "documentos");
        Directory.CreateDirectory(carpeta);

        var id = Guid.NewGuid();
        var ruta = Path.Combine(carpeta, $"{id}.jpg");

        await using (var origen = await foto.OpenReadAsync())
        await using (var destino = File.Create(ruta))
        {
            await origen.CopyToAsync(destino);
        }

        // TODO: al integrar SQLite, guardar aquí (InsertAsync) y asignar el LoteId real
        Documentos.Insert(0, new Documento
        {
            Nombre = $"Documento {Documentos.Count + 1}",
            RutaImagen = ruta,
            FechaCreacion = DateTime.Now
        });
    }

    // ================= Menú contextual del documento =================

    private async void OnMenuDocumentoClicked(object? sender, EventArgs e)
    {
        if (sender is BindableObject { BindingContext: Documento doc })
        {
            _seleccionado = doc;
            ItemTitle.Text = doc.Nombre;
            await MostrarHojaAsync(ItemSheet);
        }
    }

    private async void OnVerEditarTapped(object? sender, TappedEventArgs e)
    {
        await OcultarHojaAsync();
        await DisplayAlertAsync("Próximamente", "Aquí se mostrará el texto reconocido por OCR para editarlo.", "OK");
    }

    private async void OnExportarExcelTapped(object? sender, TappedEventArgs e)
    {
        await OcultarHojaAsync();
        await DisplayAlertAsync("Próximamente", "Aquí se exportará la información del documento a Excel.", "OK");
    }

    private async void OnRenombrarTapped(object? sender, TappedEventArgs e)
    {
        await OcultarHojaAsync();
        if (_seleccionado is null)
            return;

        var nuevo = await DisplayPromptAsync("Renombrar", "Nuevo nombre:",
            accept: "Guardar", cancel: "Cancelar", initialValue: _seleccionado.Nombre);

        if (string.IsNullOrWhiteSpace(nuevo))
            return;

        // TODO: al integrar SQLite, persistir el cambio (UpdateAsync)
        _seleccionado.Nombre = nuevo.Trim();
        RefrescarDocumento(_seleccionado);
    }

    private async void OnEliminarTapped(object? sender, TappedEventArgs e)
    {
        await OcultarHojaAsync();
        if (_seleccionado is null)
            return;

        var confirmar = await DisplayAlertAsync("Eliminar documento",
            $"¿Eliminar \"{_seleccionado.Nombre}\"? Esta acción no se puede deshacer.", "Eliminar", "Cancelar");

        if (!confirmar)
            return;

        QuitarDocumento(_seleccionado);
        _seleccionado = null;
    }

    // ================= Detalle a pantalla completa =================

    private async void OnDocumentoTapped(object? sender, TappedEventArgs e)
    {
        if (sender is BindableObject { BindingContext: Documento doc })
            await AbrirDetalleAsync(doc);
    }

    private async Task AbrirDetalleAsync(Documento doc)
    {
        var pagina = new DetallePage(doc);
        pagina.Renombrado += RefrescarDocumento;
        pagina.Eliminado += QuitarDocumento;
        await Navigation.PushAsync(pagina);
    }

    // ================= Operaciones compartidas =================

    /// <summary>Documento no notifica cambios, así que se reinserta para refrescar la lista.</summary>
    private void RefrescarDocumento(Documento doc)
    {
        var indice = Documentos.IndexOf(doc);
        if (indice < 0)
            return;

        Documentos.RemoveAt(indice);
        Documentos.Insert(indice, doc);
    }

    /// <summary>Borra el archivo de imagen y quita el documento de la lista.</summary>
    private void QuitarDocumento(Documento doc)
    {
        try
        {
            if (File.Exists(doc.RutaImagen))
                File.Delete(doc.RutaImagen);
        }
        catch
        {
            // Si el archivo no se puede borrar, igual se quita de la lista
        }

        // TODO: al integrar SQLite, borrar también el registro (DeleteAsync)
        Documentos.Remove(doc);
    }
}