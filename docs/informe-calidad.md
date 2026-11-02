# Informe de calidad — CamScanner

## 1. Objetivo

Identificar riesgos técnicos y funcionales, establecer aspectos de calidad relevantes y proponer acciones de prevención, verificación y mantenimiento para CamScanner, como parte de las actividades de Ingeniería de Software II.

## 2. Estado del producto

De acuerdo con la información suministrada por el equipo, la aplicación se encuentra funcionalmente terminada. Este informe constituye una identificación inicial de riesgos y aspectos que deben verificarse y respaldarse con evidencias.

No se registran métricas de rendimiento, defectos confirmados ni resultados de pruebas porque no se suministraron datos de ejecución. Estos campos deben actualizarse cuando se realicen las pruebas.

## 3. Evaluación de calidad

Se toman como referencia características de calidad pertinentes para una aplicación móvil: adecuación funcional, eficiencia de desempeño, compatibilidad, usabilidad, confiabilidad, seguridad, mantenibilidad y portabilidad.

| Característica | Aspecto a evaluar | Evidencia sugerida |
|---|---|---|
| Adecuación funcional | Que captura, OCR, selección, edición, gestión de lotes y exportación cumplan los requisitos. | Casos de prueba aprobados y demostración de cada flujo. |
| Eficiencia de desempeño | Tiempo de OCR y exportación, consumo de memoria y respuesta de la interfaz. | Mediciones en dispositivos identificados y con conjuntos de imágenes definidos. |
| Compatibilidad | Comportamiento en las versiones y dispositivos Android objetivo. | Matriz de dispositivos y resultados de ejecución. |
| Usabilidad | Claridad de navegación, mensajes, revisión y corrección de datos. | Pruebas con usuarios y registro de observaciones. |
| Confiabilidad | Manejo de errores, permisos denegados, interrupciones y persistencia. | Pruebas negativas, de recuperación y persistencia. |
| Seguridad y privacidad | Protección de imágenes y datos locales, permisos y ausencia de exposición involuntaria. | Revisión de permisos, almacenamiento y flujo de datos. |
| Mantenibilidad | Separación de responsabilidades, legibilidad y facilidad para corregir defectos. | Revisión de código y estructura del repositorio. |
| Portabilidad | Facilidad para compilar y ejecutar en los entornos Android definidos. | Compilación reproducible y pruebas en dispositivos objetivo. |

## 4. Riesgos identificados

La valoración de probabilidad e impacto es preliminar y debe revisarse con los resultados reales de las pruebas.

| ID | Riesgo | Probabilidad | Impacto | Acción preventiva o correctiva |
|---|---|---|---|---|
| R-01 | Imágenes borrosas, inclinadas, oscuras o de baja resolución pueden reducir la precisión del OCR. | Alta | Alto | Probar con diferentes condiciones de captura; informar cuando el reconocimiento sea parcial y permitir corrección manual. |
| R-02 | El OCR local puede consumir recursos elevados en dispositivos con poca memoria o capacidad de procesamiento. | Media | Alto | Medir tiempos y consumo en dispositivos objetivo; evitar bloquear la interfaz y liberar recursos después del procesamiento. |
| R-03 | La denegación de permisos de cámara o acceso a imágenes puede interrumpir la captura o importación. | Media | Medio | Validar permisos antes de iniciar la operación y presentar instrucciones claras al usuario. |
| R-04 | Un error en SQLite puede ocasionar pérdida, inconsistencia o imposibilidad de consultar datos. | Media | Alto | Validar operaciones, controlar excepciones y probar persistencia e integridad de relaciones entre lotes y documentos. |
| R-05 | La eliminación de un lote podría afectar documentos asociados si no se aplican reglas de integridad. | Media | Alto | Definir y probar el comportamiento de eliminación, incluyendo restricciones o eliminación relacionada cuando corresponda. |
| R-06 | La exportación a Excel puede producir archivos incompletos, vacíos o con datos desordenados. | Media | Alto | Validar el contenido exportado con documentos individuales y lotes; comprobar apertura del archivo y correspondencia de datos. |
| R-07 | El tamaño o cantidad de imágenes puede aumentar el tiempo de procesamiento y el consumo de memoria. | Media | Alto | Definir escenarios de carga representativos y medir el comportamiento con lotes pequeños y grandes. |
| R-08 | Diferencias entre versiones o fabricantes Android pueden generar comportamientos distintos. | Media | Medio | Probar en más de una versión/dispositivo dentro del rango soportado y documentar compatibilidad. |
| R-09 | Los datos extraídos pueden contener información sensible almacenada localmente. | Media | Alto | Revisar permisos y almacenamiento, limitar los datos conservados a los necesarios y evitar compartirlos sin acción del usuario. |
| R-10 | Una dependencia OCR o de generación Excel puede presentar incompatibilidades o restricciones de licencia. | Baja/Media | Medio | Identificar las bibliotecas y versiones utilizadas, revisar licencias y validar compatibilidad con .NET 10 y Android. |

## 5. Aspectos de calidad y métricas propuestas

Las métricas siguientes son propuestas para recopilar evidencia; no son resultados medidos ni umbrales ya aprobados.

| Métrica | Forma de medición | Registro requerido |
|---|---|---|
| Porcentaje de casos de prueba aprobados | Casos aprobados / casos ejecutados × 100. | Total ejecutado, aprobado y fallido. |
| Tiempo de procesamiento OCR | Tiempo desde el inicio hasta la presentación del resultado. | Dispositivo, imagen, tamaño y duración. |
| Tiempo de exportación | Tiempo desde la solicitud hasta la generación del archivo. | Cantidad de registros/documentos y duración. |
| Persistencia | Comprobar registros después de cerrar y reabrir la aplicación. | Registros antes y después de reiniciar. |
| Exactitud del OCR | Comparar el texto reconocido con una transcripción de referencia. | Texto esperado, texto obtenido y errores identificados. |
| Defectos por severidad | Clasificar defectos encontrados por impacto. | Identificador, descripción, severidad y estado. |
| Compatibilidad | Ejecución satisfactoria por versión/dispositivo Android. | Modelo, versión Android y resultado. |

Para evaluar la exactitud del OCR puede utilizarse una muestra de documentos con texto de referencia y calcular la proporción de caracteres o palabras reconocidos correctamente. El equipo debe definir el método y el umbral de aceptación antes de interpretar los resultados.

## 6. Registro de defectos

No se han suministrado defectos confirmados. Registrar aquí los hallazgos que se presenten durante la ejecución del plan de pruebas.

| ID | Descripción del defecto | Severidad | Pasos para reproducir | Estado | Responsable |
|---|---|---|---|---|---|
| DEF-__ | Por registrar después de las pruebas. | Por determinar | Por registrar | Pendiente | Por asignar |

## 7. Acciones de mantenimiento

- Corregir los defectos detectados y repetir los casos de prueba relacionados.
- Mantener actualizadas las dependencias de .NET MAUI, OCR y generación de Excel, verificando su compatibilidad.
- Revisar el manejo de excepciones en cámara, importación, OCR, SQLite y exportación.
- Mantener copias de seguridad de los datos de prueba y evitar incluir documentos reales o sensibles en el repositorio.
- Revisar periódicamente la estructura del código para conservar la separación entre interfaz, lógica de negocio y persistencia.
- Actualizar los requisitos, casos de prueba y evidencias cuando cambie el comportamiento de la aplicación.

## 8. Conclusión

CamScanner reúne funciones que requieren especial atención desde la perspectiva de calidad: reconocimiento OCR en condiciones variables, operación sin conexión, persistencia local, integridad entre lotes y documentos y generación correcta de archivos Excel. Los riesgos identificados permiten orientar las pruebas y las acciones de mantenimiento. La valoración definitiva de la calidad debe basarse en resultados medidos, defectos registrados y evidencias obtenidas durante la ejecución del plan de pruebas.
