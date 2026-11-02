# Informe de calidad — CamScanner

## 1. Objetivo
Identificar el estado comprobable del producto, riesgos técnicos y aspectos de calidad que deben atenderse durante el desarrollo y la verificación de CamScanner.

## 2. Alcance y limitaciones de la revisión
Se revisaron los archivos compartidos: `CamScanner.csproj`, modelos `Documento` y `Lote`, `CamScannerDatabase.cs`, `MainPage.xaml`, `MainPage.xaml.cs`, `MauiProgram.cs`, `App.xaml`, `AppShell.xaml` y `Platforms/Android/AndroidManifest.xml`. También se ejecutó una búsqueda de referencias a OCR, cámara, selección de archivos y Excel en `src` (excluyendo `bin` y `obj`), sin coincidencias.

Este diagnóstico se limita a los archivos y resultados suministrados. No equivale a una auditoría exhaustiva ni a pruebas de ejecución en dispositivo.

## 3. Estado técnico comprobado

| Área | Evidencia | Resultado |
|---|---|---|
| Plataforma | `.csproj` declara `net10.0-android`, `UseMaui=true`. | Configuración inicial presente. |
| SQLite | Paquete `sqlite-net-pcl` 1.11.285. | Dependencia declarada. |
| Modelo Lote | Id, Nombre, FechaCreacion, Descripcion. | Presente. |
| Modelo Documento | Id, LoteId, Nombre, RutaImagen, TextoExtraido, FechaCreacion. | Presente. |
| Inicialización de datos | Creación de tablas `Lote` y `Documento`. | Implementada. |
| Consulta de lotes | `ObtenerLotesAsync()`. | Implementada. |
| Guardar lote | `GuardarLoteAsync()` inserta o actualiza. | Implementada. |
| CRUD restante | No se encontraron métodos de eliminación ni persistencia de documentos en el archivo revisado. | No evidenciado. |
| Interfaz | `MainPage.xaml` muestra plantilla, “Hello, World!” y contador. | Interfaz de negocio no evidenciada. |
| OCR/cámara/importación | Búsqueda de referencias sin coincidencias. | No evidenciados. |
| Excel | Sin referencias encontradas ni paquete Excel identificado en `.csproj`. | No evidenciado. |
| Pruebas | No se identificó `tests/` en el listado `git ls-files` compartido. | No evidenciadas en ese listado. |

## 4. Evaluación por características de calidad

| Característica | Situación observada | Acción recomendada |
|---|---|---|
| Adecuación funcional | Interfaz de plantilla y persistencia parcial de lotes. | Implementar y verificar los flujos del alcance. |
| Eficiencia de desempeño | Sin mediciones de OCR, imágenes o exportación. | Medir duración y consumo cuando se incorporen esas funciones. |
| Compatibilidad | Se declara destino Android y API mínima 21; no hay resultados de dispositivos. | Probar emuladores y dispositivos objetivo. |
| Usabilidad | La pantalla inspeccionada es la plantilla de MAUI. | Diseñar y evaluar captura, revisión, lotes y exportación. |
| Confiabilidad | Capa de datos limitada; sin pruebas de recuperación aportadas. | Incorporar manejo de excepciones y pruebas de persistencia/integridad. |
| Seguridad y privacidad | Base local en `FileSystem.AppDataDirectory`; manifiesto declara permisos de red. No se observó permiso de cámara en el manifiesto revisado. | Revisar permisos, almacenamiento y flujo de datos al implementar captura/OCR. |
| Mantenibilidad | Separación inicial entre modelos, datos e interfaz. | Mantener responsabilidades separadas e incorporar servicios específicos. |
| Portabilidad | `.csproj` declara destinos condicionados adicionales; alcance acordado Android. | Priorizar Android y documentar plataformas efectivamente soportadas. |

## 5. Riesgos identificados

Valoraciones preliminares, sujetas a revisión con pruebas reales.

| ID | Riesgo | Probabilidad | Impacto | Acción |
|---|---|---|---|---|
| R-01 | Imágenes borrosas, inclinadas u oscuras reducen precisión OCR. | Alta | Alto | Probar condiciones variadas, permitir corrección manual y comunicar resultados parciales. |
| R-02 | OCR local consume recursos en dispositivos limitados. | Media | Alto | Medir consumo/tiempo y evitar bloquear interfaz. |
| R-03 | Permisos denegados o archivos incompatibles impiden captura/importación. | Media | Medio | Validar permisos y formatos y mostrar mensajes claros. |
| R-04 | La capa SQLite no expone el CRUD completo requerido. | Alta | Alto | Completar operaciones para lotes y documentos y probarlas. |
| R-05 | Eliminaciones pueden dejar relaciones lote-documento inconsistentes. | Media | Alto | Definir integridad referencial y probar lotes con documentos asociados. |
| R-06 | La interfaz actual no ofrece los flujos de negocio. | Alta | Alto | Implementar pantallas de captura, revisión, lotes y exportación. |
| R-07 | La exportación puede generar archivos incompletos o desordenados. | Media | Alto | Definir estructura Excel y validar exportaciones individuales y por lote. |
| R-08 | Ausencia de pruebas automatizadas visibles dificulta detectar regresiones. | Media | Alto | Crear proyecto de pruebas y automatizar validaciones de modelos/persistencia. |
| R-09 | La configuración de permisos Android puede no cubrir futuras capacidades. | Media | Medio | Revisar manifiesto y permisos en tiempo de ejecución. |
| R-10 | Dependencias OCR/Excel pueden no ser compatibles o tener restricciones de licencia. | Media | Medio | Evaluar versiones, compatibilidad y licencias antes de integrarlas. |

## 6. Métricas propuestas
No se suministraron resultados medidos. Recopilar:
- Porcentaje de requisitos probados: requisitos con pruebas ejecutadas / requisitos totales × 100.
- Porcentaje de pruebas aprobadas: casos aprobados / casos ejecutados × 100.
- Tiempo de OCR y exportación en dispositivos identificados.
- Exactitud OCR comparando resultados con transcripciones de referencia.
- Persistencia tras cerrar y abrir la aplicación.
- Defectos por severidad.
- Compatibilidad por modelo y versión Android.

Los umbrales deben acordarse antes de interpretar las mediciones.

## 7. Hallazgos de revisión

| ID | Hallazgo | Severidad sugerida | Evidencia |
|---|---|---|---|
| H-01 | La pantalla principal conserva la plantilla inicial de MAUI. | Alta | `MainPage.xaml` y `.cs`. |
| H-02 | La capa revisada solo consulta y guarda/actualiza lotes. | Alta | `CamScannerDatabase.cs`. |
| H-03 | No se encontraron referencias OCR, cámara, selección de archivos o Excel. | Alta | Búsqueda `grep` en `src`. |
| H-04 | No se identificó carpeta de pruebas en el listado versionado compartido. | Media | Salida de `git ls-files`. |

Son hallazgos de revisión estática/documental, no defectos confirmados en ejecución.

## 8. Acciones de mejora
1. Sustituir la interfaz de plantilla por los flujos de negocio.
2. Completar CRUD para lotes y documentos.
3. Incorporar captura e importación con permisos Android.
4. Seleccionar e integrar OCR local y documentar paquete/versión.
5. Incorporar selección y edición de texto reconocido.
6. Seleccionar e integrar biblioteca Excel.
7. Crear pruebas automatizadas y pruebas funcionales móviles.
8. Registrar evidencias reales y actualizar estados de requisitos.
9. Revisar permisos Android según las capacidades implementadas.

## 9. Conclusión
La revisión confirma una base inicial MAUI y persistencia SQLite con modelos de lote y documento. En los archivos inspeccionados no se evidencian la interfaz de digitalización, OCR, captura/importación, CRUD completo ni exportación Excel. Por ello, la documentación debe reflejar una implementación parcial respecto al alcance acordado. La calidad final requiere completar las funciones, ejecutar las pruebas y registrar evidencias.
