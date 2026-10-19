using GestionTareas.Controlador;
using GestionTareas.Entidades;

TListaTarea gestor = new();

while (true)
{
    Console.WriteLine("\n=== SISTEMA DE GESTIÓN DE TAREAS DE DESARROLLO ===");
    Console.WriteLine("1. Registrar tarea");
    Console.WriteLine("2. Listar tareas");
    Console.WriteLine("3. Cambiar estado de tarea");
    Console.WriteLine("0. Salir");
    Console.Write("Seleccione una opción: ");
    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            RegistrarTarea(gestor);
            break;
        case "2":
            ListarTareas(gestor);
            break;
        case "3":
            CambiarEstado(gestor);
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Opción no válida. Intente nuevamente.");
            break;
    }
}

static void RegistrarTarea(TListaTarea gestor)
{
    Console.Write("ID numérico: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("El ID debe ser un número entero.");
        return;
    }

    Console.Write("Título: ");
    string titulo = Console.ReadLine() ?? string.Empty;
    Console.Write("Descripción: ");
    string descripcion = Console.ReadLine() ?? string.Empty;
    Console.Write("Responsable: ");
    string responsable = Console.ReadLine() ?? string.Empty;
    Console.Write("Prioridad (Baja, Media, Alta): ");

    if (!Enum.TryParse(Console.ReadLine(), ignoreCase: true, out PrioridadTarea prioridad)
        || !Enum.IsDefined(prioridad))
    {
        Console.WriteLine("Prioridad no válida. Use Baja, Media o Alta.");
        return;
    }

    try
    {
        gestor.Registrar(new Tarea(id, titulo, descripcion, responsable, prioridad));
        Console.WriteLine("Tarea registrada correctamente.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"No se pudo registrar la tarea: {ex.Message}");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"No se pudo registrar la tarea: {ex.Message}");
    }
}

static void ListarTareas(TListaTarea gestor)
{
    IReadOnlyList<Tarea> tareas = gestor.ObtenerTodas();
    if (tareas.Count == 0)
    {
        Console.WriteLine("Todavía no hay tareas registradas.");
        return;
    }

    Console.WriteLine("\nID | TÍTULO | RESPONSABLE | PRIORIDAD | ESTADO");
    Console.WriteLine(new string('-', 65));
    foreach (Tarea tarea in tareas)
    {
        Console.WriteLine($"{tarea.Id} | {tarea.Titulo} | {tarea.Responsable} | {tarea.Prioridad} | {tarea.Estado}");
    }
}

static void CambiarEstado(TListaTarea gestor)
{
    Console.Write("ID de la tarea: ");
    if (!int.TryParse(Console.ReadLine(), out int id))
    {
        Console.WriteLine("El ID debe ser un número entero.");
        return;
    }

    Console.Write("Nuevo estado (Pendiente, EnProgreso, Finalizada): ");
    if (!Enum.TryParse(Console.ReadLine(), ignoreCase: true, out EstadoTarea estado)
        || !Enum.IsDefined(estado))
    {
        Console.WriteLine("Estado no válido.");
        return;
    }

    Console.WriteLine(gestor.CambiarEstado(id, estado)
        ? "Estado actualizado correctamente."
        : "No existe una tarea con ese ID.");
}
