# Plan de pruebas — CamScanner

## 1. Objetivo
Definir casos para verificar captura/importación, OCR local, selección y corrección, gestión de lotes/documentos, SQLite y exportación Excel. Este documento diseña pruebas; no informa resultados ejecutados.

## 2. Estado inicial
Todos los casos están **Pendientes de ejecución**. La revisión estática identificó configuración MAUI, modelos `Lote` y `Documento`, creación de tablas SQLite, consulta de lotes e inserción/actualización de lotes. La pantalla principal sigue siendo la plantilla MAUI y la búsqueda realizada no encontró referencias a OCR, cámara, selección de archivos o Excel.

## 3. Técnicas
- Partición de equivalencia: imágenes compatibles/no compatibles y datos válidos/no válidos.
- Valores límite: tamaños, cantidades y longitudes de campos.
- Pruebas de flujo: captura/importación, OCR, revisión, guardado y exportación.
- Persistencia: cerrar y reabrir la aplicación.
- Pruebas negativas: permisos denegados, imágenes sin texto y errores de almacenamiento/exportación.

## 4. Casos de prueba

| ID | Requisito | Escenario | Resultado esperado | Estado |
|---|---|---|---|---|
| CP-01 | RF-01 | Capturar fotografía con permiso concedido. | Imagen capturada y disponible. | Pendiente |
| CP-02 | RF-01 | Denegar permiso de cámara. | Mensaje claro, sin cierre inesperado. | Pendiente |
| CP-03 | RF-02 | Importar imagen compatible. | Imagen incorporada al flujo. | Pendiente |
| CP-04 | RF-02 | Cancelar selector de imágenes. | Se conserva el estado actual. | Pendiente |
| CP-05 | RF-03 | Procesar imagen legible sin Internet. | OCR local reconoce texto sin conexión. | Pendiente |
| CP-06 | RF-03 | Procesar imagen borrosa o sin texto. | Se informa resultado parcial o ausencia de texto. | Pendiente |
| CP-07 | RF-04 | Revisar resultado OCR. | Texto reconocido visible. | Pendiente |
| CP-08 | RF-05 | Seleccionar algunos datos. | Se conservan solo los datos elegidos. | Pendiente |
| CP-09 | RF-06 | Corregir un dato reconocido. | Valor corregido se conserva. | Pendiente |
| CP-10 | RF-07 | Crear lote válido. | Lote registrado. | Pendiente |
| CP-11 | RF-08 | Consultar lotes. | Se muestran lotes existentes. | Pendiente |
| CP-12 | RF-09 | Modificar lote. | Cambios guardados. | Pendiente |
| CP-13 | RF-10 | Eliminar lote sin documentos. | Lote deja de aparecer. | Pendiente |
| CP-14 | RF-10 | Eliminar lote con documentos asociados. | Se aplica regla de integridad definida. | Pendiente |
| CP-15 | RF-11 | Crear documento y asociarlo a lote. | Documento registrado y relacionado. | Pendiente |
| CP-16 | RF-12 | Consultar documentos de un lote. | Se muestran los documentos correspondientes. | Pendiente |
| CP-17 | RF-13 | Modificar documento. | Cambios guardados. | Pendiente |
| CP-18 | RF-14 | Eliminar documento. | Documento deja de aparecer. | Pendiente |
| CP-19 | RF-15 | Guardar y reiniciar aplicación. | Registros confirmados persisten en SQLite. | Pendiente |
| CP-20 | RF-16 | Exportar documento individual. | Excel con datos seleccionados. | Pendiente |
| CP-21 | RF-17 | Exportar lote. | Excel con datos de documentos del lote. | Pendiente |
| CP-22 | RF-18 | Provocar error controlado. | Mensaje claro y datos confirmados conservados. | Pendiente |
| CP-23 | RNF-03 | Ejecutar OCR sin conexión. | OCR funciona sin Internet. | Pendiente |
| CP-24 | RNF-04 | Reiniciar después de guardar. | Datos disponibles nuevamente. | Pendiente |
| CP-25 | RNF-02 | Procesar conjunto representativo de imágenes. | Duración registrada y sin bloqueos inaceptables. | Pendiente |
| CP-26 | RNF-10 | Abrir archivo Excel generado. | Datos legibles y correspondientes a la selección. | Pendiente |

## 5. Registro de ejecución

| ID | Fecha | Dispositivo/emulador | Resultado | Evidencia/incidencia |
|---|---|---|---|---|
| CP-__ | __/__/____ | __ | Aprobado/Fallido | __ |

## 6. Criterios de entrada
- Aplicación compilada e instalada en dispositivo/emulador Android compatible.
- Datos de prueba preparados.
- Permisos y recursos disponibles.
- Imágenes de referencia con texto conocido para OCR.
- Documentos de prueba para exportación.

## 7. Criterios de salida
- Casos ejecutados y resultados registrados.
- Evidencias asociadas a los casos.
- Defectos clasificados.
- Fallos críticos corregidos o reportados.

## 8. Evidencias recomendadas
- Captura o importación de imagen.
- OCR ejecutado sin conexión.
- Selección y corrección de datos.
- CRUD de lotes y documentos.
- Persistencia después de reiniciar.
- Archivo Excel generado y contenido revisado.
- Manejo de errores y permisos denegados.

No marcar un caso como aprobado sin evidencia de ejecución.

---

## Anexo A. Pruebas específicas de captura, OCR y servicios — aporte de Javier

Este anexo conserva el diseño de casos manuales, la descripción de pruebas xUnit y el registro aportado por Javier para el Seguimiento 1. **Advertencia de trazabilidad:** algunos identificadores RF de este anexo proceden del alcance anterior (ZIP/PDF) y NO corresponden a los RF-01 a RF-18 de `docs/especificacion.md` vigente. Para evaluar la trazabilidad formal, usar la tabla principal anterior y actualizar las referencias del anexo en el siguiente seguimiento. Los resultados de ejecución consignados por Javier son reportados por el autor, no verificados aquí de forma independiente.

### Plan detallado aportado por Javier

|                                   |                                                 |
| --------------------------------- | ----------------------------------------------- |
| **Proyecto**                | CamScanner (.NET MAUI, Android)                 |
| **Versión del plan**       | 0.2 – primera entrega (2 de noviembre)         |
| **Responsable**             | [Nombre del integrante – Desarrollo y pruebas] |
| **Documentos relacionados** | `docs/especificacion.md`, `README.md`       |

## 1. Objetivo

Verificar que las funcionalidades iniciales de CamScanner (captura e importación de imágenes, vista previa, gestión básica de documentos y reconocimiento de texto local) funcionan correctamente en escenarios normales y se comportan de forma segura ante errores, según los requerimientos de `docs/especificacion.md`.

## 2. Alcance

**Dentro del alcance (primera entrega):**

- Captura de fotos con la cámara e importación desde la galería (RF-01, RF-02).
- Nombres de documentos: nombre por defecto y renombrado (RF-03).
- Eliminación de documentos (RF-04).
- Compartir una imagen individual (RF-11).
- Mensajes de error y estabilidad ante cancelaciones y permisos denegados (RF-12, RF-13, RNF-04).
- Reglas de validación de nombres previas a exportar (RF-06, RF-07), probadas a nivel de lógica.
- Vista previa a pantalla completa y reconocimiento de texto (OCR) con ML Kit, sin conexión (prueba de viabilidad).

**Fuera del alcance por ahora (aún no implementado):** generación de ZIP y PDF (RF-05, RF-08, RF-09), compartir ZIP/PDF (RF-10), exportación a Excel, persistencia en SQLite, pruebas en iOS (RNF-02).

> **Nota de alineación:** los requerimientos RF-05 a RF-10 describen la exportación a ZIP y PDF, mientras que el desarrollo actual incluye OCR, SQLite y exportación a Excel. Este plan cubre lo implementado y deja los casos de exportación como pendientes;

## 3. Estrategia

| Tipo                                | Qué cubre                                                                                        | Herramienta                        |
| ----------------------------------- | ------------------------------------------------------------------------------------------------- | ---------------------------------- |
| **Automatizadas (unitarias)** | Lógica sin interfaz: validación y generación de nombres, almacenamiento y borrado de imágenes | xUnit (`tests/CamScanner.Tests`) |
| **Manuales en dispositivo**   | Cámara, galería, permisos, navegación, compartir, OCR y rendimiento percibido                  | Dispositivo Android y emulador     |

Las pruebas de interfaz automatizadas y las de OCR con imágenes reales se dejan manuales en esta etapa: dependen del dispositivo, los permisos del sistema y el motor de ML Kit.

## 4. Entorno de pruebas

- **Plataforma:** Android (dispositivo físico principal; emulador para casos sin cámara).
- **Framework:** .NET 10, .NET MAUI.
- **Paquetes relevantes:** `Plugin.Maui.OCR`, `sqlite-net-pcl`.
- **Datos de prueba:** pantallazos de texto, fotos nítidas de documentos, foto borrosa, imagen sin texto, 12 imágenes para probar el límite de selección.
- **Privacidad (RNF-05):** no se usan documentos reales ni datos personales en las pruebas.

## 5. Trazabilidad requerimiento → pruebas

| Requerimiento                                          | Estado en la app                      | Casos de prueba                           |
| ------------------------------------------------------ | ------------------------------------- | ----------------------------------------- |
| RF-01 Tomar foto                                       | Implementado                          | CP-01, CP-02, CP-03, CP-04                |
| RF-02 Seleccionar varias imágenes                     | Implementado                          | CP-05, CP-06, CP-07, CP-08                |
| RF-03 Nombre editable por defecto consecutivo          | Implementado                          | CP-09, CP-10, CP-11, CP-12, AUT-VN-01..05 |
| RF-04 Quitar imagen                                    | Implementado                          | CP-13, CP-14, AUT-AI-06..08               |
| RF-05 Título del paquete                              | Pendiente                             | –                                        |
| RF-06 Impedir exportar con nombres repetidos o vacíos | Lógica lista; pantalla pendiente     | CP-24, CP-25, AUT-VN-06..09               |
| RF-07 Impedir exportar con lista vacía                | Lógica lista; pantalla pendiente     | CP-26, AUT-VN-06                          |
| RF-08 a RF-10 ZIP, PDF y compartirlos                  | Pendiente                             | –                                        |
| RF-11 Compartir una imagen                             | Implementado                          | CP-17, CP-18                              |
| RF-12 No perder la lista ante fallos o cancelaciones   | Implementado (captura/galería)       | CP-03, CP-07, CP-27, AUT-AI-05            |
| RF-13 Mensajes claros de error                         | Implementado (captura/selección/OCR) | CP-02, CP-04, CP-18, CP-22, CP-27         |
| RNF-01 Usabilidad                                      | Parcial                               | CP-15, CP-16 (observación)               |
| RNF-03 Interfaz sin congelarse                         | Implementado para OCR                 | CP-23                                     |
| RNF-04 No cerrarse inesperadamente                     | Implementado                          | CP-02, CP-03, CP-07, CP-27                |
| OCR local (viabilidad)                                 | Implementado                          | CP-19 a CP-23                             |

## 6. Casos de prueba manuales

**Convenciones:** *Tipo* = Correcto (C), Error (E) o Límite (L). *Estado* inicial de todos los casos: **Pendiente** (se actualiza en el registro de ejecución, sección 8).

### 6.1 Captura con la cámara (RF-01)

| ID    | Tipo | Precondición                      | Pasos                                                                                   | Resultado esperado                                                               |
| ----- | ---- | ---------------------------------- | --------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------- |
| CP-01 | C    | Permiso de cámara concedido       | 1. Tocar **+**. 2. Elegir *Tomar foto*. 3. Capturar y aceptar.                  | La foto aparece al inicio de la lista con miniatura, nombre por defecto y fecha. |
| CP-02 | E    | Permiso de cámara denegado        | 1. Tocar **+** → *Tomar foto*. 2. Denegar el permiso.                          | Aparece el aviso "Permiso requerido". No se agrega nada y la app no se cierra.   |
| CP-03 | E    | Cámara abierta                    | 1. Tocar **+** → *Tomar foto*. 2. Cancelar o salir de la cámara sin capturar. | Se vuelve a la lista sin error ni elementos nuevos. La lista previa se conserva. |
| CP-04 | E    | Emulador o dispositivo sin cámara | 1. Tocar **+** → *Tomar foto*.                                                 | Aviso "Cámara no disponible". La app sigue funcionando.                         |

### 6.2 Importación desde la galería (RF-02)

| ID    | Tipo | Precondición                 | Pasos                                                                  | Resultado esperado                                                                               |
| ----- | ---- | ----------------------------- | ---------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------ |
| CP-05 | C    | Galería con imágenes        | 1. **+** → *Importar de la galería*. 2. Elegir 1 imagen.     | Se agrega 1 documento con su miniatura.                                                          |
| CP-06 | C    | Galería con varias imágenes | 1. **+** → *Importar de la galería*. 2. Elegir 3 imágenes.  | Se agregan 3 documentos con nombres consecutivos distintos.                                      |
| CP-07 | E    | Selector abierto              | 1. **+** → *Importar de la galería*. 2. Cancelar sin elegir. | No se agrega nada, no hay error y la lista se conserva.                                          |
| CP-08 | L    | 12 imágenes en galería      | 1. Abrir el selector. 2. Intentar elegir 12.                           | Solo permite seleccionar hasta el límite configurado (10). Se importan las elegidas sin fallos. |

### 6.3 Nombres de documentos (RF-03)

| ID    | Tipo | Precondición                                         | Pasos                                                           | Resultado esperado                                                          |
| ----- | ---- | ----------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------------------- |
| CP-09 | C    | Lista vacía                                          | Importar 2 imágenes.                                           | Se llaman "Documento 1" y "Documento 2" (la más reciente aparece primero). |
| CP-10 | C    | Documento en la lista                                 | ⋮ → *Renombrar* → escribir "Factura" → Guardar.           | El nombre cambia en la lista.                                               |
| CP-11 | E    | Documento en la lista                                 | ⋮ → *Renombrar* → dejar vacío o solo espacios → Guardar. | No se cambia el nombre.                                                     |
| CP-12 | L    | Lista con "Documento 1", "Documento 2", "Documento 3" | 1. Eliminar "Documento 2". 2. Agregar una imagen.               | El nuevo documento no repite un nombre existente (se llama "Documento 4").  |

### 6.4 Eliminar (RF-04)

| ID    | Tipo | Precondición         | Pasos                               | Resultado esperado                                                                     |
| ----- | ---- | --------------------- | ----------------------------------- | -------------------------------------------------------------------------------------- |
| CP-13 | C    | Documento en la lista | ⋮ → *Eliminar* → confirmar.    | El documento desaparece de la lista y su imagen se borra del almacenamiento de la app. |
| CP-14 | E    | Documento en la lista | ⋮ → *Eliminar* → *Cancelar*. | El documento se conserva.                                                              |

### 6.5 Vista previa a pantalla completa

| ID    | Tipo | Precondición         | Pasos                                   | Resultado esperado                                                                              |
| ----- | ---- | --------------------- | --------------------------------------- | ----------------------------------------------------------------------------------------------- |
| CP-15 | C    | Documento en la lista | Tocar la tarjeta del documento.         | Se abre la imagen a pantalla completa con barra superior (nombre) y barra inferior de acciones. |
| CP-16 | C    | Vista previa abierta  | Tocar ← o el botón atrás de Android. | Se vuelve a la lista sin cambios.                                                               |

### 6.6 Compartir (RF-11)

| ID    | Tipo | Precondición                                 | Pasos                                         | Resultado esperado                                                                                  |
| ----- | ---- | --------------------------------------------- | --------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| CP-17 | C    | Vista previa abierta                          | Tocar *Compartir* y elegir una app destino. | Se abre el menú de compartir del dispositivo y la imagen llega a la app elegida.                   |
| CP-18 | E    | Imagen borrada manualmente del almacenamiento | Tocar *Compartir*.                          | Aviso "Archivo no encontrado"; la app no se cierra. Cancelar el menú de compartir no genera error. |

### 6.7 OCR local (viabilidad)

| ID    | Tipo | Precondición                          | Pasos                            | Resultado esperado                                                                                                           |
| ----- | ---- | -------------------------------------- | -------------------------------- | ---------------------------------------------------------------------------------------------------------------------------- |
| CP-19 | C    | Pantallazo de texto digital            | Abrir el documento → *Texto*. | Aparece el indicador "Reconociendo texto…" y luego "Texto listo". El editor muestra el texto con muy pocos o ningún error. |
| CP-20 | C    | Foto real, nítida y bien iluminada    | Abrir el documento → *Texto*. | Texto reconocido en su mayor parte; pueden existir errores menores.                                                          |
| CP-21 | L    | Foto borrosa, inclinada o con poca luz | Abrir el documento → *Texto*. | El resultado puede tener errores o venir incompleto. Se documenta la calidad obtenida (esperado: peor que en CP-19 y CP-20). |
| CP-22 | E    | Imagen sin texto (paisaje)             | Abrir el documento → *Texto*. | Aviso "No se detectó texto". La app no se cierra.                                                                           |
| CP-23 | C    | Modo avión activado                   | Abrir el documento → *Texto*. | El OCR funciona igual sin Internet. La imagen sigue visible y se pueden usar otras acciones mientras se procesa (RNF-03).    |

### 6.8 Validación previa a exportar (RF-06, RF-07)

*Estos casos se ejecutan hoy como pruebas automatizadas de la lógica; se repetirán de forma manual cuando exista la pantalla de exportación.*

| ID    | Tipo | Precondición                      | Pasos              | Resultado esperado                                    |
| ----- | ---- | ---------------------------------- | ------------------ | ----------------------------------------------------- |
| CP-24 | E    | Dos documentos con el mismo nombre | Intentar exportar. | Se bloquea y se informa qué nombres se repiten.      |
| CP-25 | E    | Un documento con nombre vacío     | Intentar exportar. | Se bloquea y se informa que hay imágenes sin nombre. |
| CP-26 | E    | Lista vacía                       | Intentar exportar. | Se bloquea e informa que la lista está vacía.       |

### 6.9 Robustez (RNF-04, RF-12)

| ID    | Tipo | Precondición                                                | Pasos               | Resultado esperado                                                             |
| ----- | ---- | ------------------------------------------------------------ | ------------------- | ------------------------------------------------------------------------------ |
| CP-27 | E    | Poco espacio de almacenamiento o imagen que no se puede leer | Importar la imagen. | Mensaje de error claro; la lista existente no se pierde y la app no se cierra. |

## 7. Pruebas automatizadas (xUnit)

**Proyecto:** `tests/CamScanner.Tests` (net10.0). Prueba los servicios de `src/Services`, que no dependen de MAUI.

**Cómo se conectan los proyectos:** el proyecto de pruebas no referencia al proyecto MAUI. Enlaza los archivos de `src/Services/` con esta línea de `CamScanner.Tests.csproj`:

```xml
<Compile Include="..\..\src\Services\*.cs" LinkBase="Services" />
```

Por eso todo archivo nuevo en `src/Services/` debe compilar sin MAUI; los servicios que usen MAUI (por ejemplo, el OCR) van en otra carpeta.

| ID        | Clase.Método                                          | Verifica                                                                             |
| --------- | ------------------------------------------------------ | ------------------------------------------------------------------------------------ |
| AUT-VN-01 | `ValidadorNombresTests.NombreInicial_*`              | Nombre por defecto consecutivo (RF-03).                                              |
| AUT-VN-02 | `SiguienteNombre_ListaVacia_EsDocumento1`            | Primer nombre cuando no hay documentos.                                              |
| AUT-VN-03 | `SiguienteNombre_SaltaLosNombresOcupados`            | No repite nombres tras eliminar un documento.                                        |
| AUT-VN-04 | `SiguienteNombre_IgnoraMayusculasYEspacios`          | Comparación sin distinguir mayúsculas ni espacios.                                 |
| AUT-VN-05 | `Normalizar_QuitaEspaciosYNulos`                     | Limpieza de nombres (null, espacios).                                                |
| AUT-VN-06 | `ValidarLista_ListaVacia_NoEsValida`                 | Lista vacía bloquea la exportación (RF-07).                                        |
| AUT-VN-07 | `ValidarLista_NombreVacio_NoEsValida`                | Nombres vacíos, nulos o solo espacios (RF-06).                                      |
| AUT-VN-08 | `ValidarLista_NombresRepetidos_*`                    | Nombres repetidos, ignorando mayúsculas y espacios (RF-06).                         |
| AUT-VN-09 | `ValidarLista_NombresUnicos_EsValida`                | Caso correcto: lista válida sin errores.                                            |
| AUT-AI-01 | `AlmacenImagenesTests.GuardarAsync_CopiaElContenido` | La imagen guardada tiene el mismo contenido.                                         |
| AUT-AI-02 | `GuardarAsync_ConservaLaExtensionConocida_oUsaJpg`   | Conserva .png, .jpeg, .heic; extensiones desconocidas usan .jpg.                     |
| AUT-AI-03 | `GuardarAsync_CreaLaCarpetaSiNoExiste`               | Crea la carpeta de documentos.                                                       |
| AUT-AI-04 | `GuardarAsync_DosVeces_GeneraRutasDistintas`         | Dos imágenes nunca se sobrescriben.                                                 |
| AUT-AI-05 | `GuardarAsync_FalloAlCopiar_*`                       | Ante un fallo de lectura se propaga el error y no queda un archivo a medias (RF-12). |
| AUT-AI-06 | `Eliminar_ArchivoExistente_LoBorra`                  | Borra el archivo (RF-04).                                                            |
| AUT-AI-07 | `Eliminar_ArchivoInexistente_*`                      | No lanza error si el archivo ya no existe.                                           |
| AUT-AI-08 | `Eliminar_RutaVacia_*`                               | Ruta nula o vacía no provoca errores.                                               |

**Cómo ejecutarlas:** desde la raíz del repositorio, `dotnet test tests/CamScanner.Tests`, o simplemente `dotnet test` dentro de `tests/CamScanner.Tests`. También desde el Explorador de pruebas de Visual Studio.

**Total:** 29 pruebas (14 de `ValidadorNombresTests` y 15 de `AlmacenImagenesTests`, contando cada `[InlineData]` como una prueba).

**Por qué no se automatizan aún la interfaz y el OCR:** requieren dispositivo, permisos del sistema y ML Kit. Se evaluará más adelante extraer el OCR detrás de una interfaz (`IServicioOcr`) para probar la lógica de la app con un servicio simulado.

## 8. Registro de ejecución

### 8.1 Pruebas automatizadas

| Fecha | Ejecutó | Entorno                                   | Cubre                        | Resultado                                      | Observaciones    |
| ----- | -------- | ----------------------------------------- | ---------------------------- | ---------------------------------------------- | ---------------- |
| 2 nov | [Nombre] | PC con Windows, .NET 10.0.14, xUnit 2.9.3 | AUT-VN-01..09, AUT-AI-01..08 | **OK: 29 de 29** (0 errores, 0 omitidas) | Duración 2,3 s. |

### 8.2 Pruebas manuales

| ID    | Fecha     | Probador | Dispositivo                               | Resultado (OK / Falla) | Observaciones                                                                                                                                                          |
| ----- | --------- | -------- | ----------------------------------------- | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| CP-01 | 2/11/2026 | Javier   | Xiaomi 23090RA98G (Android 16.0 - API 36) | OK                     |                                                                                                                                                                        |
| CP-02 | 2/11/2026 | Javier   | Xiaomi 23090RA98G (Android 16.0 - API 36) | OK                     |                                                                                                                                                                        |
| CP-03 | 2/11/2026 | Javier   | Xiaomi 23090RA98G (Android 16.0 - API 36) | OK                     |                                                                                                                                                                        |
| CP-04 | 2/11/2026 | Javier   | Pixel 7 Emulador (Android 16.0 - API 36   | OK                     | El Emulador aunque no se cuente con cámara física, este simula una imagen en la cámara al conceder el permiso (Por lo que actua como una cámara normal de android) |
| CP-05 |           |          |                                           |                        |                                                                                                                                                                        |

*(Completar con cada ejecución. Registrar defectos encontrados como tarjetas en Trello y vincular el commit de la corrección.)*

## 9. Criterios de aceptación de la primera entrega

- Los casos CP-01 a CP-18 y CP-27 pasan en un dispositivo Android real.
- Los casos CP-19 a CP-23 están ejecutados y se documentan los resultados de viabilidad del OCR (incluidas las limitaciones con fotos reales).
- Todas las pruebas automatizadas pasan (`dotnet test`). *Cumplido el 2 de noviembre: 29 de 29 (sección 8.1).*
- Ningún caso hace que la aplicación se cierre inesperadamente (RNF-04).

## 10. Riesgos de calidad identificados

| Riesgo                                                           | Impacto                    | Mitigación                                                                                      |
| ---------------------------------------------------------------- | -------------------------- | ------------------------------------------------------------------------------------------------ |
| El OCR se equivoca con fotos borrosas, inclinadas o con poca luz | Texto incorrecto exportado | Pantalla para revisar y corregir; recomendar buena luz y enfoque; evaluar preprocesado de imagen |
| Permisos denegados por el usuario                                | Funciones inaccesibles     | Mensajes claros que expliquen cómo activarlos                                                   |
| Fallos de almacenamiento (poco espacio)                          | Pérdida de datos          | Evitar archivos a medias (cubierto en AUT-AI-05) y avisar al usuario                             |
| Diferencias entre dispositivos y versiones de Android            | Comportamientos distintos  | Probar en al menos un dispositivo físico y un emulador                                          |
| Lógica acoplada a la interfaz                                   | Difícil de probar         | Mantener la lógica en `src/Services/` sin dependencias de MAUI (RNF-06)                       |