
using SQLite;

namespace CamScanner.Models;

public class Lote
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Nombre { get; set; } = string.Empty;

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public string? Descripcion { get; set; }
}
