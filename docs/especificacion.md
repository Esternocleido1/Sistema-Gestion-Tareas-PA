# Especificación del sistema

## 1. Nombre
Sistema de Gestión de Tareas de Desarrollo.

## 2. Propósito
Demostrar un flujo profesional y verificable de desarrollo en C# que reduzca la falta de organización y ayude a prevenir errores mediante especificaciones, control de versiones, revisión de código y pruebas automatizadas.

## 3. Alcance
La primera versión será una aplicación de consola. Permitirá registrar tareas, consultar tareas y actualizar sus estados. La información se mantendrá en memoria durante la ejecución. No incluye usuarios autenticados, base de datos, notificaciones ni despliegue.

## 4. Requisitos funcionales
- RF-01: El sistema permitirá registrar una tarea con ID, título, descripción, responsable y prioridad.
- RF-02: El sistema rechazará IDs menores o iguales a cero.
- RF-03: El sistema rechazará títulos vacíos o compuestos solo por espacios.
- RF-04: El sistema rechazará responsables vacíos o compuestos solo por espacios.
- RF-05: El sistema impedirá registrar dos tareas con el mismo ID.
- RF-06: El sistema permitirá listar todas las tareas registradas.
- RF-07: El sistema permitirá cambiar el estado de una tarea existente a Pendiente, EnProgreso o Finalizada.
- RF-08: Si no existe el ID indicado al cambiar estado, el sistema informará que no encontró la tarea.
- RF-09: La prioridad será Baja, Media o Alta.

## 5. Requisitos no funcionales
- RNF-01: El proyecto se desarrollará en C# sobre .NET 10.
- RNF-02: La lógica de gestión estará separada de la interfaz de consola.
- RNF-03: Las validaciones principales tendrán pruebas unitarias automatizadas.
- RNF-04: GitHub Actions compilará el proyecto y ejecutará las pruebas en cada evento configurado.
- RNF-05: Los cambios destinados a `main` se propondrán mediante Pull Request y serán revisados por otro integrante cuando el tamaño del equipo lo permita.

## 6. Criterios de aceptación
- CA-01: Una tarea con datos válidos se registra y aparece en el listado.
- CA-02: Un título vacío es rechazado.
- CA-03: Un ID repetido es rechazado.
- CA-04: Una tarea existente puede cambiar a estado Finalizada.
- CA-05: Intentar cambiar el estado de una tarea inexistente devuelve un resultado negativo.
- CA-06: El comando `dotnet test` finaliza correctamente.
- CA-07: El pipeline muestra compilación y pruebas exitosas en GitHub Actions.

## 7. Supuestos y restricciones
- El proyecto es una simulación académica y no un producto listo para producción.
- Los datos se pierden al cerrar el programa.
- En una entrega de una sola persona, la revisión por pares puede demostrarse con un compañero o explicarse como procedimiento propuesto; no se deben inventar aprobaciones.
