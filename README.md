# Sistema de Gestión de Tareas de Desarrollo

Proyecto académico de Programación Avanzada en C# para demostrar especificaciones, control de versiones, revisión colaborativa, pruebas unitarias y automatización con GitHub Actions.

## Alcance de esta primera versión

- Registrar tareas con ID, título, descripción, responsable y prioridad.
- Listar las tareas registradas.
- Cambiar el estado de una tarea.
- Validar campos obligatorios, IDs duplicados y valores permitidos.
- Ejecutar pruebas unitarias con xUnit.
- Automatizar compilación y pruebas mediante GitHub Actions.

> Los datos se almacenan en memoria. Al cerrar la aplicación se pierden; no se utiliza base de datos porque no es un requisito del enunciado.

## Requisitos

- Visual Studio 2026 con el componente de desarrollo de .NET instalado y .NET 10 SDK.
- Acceso a Internet para restaurar los paquetes de pruebas.
- Una cuenta de GitHub.

## Abrir y ejecutar

1. Abre Visual Studio.
2. Selecciona **Abrir un proyecto o una solución** y abre `GestionTareas.sln`.
3. Selecciona `src/GestionTareas` como proyecto de inicio si Visual Studio no lo selecciona automáticamente.
4. Ejecuta con `Ctrl + F5`.

También puedes abrir una terminal en la carpeta raíz y ejecutar:

```powershell
dotnet run --project src/GestionTareas/GestionTareas.csproj
```

Para ejecutar las pruebas:

```powershell
dotnet test tests/GestionTareas.Tests/GestionTareas.Tests.csproj
```

## Documentación

- `docs/especificacion.md`: requisitos y criterios de aceptación.
- `docs/flujo-trabajo.md`: ramas, commits, Pull Requests y revisión.
- `docs/propuesta-solucion.md`: vínculo entre los problemas de la empresa y las herramientas elegidas.
- `docs/indice-informe.md`: estructura sugerida para el informe APA 7.

## Pipeline

El archivo `.github/workflows/ci.yml` se ejecuta al hacer `push` en ramas configuradas y al abrir un Pull Request hacia `main`. Restaura dependencias, compila el proyecto y ejecuta las pruebas. El pipeline no realiza un despliegue porque la práctica no define un entorno de publicación.
