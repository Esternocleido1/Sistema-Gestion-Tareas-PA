# Flujo de trabajo utilizado

## 1. Organización del repositorio
El proyecto Sistema de Gestión de Tareas de Desarrollo se encuentra alojado en GitHub. La rama `main` contiene la versión integrada del código. Los archivos se organizan en las carpetas `src`, `tests` y `docs`, además de la configuración de automatización en `.github/workflows`.

## 2. Control de versiones con Git
Se utilizó Git para registrar los cambios del proyecto mediante commits. Los cambios se preparan con `git add` y se registran con `git commit`, manteniendo un historial de las modificaciones realizadas.

## 3. Desarrollo mediante ramas
Para implementar el filtro por prioridad se creó la rama `feature/filtrar-tareas-prioridad`, separada de la rama principal. En ella se modificó el controlador de tareas, se añadió una opción al menú de consola y se incorporó una prueba unitaria.

## 4. Pull Request y revisión de cambios
Se abrió el Pull Request #1, titulado `Agregar filtro de tareas por prioridad`, para comparar la rama de funcionalidad con `main`. Se revisaron los archivos modificados y se comprobó el resultado de las verificaciones automáticas antes de fusionar los cambios.

## 5. Integración continua con GitHub Actions
El repositorio cuenta con un flujo de trabajo definido en `.github/workflows/ci.yml`. El pipeline ejecuta comprobaciones automáticas del proyecto, incluyendo compilación y pruebas. En el Pull Request #1, GitHub mostró que todas las comprobaciones habían pasado y que no existían conflictos con la rama base.

## 6. Gestión del trabajo
Se creó el Issue #2 para organizar la documentación y las evidencias del proyecto. El Issue se incorporó al tablero Kanban `Gestión del Proyecto - Programación Avanzada` y se asoció al Milestone `Entrega del proyecto - Programación Avanzada`.

## 7. Conclusión
El flujo de trabajo permitió separar el desarrollo de una funcionalidad de la rama principal, comprobar los cambios mediante pruebas automatizadas y fusionarlos utilizando un Pull Request. La gestión con Issues, Projects y Milestones facilita organizar y dar seguimiento a las tareas pendientes.