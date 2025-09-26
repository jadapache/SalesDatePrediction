# SalesDatePrediction


Proyecto Full-Stack que incorpora API REST en ASP .NET Core, m��dulo de visulizaci��n en D3.js y aplicaci��n SPA Angular para predecir fechas de ventas, desarrollada como prueba técnica. 


## 📂 Estructura del proyecto

```
SalesDatePrediction/
│── Date Base/                  # Scripts SQL solicitados.
│── Back End/					# API Rest Clean Architecture en .NET Core 8
│── Front-End/                  # Aplicación SPA  en Angular 19.2
│── D3/                         # Visualización  on librería D3.js
```

## 📌 Requisitos
* [SQL Server]
* [SDK Desarrollo .NET Core 8]
* [Node.js 22.16.0]
* [Angular CLI 19.2.15]
* [npm 10.9.2]
---
## ⚙️ Configuración del proyecto

### Back End (.NET Core 8)
Proyecto backend desarrollado con ASP.NET Core. Incluye controladores, servicios, repositorios y modelos para gestionar los datos.
🔧 Para ejecutar la API:
1. Abrir la carpeta **`Back End/SalesDatePrediction.API/`**.
2. Ajustar la conexi��n a la base de datos en el archivo **`appsettings.json`**.
3. Ejecutar el proyecto:

```bash
dotnet run
```
```
La API quedar�� accesible desde:
?? [http://localhost:8080](http://localhost:8080)

### Pruebas Unitarias(xUnit)

1. Abrir la carpeta **`Back End/SalesDatePrediction.APITest/`**.
2. Ejecutar pruebas:

```bash
dotnet test


### Front End (SPA en Angular)

1. Abrir la carpeta **`Front-End/`**.
2. Instalar dependencias:

```bash
npm install
```

3. Iniciar la aplicación Angular:

```bash
ng serve
```

La aplicación quedará disponible en:
👉 [http://localhost:60006](http://localhost:60006)

### Visualizaci��n de graficador (D3.js)

1. Abrir la carpeta **`D3/`**.

2. Abrir el archivo index.html en tu navegador.

---

## ?? Caracter��sticas

Endpoints de la API (Documentaci��n mediante Swagger):



GET /api/v1/Customers/GetOrderPredictions: Lista clientes con fecha de última orden y fecha predicha de la siguiente orden.

POST /api/v1/Orders/NewOrder: Crea una nueva orden.

GET /api/v1/Orders/GetByCustomerId/{customerId}: Lista órdenes por cliente.

GET /api/v1/Employees/GetAll: Lista todos los empleados.

GET /api/v1/Products/GetAll: Lista todos los productos.

GET /api/v1/Shippers/GetAll: Lista todos los transportistas (Shippers).


