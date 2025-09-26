# SalesDatePrediction - Prueba Técnica

Proyecto Full-Stack que incorpora API REST en ASP .NET Core, módulo de visulización en D3.js y aplicación SPA Angular para predecir fechas de futuras ventas. 

## 📁 Estructura del proyecto
```
SalesDatePrediction/
│── SQL-Scripts/                # Scripts SQL de la base de datos
│── Back End/                   # API Rest Clean Architecture en .NET Core 8
│── Front-End/                  # Aplicacion SPA en Angular 19.2
│── D3/                         # Visualización de gráficos con librería D3.js
```

---

## 📌 Requisitos previos
* [SQL Server]
* [SDK Desarrollo .NET Core 8]
* [Node.js 22.16.0]
* [Angular CLI 19.2.15]
* [npm 10.9.2]
---
## ⚙️ Configuración del proyecto

### 🌐 Back End (.NET Core 8)
Proyecto backend desarrollado con ASP.NET Core. Incluye controladores, servicios, repositorios y modelos para gestionar los datos.

Para correr la API:
1. Abrir la carpeta **`Back End/SalesDatePrediction.API/`**.
2. Ajustar la conexi¨®n a la base de datos en el archivo **`appsettings.json`**.
3. Ejecutar el proyecto:

```bash
dotnet run
```
La API quedaría accesible desde:
?? [http://localhost:8080](http://localhost:8080)

📚 Endpoints Expuestos (Documentación Swagger):

GET /api/v1/Customers/GetOrderPredictions: Lista clientes con fecha de última orden y fecha prevista de la siguiente orden.

POST /api/v1/Orders/NewOrder: Crea una nueva orden.

GET /api/v1/Orders/GetByCustomerId/{customerId}: Lista ordenes por cliente.

GET /api/v1/Employees/GetAll: Lista todos los empleados.

GET /api/v1/Products/GetAll: Lista todos los productos.

GET /api/v1/Shippers/GetAll: Lista todos los transportistas (Shippers).


### 🧪 Pruebas Unitarias(xUnit)
Conjunto de Casos de Pruebas Unitarias desarrolladas para la validación de los servicios y controladores de la API.

Para correr las pruebas:
1. Abrir la carpeta **`Back End/SalesDatePrediction.APITest/`**.
2. Ejecutar pruebas:

```bash
dotnet test


### Front End (SPA en Angular)
Aplicacion SPA que consume la API REST para la visualización y creación de ordenes

Para correr la aplicación:
1. Abrir la carpeta **`Front-End/`**.
2. Instalar dependencias:

```bash
npm install
```

3. Iniciar la aplicación Angular:

```bash
ng serve
```

La aplicación quedar disponible en:
ðŸ‘‰ [http://localhost:60006](http://localhost:60006)

### Visualización de graficador (D3.js)
Módulo de visualización de gráficos mediante el uso de librería D3.js

Para correr el módulo:
1. Abrir la carpeta **`D3/`**.
2. Abrir el archivo index.html en tu navegador.

---


