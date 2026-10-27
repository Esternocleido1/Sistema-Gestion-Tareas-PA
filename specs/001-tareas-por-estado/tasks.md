# Tasks: Consultar tareas por estado

**Input**: Design documents from `/specs/001-tareas-por-estado/`

**Prerequisites**: `plan.md`, `spec.md`, `research.md`, `data-model.md`, `quickstart.md`

**Tests**: Automated tests are included because the specification requires verification through tests. Preserve test-first order within each story.

**Organization**: Tasks are grouped by the user stories in `spec.md` to enable independent implementation and verification.

## Phase 1: Setup

**Purpose**: Verify the current test baseline before feature work; no new project or dependency setup is needed.

- [X] T001 Run the existing baseline suite with `dotnet test tests/GestionTareas.Tests/GestionTareas.Tests.csproj` before changes.

---

## Phase 2: Foundational

**Purpose**: Establish prerequisites shared by all stories.

The existing console project, in-memory task model, supported state enum, and xUnit project already provide the required foundation. No additional foundational code or infrastructure task is needed.

---

## Phase 3: User Story 1 - Consultar tareas por estado actual (Priority: P1) 🎯 MVP

**Goal**: Let the user select an existing task state and see only tasks in that state, with their identifying details, or a clear no-results message.

**Independent Test**: Register tasks in `Pendiente`, `EnProgreso` and `Finalizada`; query each state and verify that only exact matches are returned and that an empty result is reported without changing stored tasks.

### Tests for User Story 1

- [X] T002 [US1] Add controller tests in `tests/GestionTareas.Tests/TListaTareaTests.cs` for `ObtenerPorEstado`: assert exact filtering for `Pendiente`, `EnProgreso` and `Finalizada`, assert an empty result for a state with no matches and for an empty list, and assert source task states remain unchanged; extend the existing `CrearTarea` helper to accept an optional `EstadoTarea` and pass it to the existing `Tarea` constructor.

### Implementation for User Story 1

- [X] T003 [US1] Add `ObtenerPorEstado(EstadoTarea estado)` to `src/GestionTareas/Controlador/TListaTarea.cs`, following `ObtenerPorPrioridad`; accept only defined enum values and return a read-only list without mutating tasks. The valid states are exactly `Pendiente`, `EnProgreso` and `Finalizada`.
- [X] T004 [US1] Add menu option `5` after the existing options in `src/GestionTareas/Program.cs` and display matching task identifiers and details, or a clear no-results message, using `ObtenerPorEstado`; preserve existing choices `0` through `4` and their behavior.

**Checkpoint**: The valid-state query works independently and leaves all task data unchanged.

---

## Phase 4: User Story 2 - Gestionar entradas no válidas (Priority: P1)

**Goal**: Reject unknown state input clearly, accept casing variations of existing states, and allow the user to continue without modifying task data.

**Independent Test**: Through the console interaction, enter an invalid state and then a valid state with different casing; verify a helpful error, continued menu use, the correct results, and unchanged stored values.

### Tests for User Story 2

- [X] T005 [US2] Add a process-level console-flow test in `tests/GestionTareas.Tests/ProgramFlowTests.cs`: launch the existing console application with `ProcessStartInfo` using `dotnet run --project src/GestionTareas/GestionTareas.csproj`, set the child working directory to the repository root, redirect standard input/output, and feed scripted menu selections that register a task, change it to `Finalizada`, query `Pendiente` for no matches, select option `5` separately before each invalid input (`0`, `1`, `2` and an unknown name), query with `fInAlIzAdA`, list with option `2` and exit with `0`; assert the no-results message, an invalid-input message and menu recovery for every invalid value, matching query output, and that the final listing still shows `Finalizada`. Use existing .NET APIs only; add no application abstraction or package.

### Implementation for User Story 2

- [X] T006 [US2] Validate input for menu option `5` in `src/GestionTareas/Program.cs` by matching against the names of the defined `EstadoTarea` values without case sensitivity; reject numeric strings before enum conversion, plus unknown and unsupported names, show a comprehensible message, and return to the menu without altering tasks.

**Checkpoint**: Invalid input is handled safely, case variations work, and the user can continue using the application.

---

## Phase 5: User Story 3 - Mantener compatibilidad con el sistema existente (Priority: P2)

**Goal**: Preserve task registration, listing, state changes, and priority filtering.

**Independent Test**: Run the existing automated regression suite and exercise the existing menu operations; confirm their behavior and menu choices are unchanged.

### Verification for User Story 3

- [X] T007 [US3] Extend `tests/GestionTareas.Tests/ProgramFlowTests.cs` with a child-process regression scenario that selects existing menu options `1`, `2`, `3` and `4` to register a task, list it, change its state and filter by priority; assert each operation's expected output. Run `dotnet test tests/GestionTareas.Tests/GestionTareas.Tests.csproj` and confirm the existing controller tests `Registrar_TareaValida_AgregaLaTarea`, `CambiarEstado_IDExistente_ActualizaEstado` and `ObtenerPorPrioridad_SoloDevuelveTareasSolicitadas` also pass. This adds explicit listing/menu coverage rather than treating one controller test as full compatibility proof.

**Checkpoint**: All four prior user operations pass automated controller and console-flow verification.

---

## Phase 6: Polish & Cross-Cutting Concerns

**Purpose**: Complete the end-to-end validation documented for this feature.

- [X] T008 Run the validation scenarios in `specs/001-tareas-por-estado/quickstart.md`, confirm all automated tests pass with `dotnet test tests/GestionTareas.Tests/GestionTareas.Tests.csproj`, and locally verify the build-and-test commands from `.github/workflows/ci.yml` using Release configuration.

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies; the baseline test run must pass or any pre-existing failure must be recorded before feature work.
- **Foundational (Phase 2)**: No new tasks; required project structure and dependencies already exist.
- **User Stories (Phase 3+)**: Depend on the baseline check. Implement in priority order because US1 and US2 both integrate with `src/GestionTareas/Program.cs`.
- **Polish (Phase 6)**: Depends on the three user-story phases.

### User Story Dependencies

- **US1 (P1)**: Starts after the baseline check. It establishes state query and menu entry.
- **US2 (P1)**: Follows US1 because both change the console flow in `src/GestionTareas/Program.cs`; adds invalid-input and case-insensitive behavior.
- **US3 (P2)**: Verifies the existing operations after US1 and US2; it does not add domain features.

### Within Each User Story

- Define and run story-specific tests before implementation wherever applicable.
- In US1, complete T002 before T003 and T004; the menu handler depends on the controller query.
- In US2, complete T005 before T006. The subprocess strategy tests the current executable without a test seam or new dependency.
- Preserve the existing enum values and in-memory task behavior.

### Parallel Opportunities

- No safe parallel implementation tasks are identified: the controller query, menu wiring, and input handling form a dependency chain, and US1/US2 both touch `src/GestionTareas/Program.cs`.
- Test preparation can be performed before implementation within each story, but it does not remove the story dependencies above.

### Per-Story Execution Examples

- **US1**: T002 → T003 → T004; assert matching, empty/no-match results and no mutation.
- **US2**: T005 → T006; script numeric/unknown rejection and mixed-case name acceptance in a child process.
- **US3**: T007 after US1/US2; verify all four existing operations in the console and run the existing controller tests.

---

## Implementation Strategy

### MVP First (User Story 1 Only)

1. Run T001 to establish the current test baseline.
2. Complete T002, then implement T003 and T004.
3. Validate the valid-state and no-results scenarios independently.
4. Review the MVP before continuing to invalid-input handling and compatibility verification.

### Incremental Delivery

1. Complete US1 to provide state filtering and no-results feedback.
2. Complete US2 to handle invalid input and casing variations without data changes.
3. Complete US3 and Phase 6 to verify existing behavior and the full quickstart scenarios.

## Notes

- Every task has an unchecked checkbox, sequential ID, correct story label where required, and a concrete repository path or command with a project path.
- `[P]` is omitted because no tasks can safely run in parallel under the current file dependencies.
- The tasks plan implementation only; it does not modify or create application code or tests at this stage.
