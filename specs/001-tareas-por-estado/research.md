# Research: Consultar tareas por estado

## Decisions

- Los únicos estados actualmente permitidos son `Pendiente`, `EnProgreso` y `Finalizada`; se reutiliza el enum `EstadoTarea` existente y no se agregan ni renombran valores.
- Para la nueva consulta se aceptan únicamente esos nombres, sin distinguir mayúsculas y minúsculas. Las entradas numéricas (`0`, `1`, `2`), desconocidas o no admitidas son inválidas. No debe aceptarse una conversión numérica del enum como si fuera el nombre de un estado.
- La consulta es de solo lectura: filtra las tareas en memoria por su estado y deja los datos almacenados intactos.
- Cuando la lista está vacía o no hay coincidencias para un estado válido, la aplicación comunica claramente que no hay tareas coincidentes.
- Una entrada inválida muestra un mensaje comprensible, no ejecuta la consulta ni cambia datos y devuelve el control al menú.

## Rationale

- La solución respeta la arquitectura existente de entidad, controlador y menú de consola.
- El almacenamiento continúa en memoria y no requiere nuevas dependencias.
- La conversión de entrada debe distinguir nombres de valores numéricos para cumplir la regla de que solo se aceptan los nombres visibles de los estados.
- Mantener los tres estados existentes evita cambios en las reglas del dominio.

## Alternatives considered

1. Crear una nueva cadena o modelo de estado para esta consulta.
   - Rechazado: duplicaría las reglas del dominio y podría introducir inconsistencias.

2. Aceptar directamente cualquier valor que pueda convertirse numéricamente al enum.
   - Rechazado: entradas como `0`, `1` o `2` deben ser inválidas aunque correspondan a valores internos del enum.

3. Añadir una base de datos o servicio externo.
   - Rechazado: excede el alcance local y en memoria del proyecto.

4. Cambiar el menú principal a un patrón distinto del existente.
   - Rechazado: el flujo actual de consola es suficiente y no requiere un cambio arquitectónico.

## Test strategy

- Probar el método de consulta del controlador con tareas en cada uno de los tres estados y con un estado sin coincidencias; verificar que la lista devuelta contiene solo coincidencias y que la lista de origen y los estados de las tareas no cambian.
- Probar el flujo de consola iniciando la aplicación existente como proceso hijo con entrada estándar y salida redirigidas. Alimentar una secuencia determinista de menú, registro/cambio de estado, consulta con entrada numérica y desconocida, consulta con nombre válido de capitalización mixta, listado posterior y salida; comprobar mensajes, recuperación del menú, resultado filtrado y estado conservado.
- La estrategia de proceso hijo usa las herramientas .NET ya disponibles y no requiere modificar la arquitectura del programa ni agregar dependencias.
