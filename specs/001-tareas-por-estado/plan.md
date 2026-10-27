# Implementation Plan: Consultar tareas por estado

**Branch**: `feature/sdd-filtrar-tareas-por-estado` | **Date**: 2026-10-27 | **Spec**: [spec.md](spec.md)

**Input**: Feature specification from `/specs/001-tareas-por-estado/spec.md`

## Summary

Añadir una consulta de solo lectura por estado a la aplicación de consola. Se reutilizan la colección en memoria de `TListaTarea`, el enum `EstadoTarea` y el menú existente. Los nombres válidos son exactamente `Pendiente`, `EnProgreso` y `Finalizada`, aceptados sin distinguir mayúsculas y minúsculas; valores numéricos, desconocidos y no admitidos se rechazan.

## Technical Context

**Language/Version**: C# on .NET 10 (`TargetFramework` in `src/GestionTareas/GestionTareas.csproj` is `net10.0`)

**Primary Dependencies**: .NET runtime; tests use xUnit and Microsoft.NET.Test.Sdk as declared in `tests/GestionTareas.Tests/GestionTareas.Tests.csproj`; no additional packages are planned

**Storage**: In-memory `List<Tarea>` managed by `TListaTarea`

**Testing**: xUnit in `tests/GestionTareas.Tests`; run with `dotnet test tests/GestionTareas.Tests/GestionTareas.Tests.csproj`

**Target Platform**: Local console application run from Visual Studio or CLI

**Project Type**: Console application

**Performance Goals**: No performance threshold is defined for this feature.

**Constraints**: Preserve the three existing states, current domain rules, console menu and in-memory data; do not add persistence, services, infrastructure or dependencies.

**Scale/Scope**: Existing local task-management application; no dataset-size target is specified.

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

Passes with current scope:
- The feature stays within the console application and current task-management domain.
- It preserves in-memory storage and adds no production deployment or enterprise infrastructure.
- It applies input validation and automated testing without altering existing domain rules.
- It preserves registration, listing, state changes and priority filtering.
- It does not introduce states beyond `Pendiente`, `EnProgreso` and `Finalizada`.

## Project Structure

### Documentation (this feature)

```text
specs/001-tareas-por-estado/
├── plan.md
├── research.md
├── data-model.md
├── quickstart.md
├── contracts/
├── checklists/
├── spec.md
└── tasks.md
```

### Source Code (repository root)

```text
src/
└── GestionTareas/
    ├── Controlador/
    │   └── TListaTarea.cs
    ├── Entidades/
    │   └── Tarea.cs
    ├── Program.cs
    └── GestionTareas.csproj

tests/
└── GestionTareas.Tests/
    ├── TListaTareaTests.cs
    ├── ProgramFlowTests.cs (planned console-process tests)
    └── GestionTareas.Tests.csproj
```

**Structure Decision**: Keep the current console application, entity and in-memory controller. Add the query to `TListaTarea` and the menu interaction to `Program.cs`. Controller behavior is tested in the existing test class. The current top-level console application can be exercised without a production-code seam by launching it as a child process from xUnit with redirected standard input/output; this uses the existing .NET runtime and adds no package or architectural layer.

## Verification Design

- Controller tests cover all three supported states, exact-match filtering, empty/no-match results, and non-mutation of the stored tasks.
- A deterministic child-process test feeds scripted menu input and asserts invalid numeric/unknown input handling, recovery to the menu, case-insensitive state-name handling, and output.
- Compatibility checks cover registration, listing, state change and priority filtering through their existing controller tests and a console-process flow. The current controller test class has no dedicated `ObtenerTodas` listing assertion, so the planned compatibility test must cover listing explicitly.

## Complexity Tracking

No constitution violations or required exceptions identified for this feature.
