# Plan de pruebas — CamScanner

## 1. Objetivo

Definir los casos de prueba para verificar las funcionalidades de CamScanner: captura e importación de documentos, OCR local, selección y corrección de información, gestión de lotes y documentos, persistencia SQLite y exportación a Excel.

Este documento contiene el diseño inicial de pruebas. El estado de ejecución debe actualizarse únicamente después de ejecutar cada caso y registrar evidencia.

## 2. Alcance

Se contemplan pruebas funcionales, de persistencia, de funcionamiento sin conexión, de manejo de errores y de exportación. Las pruebas deben ejecutarse en un dispositivo Android o emulador compatible con la configuración real del proyecto.

## 3. Técnicas de prueba

- **Partición de equivalencia:** agrupar entradas que deberían producir un comportamiento equivalente; por ejemplo, imágenes compatibles y no compatibles.
- **Análisis de valores límite:** comprobar tamaños, cantidades y longitudes cercanas a los límites definidos por la aplicación.
- **Pruebas de flujo:** ejecutar secuencias completas desde la captura o importación hasta el guardado y la exportación.
- **Pruebas de persistencia:** cerrar y volver a abrir la aplicación para comprobar que los datos continúan almacenados.
- **Pruebas negativas:** provocar entradas inválidas, permisos denegados y fallos controlados para verificar el manejo de errores.

## 4. Casos de prueba

Estado inicial de todos los casos: **Pendiente de ejecución**. No se reportan resultados sin evidencia.

| ID | Requisito | Escenario / pasos resumidos | Resultado esperado | Estado |
|---|---|---|---|---|
| CP-01 | RF-01 | Conceder permiso de cámara y capturar un documento. | La fotografía se captura y queda disponible en el flujo de trabajo. | Pendiente |
| CP-02 | RF-01 | Denegar el permiso de cámara e intentar capturar. | La aplicación informa que no puede acceder a la cámara y no se cierra inesperadamente. | Pendiente |
| CP-03 | RF-02 | Importar una imagen compatible desde el dispositivo. | La imagen se incorpora correctamente. | Pendiente |
| CP-04 | RF-02 | Intentar importar una selección vacía o cancelar el selector. | La aplicación conserva el estado actual y no agrega elementos incorrectos. | Pendiente |
| CP-05 | RF-03 | Procesar una imagen nítida con texto legible y desactivar la conexión a Internet. | El OCR reconoce el texto disponible sin depender de Internet. | Pendiente |
| CP-06 | RF-03 | Procesar una imagen borrosa, inclinada o sin texto. | La aplicación presenta el resultado posible o informa que no pudo reconocer texto; no se bloquea. | Pendiente |
| CP-07 | RF-04 | Ejecutar OCR sobre una imagen con texto conocido. | El texto detectado se muestra para revisión. | Pendiente |
| CP-08 | RF-05 | Seleccionar algunos datos detectados y continuar. | Solo los datos seleccionados se conservan para el siguiente paso. | Pendiente |
| CP-09 | RF-06 | Modificar un dato reconocido y guardar los cambios. | Se muestra y conserva el valor corregido. | Pendiente |
| CP-10 | RF-07 | Crear un lote con datos válidos. | El lote se registra y aparece en la consulta. | Pendiente |
| CP-11 | RF-08 | Consultar los lotes registrados. | Se muestran los lotes existentes con información coherente. | Pendiente |
| CP-12 | RF-09 | Modificar los datos de un lote existente. | Los cambios se guardan y aparecen al volver a consultar. | Pendiente |
| CP-13 | RF-10 | Eliminar un lote sin documentos asociados. | El lote deja de aparecer en la consulta y la aplicación confirma o informa el resultado. | Pendiente |
| CP-14 | RF-10 | Intentar eliminar un lote que contiene documentos asociados. | Se aplica la regla de integridad definida por el sistema y se informa el resultado. | Pendiente |
| CP-15 | RF-11 | Registrar un documento y asociarlo a un lote. | El documento queda guardado y relacionado con el lote seleccionado. | Pendiente |
| CP-16 | RF-12 | Consultar los documentos de un lote. | Se muestran los documentos que corresponden a ese lote. | Pendiente |
| CP-17 | RF-13 | Editar información de un documento existente. | Los cambios se guardan y se visualizan al consultar nuevamente. | Pendiente |
| CP-18 | RF-14 | Eliminar un documento existente. | El documento deja de aparecer en la consulta correspondiente. | Pendiente |
| CP-19 | RF-15 | Guardar un lote y documentos, cerrar la aplicación y abrirla nuevamente. | Los registros persisten en SQLite. | Pendiente |
| CP-20 | RF-16 | Exportar a Excel la información de un documento. | Se genera un archivo Excel con los datos seleccionados del documento. | Pendiente |
| CP-21 | RF-17 | Exportar a Excel un lote con varios documentos. | El archivo incluye la información de los documentos del lote y permite identificar su contenido. | Pendiente |
| CP-22 | RF-18 | Provocar un error controlado durante OCR o exportación. | Se informa el error y la aplicación no pierde información previamente guardada. | Pendiente |
| CP-23 | RNF-03 | Ejecutar el flujo de OCR con el dispositivo sin conexión. | El reconocimiento local funciona sin Internet. | Pendiente |
| CP-24 | RNF-04 | Guardar información, cerrar forzosamente la aplicación y volver a abrirla. | Los datos confirmados antes del cierre continúan disponibles. | Pendiente |
| CP-25 | RNF-02 | Procesar un conjunto representativo de imágenes y observar la respuesta de la interfaz. | La operación termina sin bloqueos prolongados ni cierre inesperado. Registrar dispositivo, cantidad y duración. | Pendiente |
| CP-26 | RNF-10 | Abrir el archivo Excel exportado y revisar sus filas y columnas. | Los datos corresponden a la selección o lote exportado y son legibles. | Pendiente |

## 5. Registro de ejecución

Completar esta tabla después de ejecutar los casos:

| ID de prueba | Fecha | Dispositivo / emulador | Resultado (Aprobado / Fallido) | Evidencia o incidencia |
|---|---|---|---|---|
| CP-__ | __/__/____ | __ | __ | __ |

## 6. Criterios de entrada

- Aplicación compilada e instalada en un dispositivo o emulador Android compatible.
- Permisos y recursos necesarios disponibles para los escenarios que los requieren.
- Datos de prueba preparados, evitando utilizar información personal o documentos sensibles reales.
- Base de datos de prueba en un estado conocido.

## 7. Criterios de salida

- Todos los casos definidos para la entrega han sido ejecutados o se ha justificado cuáles quedan pendientes.
- Los resultados y evidencias se han registrado.
- Los defectos encontrados tienen una descripción, prioridad y estado.
- Los fallos críticos que impidan el flujo principal han sido corregidos o reportados explícitamente.

## 8. Evidencias recomendadas

- Captura de la fotografía o imagen importada.
- Resultado de OCR con el dispositivo sin conexión.
- Selección y edición de los datos reconocidos.
- Creación, consulta, modificación y eliminación de lotes y documentos.
- Comprobación de persistencia después de reiniciar la aplicación.
- Archivo Excel generado y evidencia de su contenido.
- Registro de errores controlados y mensajes presentados al usuario.

Las evidencias deben almacenarse en una ubicación acordada por el equipo y referenciarse desde este documento o desde el informe de calidad.
