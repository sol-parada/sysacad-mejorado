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

- **Arquitectura profesional en capas** (Controllers, Services, Models)
- **Validaciones de negocio robustas** en todos los servicios
- **API RESTful completa** con endpoints CRUD para todas las entidades principales
- **Documentación automática** con Swagger/OpenAPI
- **Manejo profesional de errores**
- **Persistencia real** con PostgreSQL y Entity Framework Core
- **Migraciones automáticas** aplicadas
- **Configuración Docker y Docker Compose** para desarrollo y despliegue
- **Datos de prueba iniciales** cargados correctamente
- **Eliminado código de ejemplo innecesario**

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

## 🛠️ Tecnologías Utilizadas

- **ASP.NET Core 8.0 / .NET 9** - Framework principal
- **C#** - Lenguaje de programación
- **Entity Framework Core** - ORM y migraciones
- **PostgreSQL** - Base de datos relacional
- **Docker & Docker Compose** - Contenedores y orquestación
- **Swagger/OpenAPI** - Documentación automática
- **Git & GitHub** - Control de versiones

## 🏃‍♀️ Cómo Ejecutar el Proyecto

### Prerrequisitos
- .NET 8.0 SDK o superior
- Docker y Docker Compose
- Visual Studio 2022 o Visual Studio Code

### Pasos

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/sol-parada/sysacad-mejorado.git
   cd sysacad-mejorado
   ```

2. Levantar la base de datos y la API con Docker:
   ```bash
   docker-compose up --build
   ```

3. (Opcional) Ejecutar migraciones manualmente:
   ```bash
   dotnet ef database update
   ```

4. Abrir en el navegador:
   ```
   https://localhost:7277/swagger
   ```

### 🧪 Probar la API

- Ejecuta el proyecto con Docker o `dotnet run`
- Ve a [https://localhost:7277/swagger](https://localhost:7277/swagger)
- Explora los endpoints disponibles y prueba cada operación CRUD

## 📊 Estado del Proyecto

- ✅ Arquitectura profesional en capas implementada
- ✅ 16 modelos completos según diagrama UML
- ✅ 5 Services con validaciones de negocio robustas
- ✅ 5 Controllers con endpoints CRUD completos
- ✅ Documentación Swagger automática
- ✅ Manejo profesional de errores
- ✅ Persistencia real con PostgreSQL y EF Core
- ✅ Docker y migraciones funcionando
- ✅ Separación clara de responsabilidades

## 🔄 Próximas Mejoras

- Autenticación JWT
- Tests unitarios y de integración
- Logging estructurado
- Paginación y filtros avanzados
- Frontend web

## 🎯 Próximos Pasos en el Desarrollo

- Seguridad con autenticación JWT
- Testing con suite de pruebas automatizadas
- Deployment con Docker y CI/CD
- Mejoras de performance y calidad

---

*Desarrollado para la UTN FRSR - 2025*

Arquitectura profesional implementada siguiendo mejores prácticas de desarrollo