# 🎓 SysAcad Mejorado - Sistema Académico UTN

Sistema académico moderno desarrollado en C# con ASP.NET Core Web API, que mejora el sistema actual de la UTN FRSR.

## 👥 Equipo de Desarrollo
- **Sol Parada** - Desarrolladora Principal
- **Asistente IA** - Soporte en desarrollo

## 🚀 Características
- ✅ API RESTful completa
- ✅ 16 clases del dominio académico implementadas
- ✅ 4 controladores con operaciones CRUD
- ✅ Documentación automática con Swagger
- ✅ Estructura basada en el diagrama UML proporcionado

## 📋 Entidades Implementadas

### Personas
- `Alumno` - Gestión completa de estudiantes
- `Autoridad` - Autoridades de la facultad

### Instituciones  
- `Universidad` - Datos de la UTN
- `Facultad` - Datos de FRSR

### Académico
- `Materia` - Materias del plan de estudios
- `Plan` - Planes de carrera
- `Especialidad` - Especialidades disponibles
- `Departamento` - Departamentos académicos

### Administrativo
- `Area`, `Cargo`, `CategoriaCargo`, `Grado`, `Grupo`
- `Orientacion`, `TipoDedicacion`, `TipoEspecialidad`

## 🛠️ Tecnologías Utilizadas
- **ASP.NET Core 8.0** - Framework principal
- **C#** - Lenguaje de programación
- **Swagger/OpenAPI** - Documentación automática
- **Git & GitHub** - Control de versiones

## 📚 Endpoints Disponibles

### Alumnos
- `GET /api/Alumnos` - Listar todos los alumnos
- `GET /api/Alumnos/{nroLegajo}` - Obtener alumno por legajo
- `POST /api/Alumnos` - Crear nuevo alumno
- `PUT /api/Alumnos/{nroLegajo}` - Actualizar alumno
- `DELETE /api/Alumnos/{nroLegajo}` - Eliminar alumno

### Universidades
- `GET /api/Universidades` - Listar universidades
- `GET /api/Universidades/{sigla}` - Obtener universidad por sigla
- `POST /api/Universidades` - Crear nueva universidad

### Facultades
- `GET /api/Facultades` - Listar facultades
- `POST /api/Facultades` - Crear nueva facultad

### Autoridades
- `GET /api/Autoridades` - Listar autoridades
- `POST /api/Autoridades` - Crear nueva autoridad

## 🏃‍♀️ Cómo Ejecutar el Proyecto

### Prerrequisitos
- .NET 8.0 SDK
- Visual Studio 2022 o Visual Studio Code

### Pasos
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/sol-parada/sysacad-mejorado.git
   cd sysacad-mejorado

2. Restaurar dependencias:
   ```bash
   dotnet restore

3. Ejecutar el proyecto:
   ```bash
   dotnet run

4. Abrir en el navegador:
   ```bash
   https://localhost:7277/swagger

## 🧪 Probar la API

1-Ejecuta el proyecto con dotnet run.
2-Ve a https://localhost:7277/swagger
3-Explora los endpoints disponibles.
4-Usa "Try it out" para probar cada operación.