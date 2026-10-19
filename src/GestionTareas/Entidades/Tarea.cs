namespace GestionTareas.Entidades;

public enum PrioridadTarea
{
    Baja,
    Media,
    Alta
}

public enum EstadoTarea
{
    Pendiente,
    EnProgreso,
    Finalizada
}

public class Tarea
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string Responsable { get; set; } = string.Empty;
    public PrioridadTarea Prioridad { get; set; } = PrioridadTarea.Media;
    public EstadoTarea Estado { get; set; } = EstadoTarea.Pendiente;

    public Tarea()
    {
    }

    public Tarea(int id, string titulo, string descripcion, string responsable,
        PrioridadTarea prioridad, EstadoTarea estado = EstadoTarea.Pendiente)
    {
        Id = id;
        Titulo = titulo;
        Descripcion = descripcion;
        Responsable = responsable;
        Prioridad = prioridad;
        Estado = estado;
    }
}
