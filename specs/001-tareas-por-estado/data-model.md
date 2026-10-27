# Data Model: Consultar tareas por estado

## Domain model

### `Tarea`

| Field | Type | Constraints | Notes |
|-------|------|-------------|-------|
| Id | int | > 0 | Unique identifier for each task |
| Titulo | string | required | User-facing task summary |
| Descripcion | string | optional but stored as text | Existing business field |
| Responsable | string | required | Must be present to register |
| Prioridad | `PrioridadTarea` | enum in { Baja, Media, Alta } | Existing field, unchanged |
| Estado | `EstadoTarea` | enum in { Pendiente, EnProgreso, Finalizada } | Existing field, used for filtering |

### `EstadoTarea`

```csharp
public enum EstadoTarea
{
	Pendiente,
	EnProgreso,
	Finalizada
}
```

## Validation rules

- `Tarea.Id` must be greater than zero.
- `Tarea.Titulo` cannot be empty or whitespace.
- `Tarea.Responsable` cannot be empty or whitespace.
- `Prioridad` must be one of the defined values.
- The existing `EstadoTarea` domain values remain exactly `Pendiente`, `EnProgreso` and `Finalizada`.
- For the new query input, only those state names are accepted, without case sensitivity; numeric inputs such as `0`, `1` and `2`, unknown names and unsupported values are invalid.
- `TListaTarea` maintains the collection in memory and prevents duplicate IDs.

## State transitions

- Current transitions remain the same as today: tasks are created with default `Pendiente`, then can be updated through the existing change-state flow.
- The filter-by-state feature does not change any state; it only reads and displays matching tasks.

## Relationship notes

- `TListaTarea` owns the collection of tasks in memory.
- Each `Tarea` belongs to the same in-memory list and is read using the existing patterns already used for `ObtenerTodas` and `ObtenerPorPrioridad`.
