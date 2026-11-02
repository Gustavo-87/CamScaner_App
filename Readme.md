# CamScanner — Aplicación móvil para digitalización y extracción de información

## 1. Descripción del proyecto

**CamScanner** es una aplicación móvil para dispositivos Android desarrollada desde cero con **.NET 10, .NET MAUI y C#**. Su propósito es facilitar la digitalización de documentos físicos y la extracción de información de sus fotografías, sin depender de una conexión a Internet para el reconocimiento de texto.

La aplicación permite capturar fotografías o importar imágenes de documentos, procesarlas mediante reconocimiento óptico de caracteres (OCR) local, revisar la información detectada y seleccionar o corregir los datos que se necesitan. Posteriormente, los documentos pueden organizarse en lotes, almacenarse localmente y exportarse a archivos de Excel.

El proyecto busca reducir la digitación manual, facilitar la organización de documentos y agilizar la preparación de información para su posterior uso.

## 2. Objetivo general

Desarrollar una aplicación móvil Android que permita capturar o importar documentos, reconocer su contenido mediante OCR local, gestionar la información extraída y exportarla a Excel, manteniendo los datos almacenados localmente.

## 3. Objetivos específicos

- Facilitar la captura de documentos mediante la cámara o su importación desde el dispositivo.
- Reconocer texto de las imágenes mediante un motor OCR que funcione localmente, sin requerir Internet para el procesamiento.
- Permitir al usuario seleccionar, corregir y editar la información reconocida.
- Organizar documentos e información relacionada en lotes.
- Persistir los datos de la aplicación en una base de datos SQLite.
- Permitir las operaciones de creación, consulta, modificación y eliminación de lotes y documentos.
- Exportar la información seleccionada a Excel, tanto de forma individual como por lotes.

## 4. Funcionalidades y estado del proyecto

El estado indicado para esta entrega corresponde a la información suministrada por el equipo: la aplicación se encuentra funcionalmente terminada. La documentación académica se está organizando por entregas.

| Funcionalidad | Descripción | Estado informado |
|---|---|---|
| Captura de documentos | Tomar fotografías utilizando la cámara del dispositivo Android. | Implementado |
| Importación de documentos | Seleccionar e importar imágenes desde el dispositivo. | Implementado |
| Reconocimiento OCR local | Detectar texto de las imágenes sin necesitar conexión a Internet para el procesamiento OCR. | Implementado |
| Selección de información | Elegir los datos reconocidos que se desean conservar. | Implementado |
| Corrección de información | Editar y corregir los datos extraídos antes de guardarlos o exportarlos. | Implementado |
| Organización por lotes | Agrupar documentos para facilitar su administración. | Implementado |
| Persistencia local | Guardar la información en SQLite. | Implementado |
| CRUD de lotes | Crear, consultar, modificar y eliminar lotes. | Implementado |
| CRUD de documentos | Crear, consultar, modificar y eliminar documentos. | Implementado |
| Exportación individual | Exportar a Excel la información correspondiente a un documento. | Implementado |
| Exportación por lotes | Exportar a Excel la información de los documentos de un lote. | Implementado |

> **Nota sobre la verificación:** “Implementado” refleja el estado funcional informado por el equipo. No significa por sí solo que exista evidencia de ejecución o que todos los casos de prueba estén aprobados. Los resultados de las pruebas deben registrarse en `docs/plan-de-pruebas.md` y las observaciones de calidad en `docs/informe-calidad.md`.

## 5. Tecnologías utilizadas

| Tecnología | Uso en el proyecto |
|---|---|
| .NET 10 | Plataforma de desarrollo y ejecución. |
| .NET MAUI | Construcción de la aplicación móvil. |
| C# | Lenguaje de programación. |
| SQLite | Almacenamiento local de lotes, documentos e información relacionada. |
| OCR local | Reconocimiento óptico de caracteres a partir de las imágenes, sin requerir Internet para el procesamiento. |
| Excel | Formato de exportación de la información extraída. |
| Git y GitHub | Control de versiones y alojamiento del repositorio. |
| Trello | Organización y seguimiento de actividades del equipo. |

La biblioteca o motor OCR y el componente utilizado para generar archivos Excel deben identificarse con sus nombres y versiones exactas en la documentación técnica del proyecto o en el archivo de dependencias. No se asignan nombres de paquetes en este README porque no fueron especificados en la información suministrada.

## 6. Equipo de trabajo y roles

| Integrante | Rol | Responsabilidad principal |
|---|---|---|
| Gustavo Piedrahita | Líder técnico | Coordinar el alcance, la arquitectura y la integración de los cambios del proyecto. |
| Javier Serna | Responsable de pruebas | Diseñar los casos de prueba, ejecutar las verificaciones y registrar sus resultados. |
| Richard Prado | Responsable de calidad y documentación | Revisar la calidad del producto, registrar defectos, proponer acciones de mantenimiento y mantener actualizada la documentación y las evidencias. |

Los roles representan la responsabilidad principal de cada integrante. El equipo comparte la responsabilidad sobre el producto y su funcionamiento.

## 7. Estructura del repositorio

La estructura de documentación y código del repositorio se organiza de la siguiente manera:

```text
CamScanner_App/
├── README.md
├── docs/
│   ├── especificacion.md
│   ├── plan-de-pruebas.md
│   └── informe-calidad.md
├── src/
│   └── (código fuente de la aplicación .NET MAUI)
└── tests/
    └── (pruebas automatizadas)
```

- `README.md`: descripción general, tecnologías, integrantes, estructura e instrucciones de ejecución.
- `docs/especificacion.md`: requisitos funcionales, no funcionales y criterios de aceptación.
- `docs/plan-de-pruebas.md`: casos de prueba y registro de resultados.
- `docs/informe-calidad.md`: riesgos, aspectos de calidad, defectos y acciones de mantenimiento.
- `src/`: código fuente de la aplicación móvil.
- `tests/`: proyectos y recursos de pruebas automatizadas.

Los nombres internos de carpetas y proyectos dentro de `src/` y `tests/` deben ajustarse a los que existan realmente en el repositorio.

## 8. Requisitos previos

Para compilar y ejecutar el proyecto se requiere:

- Windows compatible con el desarrollo Android mediante .NET MAUI.
- .NET 10 SDK.
- Visual Studio 2022 actualizado con la carga de trabajo **Desarrollo de la interfaz de usuario de aplicaciones multiplataforma de .NET** y los componentes de Android, o una instalación equivalente de .NET MAUI.
- Android SDK y las herramientas de compilación requeridas por la versión de .NET MAUI utilizada.
- Un dispositivo Android con depuración USB habilitada o un emulador Android configurado.

La versión concreta de Android mínima y el nivel de API objetivo deben consultarse en la configuración del proyecto (`Platforms/Android/AndroidManifest.xml` y el archivo `.csproj`, según corresponda).

## 9. Instalación y ejecución

### Opción A. Desde Visual Studio

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/Gustavo-87/CamScanner_App
   ```

2. Abrir la solución `.sln` o el proyecto `.csproj` de la aplicación en Visual Studio.
3. Verificar que esté instalada la carga de trabajo de .NET MAUI y el soporte de Android.
4. Restaurar los paquetes NuGet de la solución.
5. Seleccionar el destino Android: emulador o dispositivo físico conectado.
6. Compilar y ejecutar el proyecto desde Visual Studio.

### Opción B. Desde la terminal

1. Clonar el repositorio y entrar a la carpeta del proyecto:

   ```bash
   git clone https://github.com/Gustavo-87/CamScanner_App
   cd CamScanner_App
   ```

2. Restaurar las dependencias:

   ```bash
   dotnet restore
   ```

3. Comprobar los SDK y las cargas de trabajo disponibles:

   ```bash
   dotnet --info
   dotnet workload list
   ```

4. Compilar para Android, reemplazando la ruta por la del archivo `.csproj` real:

   ```bash
   dotnet build src/<CamScanner_Appo>/<CamScanner_App>.csproj -f net10.0-android
   ```

5. Ejecutar o desplegar en un emulador/dispositivo Android configurado. Desde Visual Studio puede seleccionarse el dispositivo y utilizar **Iniciar**. Para despliegues por terminal, seguir la configuración de Android y el perfil de ejecución definidos por el proyecto.

> Los comandos anteriores son una guía general. La ruta del `.csproj`, el identificador del proyecto y los parámetros de despliegue deben ajustarse a los nombres reales del repositorio. No se debe asumir que `dotnet run` funciona directamente para todos los proyectos MAUI Android.

## 10. Gestión del proyecto

El seguimiento de tareas, responsables, prioridades y avances se realiza mediante Trello.

**Tablero de Trello:** (https://trello.com/b/5W9InNH9/camscaner-trabajo-final)



## 11. Documentación complementaria

- [Especificación de requisitos](docs/especificacion.md)
- [Plan de pruebas](docs/plan-de-pruebas.md)
- [Informe de calidad](docs/informe-calidad.md)

## 12. Estado de la documentación

La aplicación se reporta como funcionalmente terminada. La documentación se desarrolla y completa por etapas de acuerdo con las entregas de Ingeniería de Software II. Los estados de implementación y los resultados de verificación se mantienen diferenciados para evitar presentar como probadas funcionalidades que aún no tengan evidencia registrada.
