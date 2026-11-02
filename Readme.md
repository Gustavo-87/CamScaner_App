# CamScanner — Aplicación móvil Android

## Descripción
CamScanner es un proyecto Android desarrollado con .NET 10, .NET MAUI y C#. El alcance acordado contempla capturar o importar fotografías de documentos, reconocer texto mediante OCR local, seleccionar y corregir la información detectada, organizar documentos por lotes, guardar datos en SQLite y exportarlos a Excel.

**Estado de la versión revisada:** el repositorio contiene la configuración inicial de MAUI, los modelos `Lote` y `Documento` y una capa SQLite limitada. La pantalla principal sigue siendo la plantilla de MAUI. La búsqueda realizada en `src` no encontró referencias a OCR, cámara, importación de imágenes ni Excel. Por tanto, las funciones del alcance no deben presentarse como implementadas sin código y evidencia adicionales.

## Objetivo general
Desarrollar una aplicación Android que permita digitalizar documentos, reconocer su contenido mediante OCR local, revisar y corregir la información, organizarla en lotes, almacenarla localmente y exportarla a Excel.

## Funcionalidades y estado comprobado

| Funcionalidad | Estado según archivos revisados |
|---|---|
| Proyecto .NET 10 / MAUI Android | Configuración presente en `src/CamScanner.csproj`. |
| Modelo Lote | Implementado en `src/Models/Lote.cs`. |
| Modelo Documento | Implementado en `src/Models/Documento.cs`. |
| Inicialización SQLite y creación de tablas | Implementada para `Lote` y `Documento`. |
| Consultar lotes | Implementado mediante `ObtenerLotesAsync()`. |
| Insertar/actualizar lotes | Implementado mediante `GuardarLoteAsync()`. |
| Captura de fotografías | No encontrada en los archivos revisados. |
| Importación de imágenes | No encontrada en los archivos revisados. |
| OCR local | No encontrado; tampoco se identificó dependencia OCR en el `.csproj`. |
| Selección y corrección de texto | No encontrada en los archivos revisados. |
| CRUD completo de lotes | Parcial: consulta, inserción y actualización; no se encontró eliminación. |
| CRUD de documentos | Pendiente en la capa revisada: existe el modelo, pero no operaciones de persistencia. |
| Exportación Excel | No encontrada; no se identificó dependencia Excel. |
| Pruebas automatizadas | No se identificó carpeta/proyecto `tests` en el listado compartido. |

Estos estados describen la rama revisada y los archivos suministrados; no equivalen a una auditoría exhaustiva de todo comportamiento posible.

## Tecnologías identificadas

| Tecnología | Uso / evidencia |
|---|---|
| .NET 10 | Marcos objetivo `net10.0-android` y otros destinos condicionados. |
| .NET MAUI | Interfaz y estructura de aplicación (`UseMaui=true`). |
| C# | Lenguaje de los archivos fuente. |
| SQLite | `sqlite-net-pcl` versión `1.11.285`. |
| Git / GitHub | Control de versiones. |
| Trello | Seguimiento de tareas; agregar URL real del tablero. |
| OCR local | Requerido por el alcance; no identificado en el código revisado. |
| Excel | Formato requerido; biblioteca no identificada en el código revisado. |

## Equipo y roles

| Integrante | Rol | Responsabilidad |
|---|---|---|
| Gustavo Piedrahita | Líder técnico | Coordinar alcance, arquitectura e integración. |
| Javier Serna | Responsable de pruebas | Diseñar y ejecutar pruebas y registrar resultados. |
| Richard Prado | Responsable de calidad y documentación | Revisar calidad, registrar defectos y mantener documentación y evidencias. |

## Estructura identificada

```text
CamScanner_App/
├── Readme.md
├── docs/
│   ├── especificacion.md
│   ├── informe-calidad.md
│   └── plan-de-pruebas.md
└── src/
    ├── CamScanner.csproj
    ├── App.xaml
    ├── App.xaml.cs
    ├── AppShell.xaml
    ├── AppShell.xaml.cs
    ├── MainPage.xaml
    ├── MainPage.xaml.cs
    ├── MauiProgram.cs
    ├── Data/CamScannerDatabase.cs
    ├── Models/Documento.cs
    ├── Models/Lote.cs
    ├── Platforms/Android/
    └── Resources/
```

La estructura se basa en el listado `git ls-files` compartido. No se incluye `tests/` porque no apareció en ese listado.

## Requisitos previos
- Windows 10/11 con entorno de desarrollo Android.
- .NET 10 SDK.
- Visual Studio 2022 actualizado con la carga de trabajo **Desarrollo de la interfaz de usuario de aplicaciones multiplataforma de .NET** y componentes Android, o entorno .NET MAUI equivalente.
- Android SDK y herramientas requeridas.
- Emulador Android o dispositivo con depuración USB.

El `.csproj` declara `net10.0-android` y Android API mínima 21. La compatibilidad debe validarse en el entorno y dispositivo objetivo.

## Instalación, compilación y ejecución

Clonar el repositorio:

```bash
git clone https://github.com/Gustavo-87/CamScanner_App.git
cd CamScanner_App
```

Restaurar cargas de trabajo y dependencias:

```bash
dotnet workload restore src/CamScanner.csproj
dotnet restore src/CamScanner.csproj
```

Si falta la carga MAUI Android:

```bash
dotnet workload install maui-android
```

Compilar:

```bash
dotnet build src/CamScanner.csproj -f net10.0-android
```

Para ejecutar, abrir `src/CamScanner.csproj` en Visual Studio, seleccionar un emulador o dispositivo Android y pulsar **Iniciar / Run**.

Publicar en Release (según configuración local):

```bash
dotnet publish src/CamScanner.csproj -f net10.0-android -c Release
```

La compilación no implica que OCR, captura o exportación estén disponibles: no se encontraron en la versión inspeccionada.

## Gestión del proyecto
El equipo utiliza Trello para asignar actividades, registrar avances, adjuntar evidencias y relacionar los cambios con commits.

**Tablero Trello:** pendiente de agregar el enlace real.

## Documentación
- [Especificación](docs/especificacion.md)
- [Informe de calidad](docs/informe-calidad.md)
- [Plan de pruebas](docs/plan-de-pruebas.md)

Actualizar esta documentación cuando se incorporen funciones. Para marcar una función como implementada debe identificarse el componente/archivo; para marcarla como verificada también debe registrarse el caso ejecutado y su evidencia.
