using GestionTareas.Entidades;

namespace GestionTareas.Controlador;

/// <summary>
/// Administra las tareas en memoria. En esta primera versión no se usa una base de datos.
/// </summary>
public class TListaTarea
{
    private readonly List<Tarea> _listaTareas = new();

    public Tarea Registrar(Tarea tarea)
    {
        ArgumentNullException.ThrowIfNull(tarea);

        if (tarea.Id <= 0)
            throw new ArgumentException("El identificador debe ser mayor que cero.", nameof(tarea));

        if (string.IsNullOrWhiteSpace(tarea.Titulo))
            throw new ArgumentException("El título es obligatorio.", nameof(tarea));

        if (string.IsNullOrWhiteSpace(tarea.Responsable))
            throw new ArgumentException("El responsable es obligatorio.", nameof(tarea));

        if (!Enum.IsDefined(tarea.Prioridad))
            throw new ArgumentException("La prioridad no es válida.", nameof(tarea));

        if (_listaTareas.Any(t => t.Id == tarea.Id))
            throw new InvalidOperationException($"Ya existe una tarea con el ID {tarea.Id}.");

        _listaTareas.Add(tarea);
        return tarea;
    }

    public IReadOnlyList<Tarea> ObtenerTodas()
    {
        return _listaTareas.AsReadOnly();
    }

    public bool CambiarEstado(int id, EstadoTarea nuevoEstado)
    {
        if (!Enum.IsDefined(nuevoEstado))
            throw new ArgumentException("El estado no es válido.", nameof(nuevoEstado));

        Tarea? tarea = _listaTareas.FirstOrDefault(t => t.Id == id);
        if (tarea is null)
            return false;

        tarea.Estado = nuevoEstado;
        return true;
    }
}
