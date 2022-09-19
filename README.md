# 19 de Septiembre School - Microservice Architecture .NET Core

Proyecto de ejemplo en el cual veremos como gestionar calificaciones de colegios usando una arquitectura orientada a microservicios y .NET Core.

## ¿Cómo levantar el proyecto?
### 1. Cambiar las cadenas de conexión
Actualizar las cadenas de conexión de cada Microservicio por la que disponen.

### 2. Actualizar los puertos de los proyectos web y configurarlos en el archivo appsettings.json del servicio Gateway.Api
- [x] School.Api: localhost:5091
- [x] Matter.Api: localhost:5295
- [x] Qualification.Api: localhost:5011
- [x] User.Api: localhost:5243

### 3. Ejecutar las migraciones por cada microservicio en la capa de Persistence
```
update-database -context ApplicationDbContext
```
### 4.  Configurar las propiedades de la solución para iniciar los siguientes servicios web
- [x] Gateway.Api
- [x] School.Api
- [x] Matter.Api
- [x] Qualification.Api
- [x] User.Api

### 5.  Gateway.Api es el punto de entrada para los microservicios desde este servicio web se puede consumir los diferentes recursos

## Características
- [x] Construido en .NET 6.0
- [x] Sigue los principios Clean Architecture
- [x] CQRS (Command query responsibility segregation)
- [x] Repository pattern
- [x] Specification pattern
- [x] MSSQL

