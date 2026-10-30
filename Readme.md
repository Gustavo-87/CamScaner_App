# CamScaner — App de Supervisión en Campo

---

## 1. Equipo y roles

| Integrante         | Rol                                     | Responsabilidad principal                                                                                                                    |
| ------------------ | --------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- |
| Gustavo Piedrahita | Líder técnico                         | Coordina el alcance, la arquitectura y la integración de los cambios.                                                                       |
| Javier Serna       | Responsable de pruebas                  | Diseña los casos de prueba y coordina su automatización.                                                                                   |
| Richard Prado      | Responsable de calidad y documentación | Revisa el código, registra defectos, propone acciones de mantenimiento y mantiene el README, los documentos y la evidencia de las entregas. |

> Los roles orientan la responsabilidad principal, pero cada integrante conoce y responde por todo el código del repositorio.

---

## 2. Descripción del proyecto

**CamScaner** es una aplicación móvil multiplataforma, desarrollada con **.NET MAUI y C#**, pensada para agilizar los procesos de supervisión logística que hoy se realizan de forma manual y lenta.

La app permitirá **capturar fotografías** con el dispositivo o **importarlas de forma masiva** desde la galería, **nombrarlas y organizarlas**, y **empaquetarlas** en un archivo ZIP o en un PDF con las imágenes y sus nombres en cuadrícula, listos para enviar o compartir.

### Objetivo general

Optimizar el trabajo de los supervisores en campo mediante la digitalización del registro fotográfico y su posterior envío.

### Objetivos específicos

1. Permitir el registro fotográfico en campo (cámara y galería) sin procesos manuales.
2. Empaquetar las imágenes en un `.zip` con nombres definidos por el usuario.
3. Generar un PDF con las imágenes y sus nombres en cuadrícula, como reporte visual.
4. Facilitar el envío del ZIP, del PDF y de imágenes individuales mediante las opciones de compartir del dispositivo.
5. Verificar la aplicación con casos de prueba diseñados con las técnicas vistas en clase y automatizados en parte.
6. Evaluar la calidad del producto, registrar defectos y proponer acciones de mantenimiento.

### Beneficios esperados

- Eliminar procesos manuales y repetitivos.
- Ahorrar tiempo en la supervisión y en el envío de reportes fotográficos.
- Aumentar la eficiencia y la productividad en operaciones logísticas.
- Ser accesible para cualquier supervisor sin conocimientos técnicos.

### Origen de la idea

La idea parte de una aplicación previa de supervisión en campo. El proyecto final se desarrolla como una aplicación nueva, con repositorio propio.

## 3. Alcance

### Versión inicial

- Captura de foto desde la cámara del dispositivo.
- Selección múltiple de imágenes desde la galería.
- Asignación de título al paquete y de nombre a cada imagen.
- Eliminación de imágenes de la lista antes de exportar.
- Generación de un archivo `.zip` con las imágenes renombradas.
- Generación de un archivo `.pdf` con las imágenes y sus nombres ordenados en cuadrículas.
- Compartir el ZIP, el PDF o una imagen individual mediante el menú nativo del dispositivo.
- Validaciones de entrada y manejo de errores con mensajes al usuario.

### Mejoras y funciones futuras

Una vez terminada la versión inicial, el equipo evaluará mejoras como:

- Guardar los reportes y sus fotos en una base de datos local, con un historial consultable.
- Conservar la proporción de las fotos y manejar nombres largos en el PDF.
- Procesar el ZIP y el PDF en segundo plano para lotes grandes.
- Otras funciones que surjan durante el desarrollo.

### Fuera del alcance (por ahora)

- Sincronización con servidores o servicios en la nube.
- Autenticación de usuarios.
- Edición de imágenes (recorte, filtros, anotaciones).

> El alcance se mantiene pequeño a propósito: es preferible un producto acotado y bien terminado que uno ambicioso y frágil.

---

## 4. Requerimientos

### 4.1 Funcionales

| ID    | Requerimiento                                                                                                                                                                                                              |
| ----- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| RF-01 | La app debe permitir tomar una foto con la cámara y agregarla a la lista de trabajo.                                                                                                                                      |
| RF-02 | La app debe permitir seleccionar varias imágenes de la galería a la vez.                                                                                                                                                 |
| RF-03 | Cada imagen agregada debe recibir un nombre editable (por defecto, un consecutivo).                                                                                                                                        |
| RF-04 | La app debe permitir quitar una imagen de la lista.                                                                                                                                                                        |
| RF-05 | La app debe exigir un título para el paquete antes de exportar.                                                                                                                                                           |
| RF-06 | La app debe impedir la exportación si hay nombres de imagen repetidos o vacíos, e informar al usuario.                                                                                                                   |
| RF-07 | La app debe impedir la exportación si la lista de imágenes está vacía.                                                                                                                                                 |
| RF-08 | La app debe generar un `.zip` con las imágenes, nombradas según lo definido por el usuario y conservando su extensión.                                                                                                |
| RF-09 | La app debe generar un PDF con las imágenes y sus nombres organizados en cuadrícula, agregando páginas cuando se llene una. _(Tamaño de hoja y número de imágenes por página por definir en la especificación.)_ |
| RF-10 | La app debe permitir compartir el ZIP y el PDF generados mediante las opciones del dispositivo.                                                                                                                            |
| RF-11 | La app debe permitir compartir una imagen individual de la lista.                                                                                                                                                          |
| RF-12 | Ante un fallo o una cancelación al exportar, la app no debe perder la lista de imágenes del usuario.                                                                                                                     |
| RF-13 | La app debe mostrar un mensaje claro cuando falle la captura, la selección o la exportación.                                                                                                                             |

### 4.2 No funcionales

| ID     | Requerimiento                                                                                                                                                                                                           |
| ------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| RNF-01 | **Usabilidad:** interfaz simple, pensada para usuarios no técnicos.                                                                                                                                              |
| RNF-02 | **Portabilidad:** compatible con Android e iOS mediante .NET MAUI.                                                                                                                                                |
| RNF-03 | **Rendimiento:** la interfaz no debe congelarse mientras se genera el ZIP o el PDF, y la generación debe completarse en un tiempo razonable para lotes típicos. _(Umbral por definir en la especificación.)_ |
| RNF-04 | **Confiabilidad:** ante un error, la app no debe cerrarse inesperadamente.                                                                                                                                        |
| RNF-05 | **Seguridad y privacidad:** no se suben al repositorio contraseñas, archivos `.env` ni datos reales.                                                                                                           |
| RNF-06 | **Mantenibilidad:** lógica separada de la interfaz y código versionado en Git con commits pequeños y descriptivos.                                                                                             |

> Los criterios de aceptación de cada requerimiento se detallarán en [`docs/especificacion.md`](docs/especificacion.md).

---

## 5. Tecnologías

| Tecnología                                                               | Uso                                                        |
| ------------------------------------------------------------------------- | ---------------------------------------------------------- |
| .NET MAUI (C#), versión más reciente (por definir al crear el proyecto) | Desarrollo multiplataforma de la aplicación.              |
| APIs de cámara y selección de archivos de MAUI                          | Captura de fotos e importación desde la galería.         |
| Compresión ZIP de .NET                                                   | Creación del archivo ZIP.                                 |
| Biblioteca de generación de PDF _(por definir)_                        | Creación del PDF con las imágenes en cuadrícula.        |
| Opciones de compartir de MAUI                                             | Compartir los archivos generados.                          |
| Git y GitHub                                                              | Control de versiones y entregas mediante etiquetas (tags). |
| Trello                                                                    | Gestión del proyecto.                                     |

---

## 6. Estructura del repositorio

```
proyecto-final/
├── README.md
├── docs/
│   ├── especificacion.md     ← requisitos y criterios de aceptación
│   ├── plan-de-pruebas.md    ← casos de prueba diseñados
│   └── informe-calidad.md    ← defectos, métricas y mantenimiento
├── src/                      ← código fuente (proyecto .NET MAUI)
└── tests/                    ← pruebas automatizadas
```

---

## 7. Plan de trabajo, prioridades y riesgos

### Actividades de la planeación

| # | Actividad                                            | Responsable                      |
| - | ---------------------------------------------------- | -------------------------------- |
| 1 | Definir objetivos y alcance del proyecto             | Todo el equipo                   |
| 2 | Identificar y documentar los requerimientos          | Líder técnico y documentación |
| 3 | Revisar la estructura del repositorio                | Todo el equipo                   |
| 4 | Distribuir responsabilidades entre los integrantes   | Líder técnico                  |
| 5 | Elaborar el plan de trabajo y establecer prioridades | Líder técnico                  |
| 6 | Definir los casos de prueba iniciales                | Responsable de pruebas           |
| 7 | Identificar riesgos y necesidades técnicas          | Calidad y líder técnico        |

### Riesgos y necesidades técnicas identificadas

| Riesgo                                                                                                                      | Impacto | Acción propuesta                                                                                      |
| --------------------------------------------------------------------------------------------------------------------------- | ------- | ------------------------------------------------------------------------------------------------------ |
| Si la lógica queda mezclada con la interfaz, será difícil probarla de forma automatizada.                                | Alto    | Separar desde el diseño la lógica (nombres, ZIP, PDF) de las pantallas y ubicarla en clases propias. |
| Permisos de cámara y almacenamiento en Android e iOS.                                                                      | Medio   | Documentar y probar el comportamiento cuando el usuario los niega.                                     |
| Lotes grandes de fotos de alta resolución pueden consumir mucha memoria o congelar la pantalla al generar el ZIP o el PDF. | Alto    | Procesar en segundo plano, liberar recursos y probar con lotes grandes.                                |
| Formatos de imagen no soportados por la biblioteca de PDF (por ejemplo, HEIC en iOS) o archivos que ya no existen.          | Alto    | Manejar errores y diseñar casos con formatos y archivos faltantes.                                    |
| La biblioteca de PDF y las fuentes pueden tener restricciones de licencia o requerir configuración adicional.              | Medio   | Elegir la biblioteca temprano y revisar licencias de paquetes y fuentes.                               |
| Títulos y nombres con caracteres no válidos para nombres de archivo (`/`, `:`) o repetidos al ignorar mayúsculas.    | Medio   | Definir reglas de validación en la especificación y probarlas con valores límite.                   |
| Perder el trabajo del usuario si cancela o falla el menú de compartir.                                                     | Medio   | Conservar la lista hasta confirmar la exportación y probar la cancelación.                           |
| Las pruebas de interfaz dependen de un dispositivo o emulador.                                                              | Medio   | Priorizar pruebas unitarias sobre la lógica y documentar las pruebas manuales.                        |
| El alcance puede quedar corto frente a lo sugerido en los lineamientos (persistencia en base de datos).                     | Medio   | Acordar con el docente el alcance antes de la especificación final.                                   |

> Estos riesgos se ampliarán durante el desarrollo en [`docs/informe-calidad.md`](docs/informe-calidad.md).

---

## 8. Estrategia inicial de pruebas

- **Técnicas de diseño:** partición de equivalencia, análisis de valores límite y tablas de decisión, según lo visto en clase.
- **Casos iniciales a diseñar:** título vacío, nombres repetidos, nombres vacíos, lista sin imágenes, imágenes de distintas extensiones, cancelación de la cámara o de la galería y falla al compartir. Para el PDF: una sola imagen, límite de página (por ejemplo, justo al llenarse y una más), cantidad que no llena la cuadrícula, varias páginas, y nombres largos, con acentos o caracteres especiales (por ejemplo, ñ).
- **Automatización:** pruebas unitarias sobre la lógica de validación y de generación del ZIP y del PDF, ubicadas en `tests/`.
- **Pruebas manuales:** flujo completo en dispositivo o emulador, documentado en [`docs/plan-de-pruebas.md`](docs/plan-de-pruebas.md).
