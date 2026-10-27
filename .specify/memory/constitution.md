<!--
Sync Impact Report
- Version change: initial governance template -> 1.0.0
- Modified principles: scope and domain, input validation, automated testing,
  Git traceability and PR review, maintainability
- Added sections: project requirements; development workflow
- Removed sections: none
- Follow-up for approval: confirm ratification date 2026-10-27; original adoption date is not recorded in the available history.
-->

# Constitución del Sistema de Gestión de Tareas

## Core Principles

### I. Alcance y claridad del dominio
Todo cambio del sistema debe mantener el alcance definido para una aplicación de consola en C# para la gestión de tareas académica: registro, listado, actualización de estado, validación de campos y control básico de errores. La solución debe centrarse en la funcionalidad del dominio y evitar requisitos no contemplados en la especificación del proyecto.

Rationale: este principio evita la deriva funcional y mantiene la entrega enfocada en las historias de usuario definidas.

### II. Validación explícita de datos
Toda tarea debe validar de forma obligatoria su identificación, título, descripción, responsable y prioridad antes de aceptarse en el sistema. IDs duplicados, valores no permitidos y campos vacíos deben rechazarse con mensajes claros y consistentes.

Rationale: la integridad de los datos es una condición necesaria para que el sistema sea confiable y para que las pruebas unitarias reflejen comportamientos reales.

### III. Pruebas automatizadas
Cada cambio funcional debe cubrirse con pruebas unitarias antes o en paralelo con la implementación, y la suite debe ejecutarse en cada validación del proyecto. El repositorio debe mantener un conjunto de pruebas que verifique el comportamiento principal del gestor de tareas.

Rationale: las pruebas automatizadas hacen visible la regresión temprana y aseguran que la lógica de negocio siga siendo correcta bajo cambios futuros.

### IV. Trazabilidad con Git y revisión
Todo cambio debe registrarse en ramas, commits descriptivos y Pull Requests con revisión explícita antes de fusionarse a la rama principal. La evidencia del trabajo debe permitir a cualquier miembro del equipo comprender qué se modificó y por qué.

Rationale: la trazabilidad ayuda a la colaboración, reduce errores de integración y refleja el proceso académico de control de versiones.

### V. Simplicidad y mantenibilidad
La implementación debe priorizar soluciones claras, legibles y mantenibles sobre complejidad innecesaria. Se debe evitar duplicación de lógica, acoplamiento artificial y patrones que aumenten la dificultad de comprensión del sistema.

Rationale: un proyecto académico con alcance limitado debe mantenerse fácil de entender y ampliar sin introducir carga técnica innecesaria.

## Requisitos de proyecto

El proyecto actual es una aplicación de consola desarrollada en C# y .NET, con alcance académico y ejecución local. Debe permitir la compilación y la ejecución desde Visual Studio o desde la línea de comandos, sin requerir despliegue en producción ni infraestructura empresarial adicional.

La persistencia debe mantenerse en memoria durante esta versión, y cualquier decisión de almacenamiento persistente debe justificarse explícitamente como extensión del alcance. La documentación del proyecto debe mantenerse sincronizada con la implementación y con los requisitos de la práctica. El repositorio debe incluir, como mínimo, la especificación, la propuesta de solución y la guía de flujo de trabajo para que el contexto del proyecto sea auditable.

## Flujo de trabajo de desarrollo

Cada tarea debe desarrollarse en una rama separada, con commits pequeños y mensajes claros. Los cambios de funcionalidad deben pasar por revisión antes de integrarse en la rama principal y deben cumplir con la validación automatizada de compilación y pruebas.

El proyecto debe ejecutar la verificación continua en GitHub Actions para compilar y probar el código, y la configuración de CI debe reflejar exactamente el comportamiento requerido por la práctica. No se deben introducir despliegues, entornos de producción ni infraestructura empresarial no contemplados en el alcance actual.

## Governance

Esta Constitución define la fuente principal de reglas del proyecto y prevalece sobre prácticas informales o decisiones no documentadas. Cualquier cambio en la estructura del sistema, en la forma de trabajo o en los principios del repositorio debe documentarse y revisarse antes de su aprobación.

Los cambios se realizan mediante Pull Request con explicación de la necesidad del cambio, el impacto esperado y la evidencia que respalda la decisión. Si el ajuste modifica principios, requerimientos o políticas de cumplimiento, debe incluirse una nota de impacto en la documentación del proyecto.

La fecha de adopción original no consta en el historial disponible; esta versión se ratifica el 2026-10-27.

La versionado sigue la regla semántica:
- MAJOR: eliminación o redefinición incompatible de principios o políticas de gobernanza.
- MINOR: incorporación de un nuevo principio o una expansión significativa de una sección existente.
- PATCH: correcciones de redacción, aclaraciones y ajustes no semánticos.

La revisión de cumplimiento ocurre en cada Pull Request y en cada validación automatizada del repositorio. Se verifica que los cambios respeten el alcance del proyecto, las reglas de validación, la evidencia de pruebas y la trazabilidad con Git.

**Version**: 1.0.0 | **Ratified**: 2026-10-27 | **Last Amended**: 2026-10-27
