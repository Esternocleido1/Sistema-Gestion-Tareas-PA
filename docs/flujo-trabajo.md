# Flujo de trabajo del repositorio

## Flujo elegido
Para el tamaño de este proyecto se utilizará una rama principal `main` y ramas cortas por funcionalidad. Es una forma sencilla de trabajo basada en integración frecuente, cercana a Trunk Based Development, sin crear todas las ramas permanentes de Git Flow.

## Ramas sugeridas
- `main`: versión integrada y comprobada.
- `feature/registro-tareas`: registro y validación de tareas.
- `feature/pruebas-unitarias`: pruebas del controlador.
- `docs/informe-apa7`: documentación e informe.

## Ciclo de trabajo
1. Crear un Issue para describir el trabajo y sus criterios de aceptación.
2. Crear una rama a partir de `main`.
3. Realizar un cambio pequeño y probarlo localmente.
4. Crear commits con mensajes claros, por ejemplo `feat: validar título de tarea`.
5. Enviar la rama a GitHub y abrir un Pull Request hacia `main`.
6. Revisar el cambio, resolver observaciones y comprobar el estado del pipeline.
7. Integrar el Pull Request cuando la revisión y las comprobaciones sean satisfactorias.
8. Cerrar el Issue relacionado y actualizar el tablero del proyecto.

## Reglas recomendadas
- No subir carpetas `bin` ni `obj`.
- Evitar commits que mezclen cambios sin relación.
- No incorporar secretos, contraseñas o tokens al repositorio.
- No afirmar que hubo Code Review o que las pruebas pasaron sin evidencia verificable.

## Evidencias para el informe
Capturar la página del repositorio, ramas, historial de commits, Issue, tablero, Pull Request con revisión y pestaña Actions con el pipeline completado.
