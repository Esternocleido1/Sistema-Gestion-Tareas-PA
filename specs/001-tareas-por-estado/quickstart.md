# Quickstart: validar la consulta de tareas por estado

## Prerrequisitos

- .NET SDK compatible con `net10.0`, según `src/GestionTareas/GestionTareas.csproj`.
- Repositorio local con la aplicación de consola y el proyecto de pruebas xUnit existentes.

## Comandos

### Ejecutar las pruebas automatizadas

```powershell
dotnet test tests/GestionTareas.Tests/GestionTareas.Tests.csproj
```

### Ejecutar la aplicación de consola

```powershell
dotnet run --project src/GestionTareas/GestionTareas.csproj
```

## Escenarios de validación

1. Registrar varias tareas y utilizar la operación existente de cambio de estado para asignarles `Pendiente`, `EnProgreso` y `Finalizada`; consultar por cada nombre admitido.
   - Resultado esperado: se muestran solo las tareas con el estado consultado y su información identificativa.

2. Consultar un estado válido cuando no hay tareas registradas o ninguna coincide.
   - Resultado esperado: se muestra un mensaje claro de que no hay tareas coincidentes; la lista y los estados permanecen sin cambios.
   - Prueba automatizada relacionada: los casos de coincidencias vacías y sin coincidencias de `TListaTareaTests`.

3. Introducir nombres de estado con distintas mayúsculas/minúsculas, por ejemplo `fInAlIzAdA`.
   - Resultado esperado: se reconoce el nombre como `Finalizada` sin alterar el valor almacenado.

4. Introducir `0`, `1`, `2` y un nombre desconocido en consultas separadas; después de cada error, continuar desde el menú y, al final, listar las tareas.
   - Resultado esperado: cada entrada se rechaza con un mensaje comprensible, no modifica datos y devuelve el flujo al menú; el listado final conserva los estados previos.
   - Prueba automatizada relacionada: escenario de consola como proceso hijo en `tests/GestionTareas.Tests/ProgramFlowTests.cs`, con entrada y salida estándar redirigidas.

5. Recorrer las operaciones existentes: registrar, listar, cambiar el estado y filtrar por prioridad.
   - Resultado esperado: las cuatro operaciones siguen disponibles y muestran los resultados esperados.
   - Pruebas automatizadas relacionadas: pruebas existentes de `TListaTareaTests` y flujo de consola de compatibilidad en `ProgramFlowTests.cs`.

## Criterios de aprobación

- La consulta devuelve exactamente las coincidencias, sin alterar las tareas.
- La lista vacía y la ausencia de coincidencias producen el mensaje de no resultados.
- Solo se aceptan los nombres actuales, ignorando capitalización; números y valores inválidos se rechazan.
- Las operaciones existentes conservan su comportamiento.
- La suite automatizada pasa con `dotnet test tests/GestionTareas.Tests/GestionTareas.Tests.csproj`.
