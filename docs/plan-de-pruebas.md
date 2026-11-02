# Plan de pruebas — CamScanner

**Proyecto:** CamScanner · Android · .NET 10 / .NET MAUI  
**Etapa:** Seguimiento 1, 2 de noviembre de 2026  
**Responsable de pruebas:** Javier Serna  
**Documentación y calidad:** Richard Prado  
**Especificación vigente:** [docs/especificacion.md](especificacion.md)

## 1. Objetivo y alcance

Verificar incrementalmente la digitalización de documentos: captura/importación de imágenes, OCR local, selección y corrección del texto, gestión de lotes y documentos con SQLite y exportación individual o por lote a Excel.

Este documento distingue **casos diseñados**, **pruebas automatizadas aportadas** y **ejecuciones reportadas**. Una función planeada no se considera implementada ni verificada por el hecho de estar documentada. El alcance del proyecto **no incluye exportación ZIP/PDF**.

## 2. Estrategia

- **Partición de equivalencia:** imágenes válidas, inválidas y sin texto; campos correctos e incorrectos.
- **Valores límite:** lista vacía, cantidad de imágenes y longitudes de nombres.
- **Tablas de decisión:** permisos, cancelación, imagen disponible y condiciones de exportación.
- **Pruebas unitarias xUnit:** lógica independiente de MAUI.
- **Pruebas manuales en Android:** cámara, galería, OCR, navegación y permisos.
- **Integración y persistencia:** relaciones entre lote y documento; operaciones SQLite tras reiniciar la aplicación.
- **Regresión:** repetir casos afectados después de cada integración.

## 3. Casos de prueba funcionales y no funcionales

**Estado de los casos:** Pendiente de ejecución verificable, salvo los resultados expresamente consignados como *reportados por Javier* en la sección 5.

| Caso | Requisito vigente | Escenario | Resultado esperado |
|---|---|---|---|
| CP-01 | RF-01 | Capturar foto con permiso | Foto disponible para revisión |
| CP-02 | RF-01, RF-18 | Denegar permiso de cámara | Mensaje claro, sin cierre |
| CP-03 | RF-01 | Cancelar la cámara | No agrega registro ni pierde selección previa |
| CP-04 | RF-02 | Importar una imagen | Imagen disponible |
| CP-05 | RF-02 | Importar varias imágenes | Todas las imágenes seleccionadas aparecen |
| CP-06 | RF-02 | Cancelar el selector | Mantiene el estado anterior |
| CP-07 | RF-03, RNF-03 | OCR con imagen legible sin Internet | Reconoce texto localmente |
| CP-08 | RF-03 | Imagen borrosa | Registra resultado parcial sin bloquearse |
| CP-09 | RF-03, RF-18 | Imagen sin texto | Informa que no se detectó texto |
| CP-10 | RF-04 | Mostrar resultado OCR | Presenta texto reconocido |
| CP-11 | RF-05 | Seleccionar campos detectados | Conserva solamente los elegidos |
| CP-12 | RF-06 | Corregir un campo | Guarda el valor editado |
| CP-13 | RF-07 | Crear lote válido | Queda registrado |
| CP-14 | RF-07, RF-18 | Crear lote con nombre inválido | No guarda y muestra validación |
| CP-15 | RF-08 | Consultar lotes | Lista los lotes existentes |
| CP-16 | RF-09 | Editar lote | Conserva modificaciones |
| CP-17 | RF-10, RNF-09 | Eliminar lote con documentos | Respeta la regla de integridad definida |
| CP-18 | RF-11 | Registrar documento en un lote | Documento asociado al lote correcto |
| CP-19 | RF-12 | Consultar documentos del lote | Muestra solo los asociados |
| CP-20 | RF-13 | Modificar documento | Conserva cambios |
| CP-21 | RF-14 | Eliminar documento | Deja de mostrarse |
| CP-22 | RF-15, RNF-04 | Guardar y reiniciar aplicación | Registros persisten |
| CP-23 | RF-16 | Exportar documento a Excel | Archivo .xlsx con campos seleccionados |
| CP-24 | RF-17 | Exportar lote a Excel | Archivo .xlsx con registros del lote |
| CP-25 | RF-18 | Fallo al importar/guardar/exportar | Mensaje claro y datos anteriores intactos |
| CP-26 | RNF-02 | Procesar varias imágenes | Registrar duración y observar bloqueos |

Los criterios de aceptación CA-01 a CA-18 se encuentran en `docs/especificacion.md`. Para pruebas de eliminación de lotes debe definirse antes si se bloquea la eliminación o si hay borrado en cascada.

## 4. Pruebas automatizadas aportadas por Javier

**Proyecto de pruebas:** `tests/CamScanner.Tests` (xUnit).  
**Servicios:** `src/Services/ValidadorNombres.cs` y `src/Services/AlmacenImagenes.cs`.

| Grupo | Objetivo | Correspondencia con el alcance vigente |
|---|---|---|
| ValidadorNombresTests | Generar, normalizar y validar nombres; detectar vacíos y duplicados | Validaciones auxiliares para documentos; las pruebas de bloqueo de exportación todavía no prueban la exportación Excel |
| AlmacenImagenesTests | Guardar imagen sin alterar contenido, respetar extensión, evitar sobrescrituras y manejar fallos | RF-01, RF-02 y RF-18; almacenamiento de imágenes, distinto de persistencia de entidades SQLite |

Se registran **29 pruebas automatizadas reportadas por Javier** (14 de nombres y 15 de almacenamiento, contando casos parametrizados). El registro original indicó **29/29 aprobadas el 2 de noviembre en Windows** y duración de 2,3 s; este resultado debe respaldarse con salida de `dotnet test` o evidencia equivalente y repetirse tras integrar el PR. No equivale a pruebas automatizadas del OCR ni de SQLite.

Comando de ejecución desde la raíz del repositorio:

```bash
dotnet test tests/CamScanner.Tests/CamScanner.Tests.csproj
```

## 5. Registro de ejecución manual

*Resultados declarados por Javier en su plan original; no verificados independientemente durante la conciliación.*

| Caso del registro original | Fecha | Entorno | Resultado reportado | Observaciones |
|---|---|---|---|---|
| Captura con cámara autorizada | 02/11/2026 | Xiaomi 23090RA98G, Android 16 | OK | Evidencia pendiente de vincular |
| Permiso de cámara denegado | 02/11/2026 | Xiaomi 23090RA98G, Android 16 | OK | Evidencia pendiente de vincular |
| Cancelar cámara | 02/11/2026 | Xiaomi 23090RA98G, Android 16 | OK | Evidencia pendiente de vincular |
| Cámara en emulador | 02/11/2026 | Pixel 7 emulado, Android 16 | OK | La cámara virtual puede simular una captura |

**Advertencia:** el registro anterior no valida automáticamente los demás casos y debe complementarse con capturas, logs o enlaces a incidencias. En particular, OCR sin Internet y exportación Excel no cuentan aquí con resultados de ejecución comprobados.

## 6. Criterios de entrada y salida

**Entrada:** versión identificada por commit; aplicación compilable, dispositivo/emulador y datos sintéticos preparados.  
**Salida:** pruebas ejecutadas con resultado y evidencia; defectos registrados en Trello; fallos críticos corregidos o documentados; relación clara entre prueba y requisito.

## 7. Pendientes prioritarios

1. Verificar compilación Android y ejecutar `dotnet test` sobre la versión integrada.
2. Validar en dispositivo la captura, importación y OCR offline; adjuntar evidencias.
3. Implementar y probar CRUD de lotes/documentos y persistencia SQLite.
4. Diseñar pruebas de selección/corrección de campos y exportación Excel cuando esos módulos existan.
5. Concretar reglas de eliminación con documentos asociados, formatos permitidos y umbrales de rendimiento.

## 8. Trazabilidad de aportes

- **Richard:** planteamiento general de requisitos y cobertura funcional.
- **Javier:** diseño detallado de pruebas manuales de captura/OCR, código de pruebas xUnit y reporte inicial de resultados.
- **Conciliación:** unificación de los casos bajo los RF-01 a RF-18 vigentes; retirada de referencias a los antiguos requisitos ZIP/PDF sin borrar el historial Git de los autores.
