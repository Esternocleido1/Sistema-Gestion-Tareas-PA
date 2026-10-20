# Especificación del Sistema de Gestión de Tareas



## 1. Propósito

Desarrollar una aplicación de consola en C# que permita registrar, consultar y administrar tareas de un equipo de desarrollo de software. El sistema se utiliza como proyecto práctico para demostrar control de versiones, pruebas automatizadas y colaboración mediante GitHub.



## 2. Alcance

La versión inicial permite registrar tareas, consultar las tareas existentes, cambiar el estado de una tarea y filtrar tareas por prioridad. Los datos se mantienen en memoria durante la ejecución; esta versión no contempla persistencia en una base de datos.



## 3. Usuarios previstos

El sistema está orientado a integrantes de un equipo de desarrollo que necesitan realizar pruebas básicas de gestión de tareas. No incluye autenticación ni permisos por usuario.



## 4. Datos de una tarea

Cada tarea contiene los siguientes datos:

- Identificador: número que distingue la tarea.

- Título: nombre breve de la tarea.

- Descripción: detalle del trabajo que debe realizarse.

- Responsable: persona encargada de la tarea.

- Prioridad: nivel de importancia de la tarea.

- Estado: situación actual de la tarea.



## 5. Requisitos funcionales


### RF-01. Registrar tareas

El sistema debe permitir registrar una tarea con sus datos correspondientes y confirmar cuando el registro sea válido.



### RF-02. Validar registros

El sistema debe rechazar un título vacío y un identificador duplicado, de acuerdo con las validaciones implementadas en el controlador.



### RF-03. Consultar tareas

El sistema debe mostrar las tareas registradas con su identificador, título, responsable, prioridad y estado.



### RF-04. Cambiar el estado

El sistema debe permitir cambiar el estado de una tarea existente e informar cuando el identificador no corresponda a ninguna tarea.



### RF-05. Filtrar por prioridad

El sistema debe permitir seleccionar un nivel de prioridad y mostrar únicamente las tareas que coincidan con él.



### RF-06. Validar la prioridad del filtro

Si el usuario introduce una prioridad no válida, el sistema debe mostrar un mensaje de validación en lugar de realizar el filtrado.



## 6. Requisitos no funcionales

- El código debe estar organizado en clases con responsabilidades diferenciadas.

- La lógica de gestión de tareas debe poder comprobarse mediante pruebas unitarias.

- El proyecto debe mantenerse bajo control de versiones con Git.

- Los cambios deben poder revisarse mediante Pull Requests.

- GitHub Actions debe automatizar la compilación y la ejecución de las pruebas configuradas.

- La documentación debe permitir comprender cómo instalar, ejecutar y probar el sistema.



## 7. Criterios de aceptación

- CA-01: se registra correctamente una tarea con datos válidos.

- CA-02: se rechaza un registro con título vacío.

- CA-03: se rechaza un identificador duplicado.

- CA-04: se muestran las tareas registradas.

- CA-05: se puede modificar el estado de una tarea existente.

- CA-06: una tarea inexistente no se modifica.

- CA-07: al filtrar por prioridad Alta, solo se muestran tareas con prioridad Alta.

- CA-08: una prioridad no válida se rechaza con un mensaje claro.

- CA-09: las pruebas automatizadas terminan correctamente y el pipeline permite comprobar el resultado.



## 8. Restricciones y limitaciones

- Los datos se almacenan únicamente en memoria y se pierden al cerrar la aplicación.

- La aplicación inicial utiliza una interfaz de consola.

- No se incluye conexión a una base de datos.

- El programa es una aplicación académica de demostración, no una plataforma empresarial desplegada en producción.



## 9. Verificación

Los requisitos deben comprobarse mediante ejecución manual del programa y pruebas unitarias. La compilación y las pruebas configuradas se ejecutan también en el pipeline de GitHub Actions.



## 10. Evolución de las especificaciones

Para futuras funcionalidades, primero se definirán el requisito y sus criterios de aceptación; después se implementará la solución, se ejecutarán las pruebas y se revisarán los cambios mediante un Pull Request.
