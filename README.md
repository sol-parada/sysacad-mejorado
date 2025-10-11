# 🎓 SysAcad Mejorado - Sistema Académico UTN

Sistema académico moderno desarrollado en C# con ASP.NET Core Web API, implementando una **arquitectura empresarial en capas** que mejora el sistema actual de la UTN FRSR.

## 👥 Equipo de Desarrollo
- **Sol Parada** - Desarrolladora Principal
- **Asistente IA** - Soporte en desarrollo

## 🏗️ Arquitectura del Sistema

El proyecto sigue una **arquitectura profesional en capas** que separa responsabilidades:

```
Capa de Presentación (Controllers/)
├── AlumnosController.cs
├── UniversidadesController.cs
├── FacultadesController.cs
├── AutoridadesController.cs
└── MateriasController.cs

Capa de Lógica de Negocio (Services/)
├── AlumnoService.cs
├── UniversidadService.cs
├── FacultadService.cs
├── AutoridadService.cs
└── MateriaService.cs

Capa de Dominio (Models/)
├── Alumno.cs
├── Universidad.cs
├── Facultad.cs
├── Autoridad.cs
├── Materia.cs
└── 11 clases más del diagrama UML
```

## 🚀 Características Implementadas

### ✅ **Arquitectura Profesional**
- Separación clara entre **Controllers** y **Services**
- **Validaciones de negocio** centralizadas en Services
- Manejo consistente de errores
- Código mantenible y escalable

### ✅ **Entidades Principales con Validaciones**
- **Alumno** - Gestión completa con validaciones de legajo único y edad mínima
- **Universidad** - CRUD con validación de siglas únicas
- **Facultad** - Gestión con validaciones de ciudad, email y contactos
- **Autoridad** - Administración con validaciones de nombre y cargo
- **Materia** - Gestión académica con validación de códigos únicos

### ✅ **Validaciones de Negocio Implementadas**
- **Alumno**: Legajo único, edad mínima 16 años
- **Universidad**: Sigla única, nombre obligatorio
- **Facultad**: Sigla única, ciudad obligatoria, email válido
- **Autoridad**: Nombre y cargo obligatorios, email válido
- **Materia**: Código único y válido, nombre obligatorio

## 📋 Entidades Implementadas

### 👤 Personas
- `Alumno` - Gestión completa de estudiantes con validaciones
- `Autoridad` - Autoridades de la facultad con validaciones

### 🏛️ Instituciones  
- `Universidad` - Datos de la UTN con validaciones
- `Facultad` - Datos de FRSR con validaciones

### 📚 Académico
- `Materia` - Materias del plan de estudios con validaciones
- `Plan` - Planes de carrera
- `Especialidad` - Especialidades disponibles
- `Departamento` - Departamentos académicos

### ⚙️ Administrativo
- `Area`, `Cargo`, `CategoriaCargo`, `Grado`, `Grupo`
- `Orientacion`, `TipoDedicacion`, `TipoEspecialidad`

## 🛠️ Tecnologías Utilizadas
- **ASP.NET Core 8.0** - Framework principal
- **C#** - Lenguaje de programación
- **Arquitectura en Capas** - Separación Controller/Service
- **Swagger/OpenAPI** - Documentación automática
- **Git & GitHub** - Control de versiones

## 📚 Endpoints Disponibles

### 👤 Alumnos
- `GET /api/Alumnos` - Listar todos los alumnos
- `GET /api/Alumnos/{nroLegajo}` - Obtener alumno por legajo
- `POST /api/Alumnos` - Crear nuevo alumno (valida legajo único y edad)
- `PUT /api/Alumnos/{nroLegajo}` - Actualizar alumno
- `DELETE /api/Alumnos/{nroLegajo}` - Eliminar alumno

### 🏛️ Universidades
- `GET /api/Universidades` - Listar universidades
- `GET /api/Universidades/{sigla}` - Obtener universidad por sigla
- `POST /api/Universidades` - Crear nueva universidad (valida sigla única)
- `PUT /api/Universidades/{sigla}` - Actualizar universidad
- `DELETE /api/Universidades/{sigla}` - Eliminar universidad

### 🏫 Facultades
- `GET /api/Facultades` - Listar facultades
- `GET /api/Facultades/{sigla}` - Obtener facultad por sigla
- `POST /api/Facultades` - Crear nueva facultad (valida sigla única y ciudad)
- `PUT /api/Facultades/{sigla}` - Actualizar facultad
- `DELETE /api/Facultades/{sigla}` - Eliminar facultad

### 👨‍💼 Autoridades
- `GET /api/Autoridades` - Listar autoridades
- `GET /api/Autoridades/{id}` - Obtener autoridad por ID
- `POST /api/Autoridades` - Crear nueva autoridad (valida nombre y cargo)
- `PUT /api/Autoridades/{id}` - Actualizar autoridad
- `DELETE /api/Autoridades/{id}` - Eliminar autoridad

### 📖 Materias
- `GET /api/Materias` - Listar materias
- `GET /api/Materias/{codigo}` - Obtener materia por código
- `POST /api/Materias` - Crear nueva materia (valida código único y formato)
- `PUT /api/Materias/{codigo}` - Actualizar materia
- `DELETE /api/Materias/{codigo}` - Eliminar materia

## 🏃‍♀️ Cómo Ejecutar el Proyecto

### Prerrequisitos
- .NET 8.0 SDK
- Visual Studio 2022 o Visual Studio Code

### Pasos

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/sol-parada/sysacad-mejorado.git
   cd sysacad-mejorado
   ```

2. Restaurar dependencias:
   ```bash
   dotnet restore
   ```

3. Ejecutar el proyecto:
   ```bash
   dotnet run
   ```

4. Abrir en el navegador:
   ```
   https://localhost:7277/swagger
   ```

### 🧪 Probar la API

- Ejecuta el proyecto con `dotnet run`
- Ve a [https://localhost:7277/swagger](https://localhost:7277/swagger)
- Explora los 5 grupos de endpoints disponibles
- Usa "Try it out" para probar cada operación CRUD
- Verifica las validaciones intentando crear recursos duplicados

## 📊 Estado del Proyecto

- ✅ Completado
  - 16 modelos completos según diagrama UML
  - Arquitectura profesional en capas implementada
  - 5 Services con validaciones de negocio robustas
  - 5 Controllers con endpoints CRUD completos
  - Documentación Swagger automática
  - Manejo profesional de errores
  - Separación clara de responsabilidades

## 🔄 Próximas Mejoras

- Base de datos con Entity Framework
- Autenticación JWT
- Tests unitarios
- Dockerización
- Frontend web

## 🎯 Próximos Pasos en el Desarrollo

El proyecto evolucionará hacia:

- Persistencia con Entity Framework y PostgreSQL
- Seguridad con autenticación JWT
- Testing con suite de pruebas automatizadas
- Deployment con Docker y CI/CD

---

*Desarrollado para la UTN FRSR - 2025*

Arquitectura profesional implementada siguiendo mejores prácticas de desarrollo# 🎓 SysAcad Mejorado - Sistema Académico UTN

Sistema académico moderno desarrollado en C# con ASP.NET Core Web API, implementando una **arquitectura empresarial en capas** que mejora el sistema actual de la UTN FRSR.

## 👥 Equipo de Desarrollo
- **Sol Parada** - Desarrolladora Principal
- **Asistente IA** - Soporte en desarrollo

## 🏗️ Arquitectura del Sistema

El proyecto sigue una **arquitectura profesional en capas** que separa responsabilidades:

```
Capa de Presentación (Controllers/)
├── AlumnosController.cs
├── UniversidadesController.cs
├── FacultadesController.cs
├── AutoridadesController.cs
└── MateriasController.cs

Capa de Lógica de Negocio (Services/)
├── AlumnoService.cs
├── UniversidadService.cs
├── FacultadService.cs
├── AutoridadService.cs
└── MateriaService.cs

Capa de Dominio (Models/)
├── Alumno.cs
├── Universidad.cs
├── Facultad.cs
├── Autoridad.cs
├── Materia.cs
└── 11 clases más del diagrama UML
```

## 🚀 Características Implementadas

### ✅ **Arquitectura Profesional**
- Separación clara entre **Controllers** y **Services**
- **Validaciones de negocio** centralizadas en Services
- Manejo consistente de errores
- Código mantenible y escalable

### ✅ **Entidades Principales con Validaciones**
- **Alumno** - Gestión completa con validaciones de legajo único y edad mínima
- **Universidad** - CRUD con validación de siglas únicas
- **Facultad** - Gestión con validaciones de ciudad, email y contactos
- **Autoridad** - Administración con validaciones de nombre y cargo
- **Materia** - Gestión académica con validación de códigos únicos

### ✅ **Validaciones de Negocio Implementadas**
- **Alumno**: Legajo único, edad mínima 16 años
- **Universidad**: Sigla única, nombre obligatorio
- **Facultad**: Sigla única, ciudad obligatoria, email válido
- **Autoridad**: Nombre y cargo obligatorios, email válido
- **Materia**: Código único y válido, nombre obligatorio

## 📋 Entidades Implementadas

### 👤 Personas
- `Alumno` - Gestión completa de estudiantes con validaciones
- `Autoridad` - Autoridades de la facultad con validaciones

### 🏛️ Instituciones  
- `Universidad` - Datos de la UTN con validaciones
- `Facultad` - Datos de FRSR con validaciones

### 📚 Académico
- `Materia` - Materias del plan de estudios con validaciones
- `Plan` - Planes de carrera
- `Especialidad` - Especialidades disponibles
- `Departamento` - Departamentos académicos

### ⚙️ Administrativo
- `Area`, `Cargo`, `CategoriaCargo`, `Grado`, `Grupo`
- `Orientacion`, `TipoDedicacion`, `TipoEspecialidad`

## 🛠️ Tecnologías Utilizadas
- **ASP.NET Core 8.0** - Framework principal
- **C#** - Lenguaje de programación
- **Arquitectura en Capas** - Separación Controller/Service
- **Swagger/OpenAPI** - Documentación automática
- **Git & GitHub** - Control de versiones

## 📚 Endpoints Disponibles

### 👤 Alumnos
- `GET /api/Alumnos` - Listar todos los alumnos
- `GET /api/Alumnos/{nroLegajo}` - Obtener alumno por legajo
- `POST /api/Alumnos` - Crear nuevo alumno (valida legajo único y edad)
- `PUT /api/Alumnos/{nroLegajo}` - Actualizar alumno
- `DELETE /api/Alumnos/{nroLegajo}` - Eliminar alumno

### 🏛️ Universidades
- `GET /api/Universidades` - Listar universidades
- `GET /api/Universidades/{sigla}` - Obtener universidad por sigla
- `POST /api/Universidades` - Crear nueva universidad (valida sigla única)
- `PUT /api/Universidades/{sigla}` - Actualizar universidad
- `DELETE /api/Universidades/{sigla}` - Eliminar universidad

### 🏫 Facultades
- `GET /api/Facultades` - Listar facultades
- `GET /api/Facultades/{sigla}` - Obtener facultad por sigla
- `POST /api/Facultades` - Crear nueva facultad (valida sigla única y ciudad)
- `PUT /api/Facultades/{sigla}` - Actualizar facultad
- `DELETE /api/Facultades/{sigla}` - Eliminar facultad

### 👨‍💼 Autoridades
- `GET /api/Autoridades` - Listar autoridades
- `GET /api/Autoridades/{id}` - Obtener autoridad por ID
- `POST /api/Autoridades` - Crear nueva autoridad (valida nombre y cargo)
- `PUT /api/Autoridades/{id}` - Actualizar autoridad
- `DELETE /api/Autoridades/{id}` - Eliminar autoridad

### 📖 Materias
- `GET /api/Materias` - Listar materias
- `GET /api/Materias/{codigo}` - Obtener materia por código
- `POST /api/Materias` - Crear nueva materia (valida código único y formato)
- `PUT /api/Materias/{codigo}` - Actualizar materia
- `DELETE /api/Materias/{codigo}` - Eliminar materia

## 🏃‍♀️ Cómo Ejecutar el Proyecto

### Prerrequisitos
- .NET 8.0 SDK
- Visual Studio 2022 o Visual Studio Code

### Pasos

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/sol-parada/sysacad-mejorado.git
   cd sysacad-mejorado
   ```

2. Restaurar dependencias:
   ```bash
   dotnet restore
   ```

3. Ejecutar el proyecto:
   ```bash
   dotnet run
   ```

4. Abrir en el navegador:
   ```
   https://localhost:7277/swagger
   ```

### 🧪 Probar la API

- Ejecuta el proyecto con `dotnet run`
- Ve a [https://localhost:7277/swagger](https://localhost:7277/swagger)
- Explora los 5 grupos de endpoints disponibles
- Usa "Try it out" para probar cada operación CRUD
- Verifica las validaciones intentando crear recursos duplicados

## 📊 Estado del Proyecto

- ✅ Completado
  - 16 modelos completos según diagrama UML
  - Arquitectura profesional en capas implementada
  - 5 Services con validaciones de negocio robustas
  - 5 Controllers con endpoints CRUD completos
  - Documentación Swagger automática
  - Manejo profesional de errores
  - Separación clara de responsabilidades

## 🔄 Próximas Mejoras

- Base de datos con Entity Framework
- Autenticación JWT
- Tests unitarios
- Dockerización
- Frontend web

## 🎯 Próximos Pasos en el Desarrollo

El proyecto evolucionará hacia:

- Persistencia con Entity Framework y PostgreSQL
- Seguridad con autenticación JWT
- Testing con suite de pruebas automatizadas
- Deployment con Docker y CI/CD

---

*Desarrollado para la UTN FRSR - 2025*

Arquitectura profesional implementada siguiendo mejores prácticas de desarrollo