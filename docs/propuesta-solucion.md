# Propuesta de solución tecnológica para la empresa



## 1. Introducción

La empresa descrita en el proyecto presenta problemas relacionados con el control de versiones, la organización del equipo, los errores en producción, la documentación y la falta de automatización. Se propone un modelo de desarrollo que combine Git, GitHub, pruebas automatizadas, integración continua y herramientas de apoyo a la programación.



La propuesta se ejemplifica mediante el Sistema de Gestión de Tareas de Desarrollo, una aplicación de consola realizada en C#.



## 2. Problemas identificados y soluciones propuestas



### 2.1. Pérdida de versiones del código

Se utilizará Git para registrar los cambios mediante commits y conservar el historial del proyecto. GitHub alojará el repositorio remoto. Las ramas permitirán desarrollar funcionalidades por separado y los Pull Requests facilitarán revisar los cambios antes de integrarlos en `main`.



### 2.2. Falta de organización del equipo

Se utilizarán GitHub Issues para registrar tareas y errores, GitHub Projects para visualizar el avance en un tablero Kanban y Milestones para agrupar tareas relacionadas con una entrega. Cada tarea deberá tener una descripción clara y criterios de finalización.



### 2.3. Errores frecuentes en producción

Se utilizarán pruebas automatizadas y revisión de código antes de integrar cambios. GitHub Actions ejecutará la compilación y las pruebas configuradas. Estas medidas ayudan a detectar defectos, pero no garantizan por sí solas que el software esté libre de errores. En una empresa real también se deberían considerar pruebas de integración, seguridad y aceptación según las necesidades del sistema.



### 2.4. Falta de documentación técnica

Se mantendrán un README con instrucciones de ejecución, un documento de especificaciones, la descripción del flujo de trabajo y la propuesta de solución. La documentación deberá actualizarse cuando cambien los requisitos o el comportamiento del sistema.



### 2.5. Falta de herramientas modernas y automatización

Se propone utilizar GitHub Actions para automatizar compilación y pruebas, GitHub Copilot como asistente de programación bajo revisión humana y Spec Driven Development para definir requisitos antes de implementar funcionalidades. GitHub Spec Kit se evaluará como herramienta de apoyo para organizar este enfoque, considerando el tiempo de aprendizaje y las necesidades del equipo.



## 3. Flujo de trabajo propuesto



1\. Registrar la necesidad mediante un Issue.

2\. Definir la especificación y sus criterios de aceptación.

3\. Crear una rama para desarrollar la funcionalidad.

4\. Implementar el código y ejecutar las pruebas.

5\. Subir los cambios y abrir un Pull Request.

6\. Revisar las modificaciones y comprobar el resultado de GitHub Actions.

7\. Corregir los problemas identificados y repetir las verificaciones.

8\. Integrar los cambios aprobados en `main`.

9\. Actualizar la documentación y el tablero de seguimiento.



## 4. Aplicación práctica en el proyecto académico

La propuesta se demuestra mediante el Sistema de Gestión de Tareas de Desarrollo. Se creó un repositorio en GitHub, se trabajó en la rama `feature/filtrar-tareas-prioridad`, se incorporó el filtrado de tareas por prioridad y se añadió una prueba unitaria. Los cambios se integraron mediante un Pull Request que mostró comprobaciones automáticas satisfactorias y ausencia de conflictos.



También se creó el Issue #2 para la documentación, se incorporó al tablero Kanban `Gestión del Proyecto - Programación Avanzada` y se asoció al Milestone `Entrega del proyecto - Programación Avanzada`.



Esta práctica demuestra una parte del modelo propuesto; no significa que la solución se haya implantado en una empresa real.



## 5. Etapas de implementación



### Etapa 1. Organización inicial

Crear el repositorio, acordar las convenciones de trabajo, documentar los requisitos y preparar el tablero de tareas.



### Etapa 2. Desarrollo controlado

Implementar funcionalidades mediante ramas, commits descriptivos, criterios de aceptación y pruebas automatizadas.



### Etapa 3. Integración continua

Configurar GitHub Actions para compilar el proyecto y ejecutar las pruebas al subir cambios o abrir Pull Requests.



### Etapa 4. Mejora de la calidad

Fortalecer la revisión de código, aplicar gradualmente prácticas de desarrollo guiado por pruebas y ampliar las verificaciones de acuerdo con los riesgos del sistema.



### Etapa 5. Asistencia mediante inteligencia artificial

Evaluar GitHub Copilot para apoyar tareas de programación y generación de pruebas. Las sugerencias deberán ser revisadas por una persona y se evitará introducir secretos o información confidencial en instrucciones no autorizadas.



## 6. Indicadores de seguimiento

Se recomienda revisar el porcentaje de ejecuciones exitosas del pipeline, el número de pruebas automatizadas, los Pull Requests pendientes de revisión, el tiempo de resolución de Issues y la actualización de la documentación. Los valores iniciales deberán obtenerse de mediciones reales; no se asignarán resultados numéricos sin datos.



## 7. Riesgos y medidas de prevención



\- Las pruebas pueden no detectar todos los defectos. Se deberán revisar sus resultados y ampliar la cobertura según los riesgos.

\- Las sugerencias de inteligencia artificial pueden ser incorrectas o inseguras. El código generado deberá revisarse y probarse.

\- Un flujo de trabajo demasiado complejo puede ralentizar a un equipo pequeño. Se recomienda comenzar con ramas cortas y reglas sencillas.

\- La automatización de compilación y pruebas no equivale a un despliegue seguro en producción. Un despliegue real requeriría configuración adicional, controles de acceso, gestión de secretos y pruebas apropiadas.

\- La documentación desactualizada puede provocar errores. Deberá revisarse cuando cambien los requisitos o el comportamiento del sistema.



## 8. Conclusión

La propuesta combina control de versiones, colaboración organizada, especificaciones, pruebas y automatización para reducir riesgos durante el desarrollo de software. El proyecto académico demuestra parte de este modelo mediante un repositorio funcional, un flujo de integración verificable y herramientas de gestión. Una implantación empresarial tendría que adaptarse al tamaño del equipo, al producto y a sus requisitos de seguridad y operación.

