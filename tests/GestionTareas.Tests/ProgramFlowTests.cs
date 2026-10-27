using System.Diagnostics;
using Xunit;

namespace GestionTareas.Tests;

public class ProgramFlowTests
{
    [Fact]
    public async Task Menu_FiltroEstado_RechazaEntradasInvalidasYAceptaNombreCaseInsensitive()
    {
        string output = await RunApplicationAsync(
            "1", "1", "Tarea de prueba", "Descripción", "Equipo", "Media",
            "3", "1", "Finalizada",
            "5", "Pendiente",
            "5", "1",
            "5", "2",
            "5", "Desconocido",
            "5", "fINalIzAdA",
            "2", "0");

        Assert.Equal(3, CountOccurrences(output, "Estado no v"));
        Assert.Contains("No hay tareas con estado Pendiente.", output);
        const string finalizadaTaskRow = "1 | Tarea de prueba | Equipo | Media | Finalizada";
        Assert.Equal(2, CountOccurrences(output, finalizadaTaskRow));
        Assert.True(
            output.IndexOf(finalizadaTaskRow, StringComparison.Ordinal)
                > output.IndexOf("No hay tareas con estado Pendiente.", StringComparison.Ordinal),
            output);
        Assert.True(CountOccurrences(output, "Seleccione una opci") >= 9);
        Assert.Contains("Finalizada", output);
    }

    [Fact]
    public async Task Menu_OperacionesExistentes_ContinuanDisponibles()
    {
        string output = await RunApplicationAsync(
            "1", "10", "Tarea de compatibilidad", "Descripción", "Equipo", "Alta",
            "2",
            "3", "10", "Finalizada",
            "4", "Alta",
            "0");

        Assert.Contains("Tarea registrada correctamente.", output);
        Assert.Contains("10 | Tarea de compatibilidad | Equipo | Alta | Pendiente", output);
        Assert.Contains("Estado actualizado correctamente.", output);
        Assert.Contains("10 | Tarea de compatibilidad | Equipo | Alta | Finalizada", output);
    }

    private static async Task<string> RunApplicationAsync(params string[] inputLines)
    {
        string repositoryRoot = Path.GetFullPath(
            Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", ".."));
        ProcessStartInfo startInfo = new("dotnet")
        {
            WorkingDirectory = repositoryRoot,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        startInfo.ArgumentList.Add("run");
        startInfo.ArgumentList.Add("--project");
        startInfo.ArgumentList.Add("src/GestionTareas/GestionTareas.csproj");

        using Process process = new() { StartInfo = startInfo };
        Assert.True(process.Start(), "No se pudo iniciar la aplicación de consola.");

        Task<string> standardOutput = process.StandardOutput.ReadToEndAsync();
        Task<string> standardError = process.StandardError.ReadToEndAsync();
        await process.StandardInput.WriteLineAsync(string.Join(Environment.NewLine, inputLines));
        process.StandardInput.Close();

        using CancellationTokenSource timeout = new(TimeSpan.FromSeconds(30));
        try
        {
            await process.WaitForExitAsync(timeout.Token);
        }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            throw new TimeoutException("La aplicación de consola no terminó dentro del límite de 30 segundos.");
        }

        string output = await standardOutput;
        string error = await standardError;
        Assert.Equal(0, process.ExitCode);
        return output + Environment.NewLine + error;
    }

    private static int CountOccurrences(string text, string value)
    {
        return (text.Length - text.Replace(value, string.Empty, StringComparison.Ordinal).Length)
            / value.Length;
    }
}
