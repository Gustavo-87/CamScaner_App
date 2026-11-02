# Especificación de requisitos — CamScanner

## 1. Introducción

### 1.1 Propósito

Este documento define los requisitos funcionales, no funcionales y criterios de aceptación de CamScanner, una aplicación móvil Android desarrollada con .NET 10, .NET MAUI y C#. La especificación sirve como referencia para el desarrollo, las pruebas y la evaluación de calidad del producto en Ingeniería de Software II.

### 1.2 Alcance

La aplicación permite capturar o importar fotografías de documentos, reconocer su contenido mediante OCR local, seleccionar y corregir la información detectada, organizar documentos en lotes, almacenar la información en SQLite y exportarla a Excel.

El procesamiento OCR se realiza localmente y no requiere conexión a Internet. Esta condición se refiere al reconocimiento de texto; no implica que cualquier otra función del dispositivo o integración futura funcione sin conectividad.

### 1.3 Usuarios previstos

Personas que necesitan digitalizar documentos físicos, extraer información de ellos, organizarla y exportarla para su consulta o procesamiento posterior.

### 1.4 Definiciones

| Término | Definición |
|---|---|
| OCR | Reconocimiento óptico de caracteres: proceso de identificar texto presente en una imagen. |
| Lote | Agrupación lógica de documentos para facilitar su organización y exportación conjunta. |
| CRUD | Operaciones de crear, consultar, actualizar y eliminar registros. |
| SQLite | Sistema de base de datos relacional local utilizado para persistir información. |
| Exportación | Generación de un archivo Excel con la información seleccionada. |

## 2. Descripción general

### 2.1 Perspectiva del producto

CamScanner es una aplicación móvil Android desarrollada con .NET MAUI y C#. Utiliza almacenamiento local SQLite y un mecanismo OCR que funciona en el dispositivo. La aplicación integra captura/importación de imágenes, reconocimiento de texto, revisión de datos, gestión de lotes y exportación a Excel.

### 2.2 Funciones principales

- Capturar fotografías de documentos.
- Importar imágenes de documentos desde el dispositivo.
- Reconocer texto mediante OCR local.
- Seleccionar y corregir información reconocida.
- Organizar documentos en lotes.
- Crear, consultar, modificar y eliminar lotes y documentos.
- Guardar información localmente en SQLite.
- Exportar información a Excel por documento o por lote.

### 2.3 Restricciones conocidas

- La plataforma objetivo indicada para el proyecto es Android.
- La solución se desarrolla con .NET 10, .NET MAUI y C#.
- El reconocimiento OCR debe poder ejecutarse sin conexión a Internet.
- La persistencia de datos se realiza localmente mediante SQLite.
- La exportación requerida es a Excel.

No se especifican en la información disponible el motor OCR, la biblioteca de Excel, el esquema detallado de la base de datos, la versión mínima de Android ni los formatos de imagen admitidos. Estos datos deben completarse a partir de la implementación real.

## 3. Requisitos funcionales

| ID | Requisito | Prioridad |
|---|---|---|
| RF-01 | El sistema debe permitir capturar una fotografía de un documento mediante la cámara del dispositivo. | Alta |
| RF-02 | El sistema debe permitir importar una o varias imágenes de documentos desde el dispositivo. | Alta |
| RF-03 | El sistema debe procesar una imagen y reconocer su contenido textual mediante OCR local, sin requerir Internet para el reconocimiento. | Alta |
| RF-04 | El sistema debe mostrar al usuario el texto o la información detectada por el OCR. | Alta |
| RF-05 | El sistema debe permitir seleccionar los datos reconocidos que el usuario desea conservar. | Alta |
| RF-06 | El sistema debe permitir corregir o editar la información extraída antes de guardarla o exportarla. | Alta |
| RF-07 | El sistema debe permitir crear lotes para agrupar documentos. | Alta |
| RF-08 | El sistema debe permitir consultar los lotes existentes y su información relacionada. | Alta |
| RF-09 | El sistema debe permitir modificar la información de un lote. | Alta |
| RF-10 | El sistema debe permitir eliminar un lote de acuerdo con las reglas de integridad definidas por la aplicación. | Media |
| RF-11 | El sistema debe permitir registrar documentos y asociarlos a un lote cuando corresponda. | Alta |
| RF-12 | El sistema debe permitir consultar los documentos almacenados y su información. | Alta |
| RF-13 | El sistema debe permitir modificar la información de un documento. | Alta |
| RF-14 | El sistema debe permitir eliminar documentos. | Media |
| RF-15 | El sistema debe almacenar localmente en SQLite los lotes, documentos y datos que correspondan. | Alta |
| RF-16 | El sistema debe exportar a Excel la información seleccionada de un documento individual. | Alta |
| RF-17 | El sistema debe exportar a Excel la información de los documentos pertenecientes a un lote. | Alta |
| RF-18 | El sistema debe informar al usuario cuando ocurra un error durante la captura, importación, lectura OCR, persistencia o exportación. | Alta |

## 4. Requisitos no funcionales

| ID | Característica | Requisito |
|---|---|---|
| RNF-01 | Usabilidad | La interfaz debe permitir comprender las acciones principales de captura, revisión, organización y exportación sin conocimientos técnicos especializados. |
| RNF-02 | Rendimiento | El procesamiento de imágenes y OCR debe completarse en un tiempo razonable para el dispositivo Android utilizado, sin bloquear innecesariamente la interfaz. |
| RNF-03 | Disponibilidad sin conexión | El reconocimiento OCR debe funcionar sin conexión a Internet. |
| RNF-04 | Persistencia | La información guardada debe permanecer disponible después de cerrar y volver a abrir la aplicación, siempre que los datos locales no hayan sido eliminados. |
| RNF-05 | Confiabilidad | Los errores de captura, OCR, base de datos o exportación deben manejarse sin provocar cierres inesperados ni pérdida injustificada de información. |
| RNF-06 | Compatibilidad | La aplicación debe ejecutarse en dispositivos Android que cumplan los requisitos de versión y recursos definidos por el proyecto. |
| RNF-07 | Mantenibilidad | El código debe organizarse de forma que facilite modificar la interfaz, la lógica de negocio, el acceso a datos y los procesos de OCR/exportación. |
| RNF-08 | Privacidad | Las imágenes y los datos procesados mediante OCR deben tratarse localmente según el alcance definido, evitando transmitirlos a servicios externos sin autorización. |
| RNF-09 | Integridad | Las operaciones sobre lotes y documentos deben conservar relaciones y consistencia de los datos almacenados. |
| RNF-10 | Exportación | Los archivos Excel generados deben contener los datos seleccionados y mantener una organización comprensible para el usuario. |

## 5. Criterios de aceptación

Los siguientes criterios permiten comprobar cada requisito. Los resultados de ejecución deben registrarse en `plan-de-pruebas.md`.

| ID | Criterio de aceptación |
|---|---|
| CA-01 | Al conceder los permisos requeridos, el usuario puede tomar una fotografía y visualizarla o incorporarla al flujo de trabajo. |
| CA-02 | El usuario puede seleccionar imágenes del dispositivo y agregarlas al flujo de trabajo. |
| CA-03 | Al procesar una imagen compatible, la aplicación presenta el texto que el OCR local logra reconocer sin necesitar conexión a Internet. |
| CA-04 | El texto detectado se presenta de forma que el usuario pueda revisarlo. |
| CA-05 | El usuario puede seleccionar los datos que desea conservar y la aplicación mantiene esa selección. |
| CA-06 | El usuario puede editar un dato reconocido y visualizar el valor corregido. |
| CA-07 | El usuario puede crear un lote y encontrarlo posteriormente en la consulta de lotes. |
| CA-08 | Al consultar un lote, se muestra la información correspondiente y los documentos asociados, si existen. |
| CA-09 | El usuario puede modificar un lote y consultar los cambios guardados. |
| CA-10 | El usuario puede eliminar un lote conforme a las reglas de integridad de la aplicación; el sistema informa si la operación no se puede completar. |
| CA-11 | El usuario puede registrar un documento y asociarlo al lote correspondiente. |
| CA-12 | El usuario puede consultar un documento almacenado y su información. |
| CA-13 | El usuario puede modificar un documento y consultar los cambios después de guardarlos. |
| CA-14 | El usuario puede eliminar un documento y comprobar que ya no aparece en la consulta correspondiente. |
| CA-15 | Después de guardar datos y reiniciar la aplicación, los registros continúan disponibles en SQLite. |
| CA-16 | Al exportar un documento, se genera un archivo Excel que contiene la información seleccionada para ese documento. |
| CA-17 | Al exportar un lote, el archivo Excel contiene la información correspondiente a los documentos incluidos en ese lote. |
| CA-18 | Ante un error en cualquiera de las operaciones principales, se informa al usuario y la aplicación conserva los datos que no se hayan confirmado como eliminados. |

## 6. Reglas y validaciones por definir

Para cerrar la especificación con el comportamiento exacto de la aplicación, el equipo debe documentar a partir del código y de las decisiones funcionales:

- Formatos de imagen admitidos y límites de tamaño o resolución.
- Idiomas y tipos de texto reconocidos por el motor OCR.
- Estructura de los campos extraídos y reglas para seleccionar información.
- Campos obligatorios y reglas de validación de lotes y documentos.
- Comportamiento al eliminar un lote que contiene documentos.
- Estructura, nombre y extensión exacta del archivo Excel generado.
- Tratamiento de duplicados, errores de OCR y documentos sin texto reconocible.
- Versión mínima de Android y dispositivos objetivo.

## 7. Trazabilidad

Los requisitos funcionales RF-01 a RF-18 se relacionan con los criterios de aceptación CA-01 a CA-18, respectivamente. Los requisitos no funcionales RNF-01 a RNF-10 deben verificarse mediante pruebas de usabilidad, rendimiento, funcionamiento sin conexión, persistencia, confiabilidad, compatibilidad, mantenibilidad, privacidad, integridad y revisión de archivos exportados.
