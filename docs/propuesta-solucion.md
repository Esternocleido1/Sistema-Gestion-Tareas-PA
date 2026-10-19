# Propuesta de solución para la empresa

## Problema y medida propuesta

| Problema de la empresa | Medida propuesta | Evidencia esperada |
|---|---|---|
| Pérdida de versiones | Git con commits, ramas y repositorio remoto en GitHub | Historial de commits y ramas |
| Desorganización del equipo | Issues, Projects (Kanban), responsables y Milestones | Issue, tablero y hito |
| Errores en producción | Code Review, pruebas unitarias y pipeline de CI | Pull Request revisado y resultado de Actions |
| Falta de documentación | Especificaciones, README y documentos del flujo | Archivos de `docs` y README |
| Falta de automatización y apoyo moderno | GitHub Actions y evaluación responsable de GitHub Copilot/Spec Kit | Pipeline exitoso y ejemplos documentados |

## Modelo de desarrollo propuesto
1. Definir los requisitos y los criterios de aceptación antes de programar.
2. Dividir el trabajo en Issues pequeños y asignar responsables.
3. Desarrollar cada tarea en una rama corta.
4. Escribir pruebas para los comportamientos importantes.
5. Abrir un Pull Request y solicitar revisión de código.
6. Ejecutar automáticamente restauración, compilación y pruebas mediante GitHub Actions.
7. Integrar los cambios únicamente después de revisar el código y el resultado de las comprobaciones.
8. Mantener la documentación actualizada y revisar periódicamente las tareas pendientes.

## Uso responsable de IA
GitHub Copilot puede apoyar la elaboración de código, explicaciones o pruebas. Las sugerencias deben revisarse y comprobarse con pruebas; no se deben introducir datos confidenciales en prompts. Spec Kit se evaluará como herramienta para estructurar el trabajo a partir de especificaciones, plan y tareas.

## Limitaciones
La aplicación de demostración almacena datos en memoria y no realiza despliegue real. La propuesta empresarial requeriría adaptar permisos, protección de ramas, pruebas, estrategia de releases y controles de seguridad al tamaño y criticidad de cada organización.
