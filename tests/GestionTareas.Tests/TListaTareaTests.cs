using GestionTareas.Controlador;
using GestionTareas.Entidades;
using Xunit;

namespace GestionTareas.Tests;

public class TListaTareaTests
{
    [Fact]
    public void Registrar_TareaValida_AgregaLaTarea()
    {
        TListaTarea gestor = new();
        Tarea tarea = CrearTarea(1, "Preparar repositorio");

        gestor.Registrar(tarea);

        Assert.Single(gestor.ObtenerTodas());
        Assert.Equal("Preparar repositorio", gestor.ObtenerTodas()[0].Titulo);
    }

    [Fact]
    public void Registrar_TituloVacio_LanzaExcepcion()
    {
        TListaTarea gestor = new();
        Tarea tarea = CrearTarea(1, "   ");

        Assert.Throws<ArgumentException>(() => gestor.Registrar(tarea));
        Assert.Empty(gestor.ObtenerTodas());
    }

    [Fact]
    public void Registrar_IDDuplicado_LanzaExcepcion()
    {
        TListaTarea gestor = new();
        gestor.Registrar(CrearTarea(1, "Primera tarea"));

        Assert.Throws<InvalidOperationException>(() =>
            gestor.Registrar(CrearTarea(1, "Segunda tarea")));
    }

    [Fact]
    public void CambiarEstado_IDExistente_ActualizaEstado()
    {
        TListaTarea gestor = new();
        gestor.Registrar(CrearTarea(1, "Escribir pruebas"));

        bool actualizado = gestor.CambiarEstado(1, EstadoTarea.Finalizada);

        Assert.True(actualizado);
        Assert.Equal(EstadoTarea.Finalizada, gestor.ObtenerTodas()[0].Estado);
    }

    [Fact]
    public void CambiarEstado_IDInexistente_RetornaFalse()
    {
        TListaTarea gestor = new();

        Assert.False(gestor.CambiarEstado(999, EstadoTarea.Finalizada));
    }
    [Fact]
    public void ObtenerPorPrioridad_SoloDevuelveTareasSolicitadas()
    {
        TListaTarea gestor = new();

        gestor.Registrar(
            CrearTarea(1, "Preparar repositorio", PrioridadTarea.Alta));

        gestor.Registrar(
            CrearTarea(2, "Documentar proyecto", PrioridadTarea.Media));

        gestor.Registrar(
            CrearTarea(3, "Revisar pruebas", PrioridadTarea.Alta));

        IReadOnlyList<Tarea> resultado =
            gestor.ObtenerPorPrioridad(PrioridadTarea.Alta);

        Assert.Equal(2, resultado.Count);

        Assert.All(
            resultado,
            tarea => Assert.Equal(PrioridadTarea.Alta, tarea.Prioridad));
    }
    private static Tarea CrearTarea(int id,string titulo,PrioridadTarea prioridad = PrioridadTarea.Media)
    {
        return new Tarea(
            id,
            titulo,
            "Descripción de prueba",
            "Equipo de desarrollo",
            prioridad);
    }
}
