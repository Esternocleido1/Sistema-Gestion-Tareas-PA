# Feature Specification: Consultar tareas por estado

**Feature Branch**: `feature/sdd-filtrar-tareas-por-estado`

**Created**: 2026-10-27

**Status**: Draft

**Input**: User description: "En el proyecto existente Sistema de Gestión de Tareas de Desarrollo, quiero incorporar una funcionalidad que permita al usuario consultar las tareas filtrándolas por su estado actual. ..."

## User Scenarios & Testing *(mandatory)*

### User Story 1 - Consultar tareas por estado actual (Priority: P1)

Un integrante del equipo de desarrollo necesita consultar rápidamente qué tareas están pendientes, en progreso o finalizadas, utilizando los estados que admite el sistema actual. La consulta debe filtrar la lista sin alterar las tareas ni sus estados.

**Why this priority**: Esta consulta permite localizar tareas por su estado dentro del flujo cotidiano de gestión.

**Independent Test**: Con tareas registradas en los tres estados admitidos, consultar cada estado y verificar que se muestran solo sus coincidencias y que las tareas conservan sus datos.

**Acceptance Scenarios**:

1. **Given** varias tareas registradas con diferentes estados, **When** el usuario consulta un estado admitido, **Then** se muestran únicamente las tareas coincidentes, con su información identificativa.
2. **Given** que ninguna tarea tiene el estado consultado, incluida una lista vacía, **When** el usuario realiza la consulta, **Then** el sistema muestra un mensaje claro de que no hay tareas coincidentes.
3. **Given** tareas registradas, **When** el usuario consulta por estado, **Then** el sistema no modifica la lista ni el estado almacenado de ninguna tarea.

---

### User Story 2 - Gestionar entradas de estado (Priority: P1)

El usuario puede escribir el nombre de un estado admitido sin importar el uso de mayúsculas y minúsculas. Si introduce un valor desconocido o no admitido, el sistema debe explicar el error y permitirle continuar utilizando la aplicación.

**Why this priority**: La validación clara evita que una entrada incorrecta interrumpa el uso de la aplicación o afecte a los datos.

**Independent Test**: En la aplicación, introducir un nombre válido con variación de mayúsculas, luego valores numéricos y desconocidos; verificar resultados para el nombre válido, mensajes para las entradas inválidas y continuidad de uso.

**Acceptance Scenarios**:

1. **Given** uno de los nombres `Pendiente`, `EnProgreso` o `Finalizada` escrito con cualquier combinación de mayúsculas y minúsculas, **When** el usuario lo introduce para consultar, **Then** el sistema lo trata como el estado correspondiente sin modificar el valor almacenado.
2. **Given** una entrada numérica como `0`, `1` o `2`, o un valor desconocido o no admitido, **When** el usuario intenta consultar, **Then** el sistema muestra un mensaje comprensible, no ejecuta la consulta con esa entrada y vuelve al menú para permitir continuar.
3. **Given** tareas previamente registradas, **When** el usuario introduce una entrada inválida, **Then** las tareas y sus estados permanecen intactos.

---

### User Story 3 - Mantener compatibilidad con el sistema existente (Priority: P2)

La nueva consulta se integra en la aplicación actual y conserva las operaciones existentes de registro, listado, cambio de estado y filtrado por prioridad.

**Why this priority**: La incorporación debe mantener el comportamiento que los usuarios ya utilizan.

**Independent Test**: Ejecutar pruebas automatizadas de las operaciones existentes y un flujo de consola que las ejercite después de integrar la consulta.

**Acceptance Scenarios**:

1. **Given** un usuario que utiliza la aplicación, **When** registra, lista, cambia el estado y filtra por prioridad, **Then** cada operación conserva su comportamiento anterior.
2. **Given** tareas registradas, **When** el usuario realiza una consulta por estado, **Then** no cambian el formato de los datos existentes ni las reglas de las operaciones previas.

---

### Edge Cases

- Los nombres válidos con diferencias de mayúsculas y minúsculas se reconocen como el mismo estado.
- Las entradas numéricas, desconocidas o no admitidas se rechazan con un mensaje y el flujo vuelve al menú.
- Una lista vacía y una consulta válida sin coincidencias muestran el mensaje de no resultados.
- Una consulta no modifica datos ni estados de las tareas.

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: El sistema MUST proporcionar una opción para consultar tareas por estado en el menú principal.
- **FR-002**: Para esta consulta, el sistema MUST aceptar únicamente los nombres `Pendiente`, `EnProgreso` y `Finalizada`, sin distinguir mayúsculas y minúsculas; MUST rechazar valores numéricos, desconocidos o no admitidos y MUST NOT añadir ni renombrar estados.
- **FR-003**: El sistema MUST mostrar únicamente las tareas cuyo estado coincida con el estado seleccionado, conservando su información identificativa.
- **FR-004**: Si la lista está vacía o no existen tareas con el estado seleccionado, el sistema MUST mostrar un mensaje claro de que no hay coincidencias.
- **FR-005**: Ante una entrada inválida, el sistema MUST mostrar un mensaje comprensible, no modificar los datos y permitir continuar usando la aplicación.
- **FR-006**: El sistema MUST mantener los valores de estado almacenados sin modificarlos durante la consulta.
- **FR-007**: El sistema MUST mantener las operaciones existentes de registro, listado, cambio de estado y filtrado por prioridad.

### Key Entities *(include if feature involves data)*

- **Tarea**: Representa una unidad de trabajo con identificación, título, descripción, responsable, prioridad y estado actual.
- **Estado de tarea**: Estado existente de una tarea. Los únicos valores admitidos son `Pendiente`, `EnProgreso` y `Finalizada`; la consulta acepta sus nombres sin distinguir mayúsculas y minúsculas, pero no valores numéricos.

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: Para cualquier estado admitido consultado, los resultados contienen todas y solo las tareas que tienen ese estado.
- **SC-002**: Una lista vacía o una consulta sin coincidencias produce un mensaje claro de que no hay tareas coincidentes.
- **SC-003**: Los nombres admitidos se reconocen aunque varíe su capitalización; entradas numéricas, desconocidas o no admitidas se rechazan y no alteran las tareas.
- **SC-004**: Registro, listado, cambio de estado y filtrado por prioridad conservan su comportamiento previo.
- **SC-005**: Las pruebas automatizadas verifican los resultados del filtro, la lista vacía/sin coincidencias, los nombres con distinta capitalización, las entradas inválidas y la compatibilidad con las operaciones existentes.

## Assumptions

- Los estados válidos son exactamente `Pendiente`, `EnProgreso` y `Finalizada`, tal como admite el sistema actual.
- La entrada válida para esta consulta es el nombre del estado; los valores numéricos del enum no son nombres admitidos.
- La comparación no distingue mayúsculas de minúsculas y no modifica los valores almacenados.
- La consulta es de solo lectura y su alcance se limita a la aplicación existente.
