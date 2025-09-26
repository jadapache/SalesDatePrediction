using SalesDatePrediction.Api.Middleware;
using System.Reflection;
using System;
using SalesDatePrediction.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Infraestructure.Services;
using SalesDatePrediction.Application.Interfaces.Repositories;
using SalesDatePrediction.Infraestructure.Repositories;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using SalesDatePrediction.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.WebHost.UseUrls("http://0.0.0.0:8080", "http://localhost:5000");

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();



var conString = builder.Configuration.GetConnectionString("DefaultConnection") ??
     throw new InvalidOperationException("Connection string 'DefaultConnection'" +
    " not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(conString));

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});



// ─────────────────────────────
// CORS
// ─────────────────────────────
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
    {
        policy
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
    });
});


// ─────────────────────────────
// Inyección de servicios (Application Layer)
// ─────────────────────────────
builder.Services.AddApiExtention();



// ─────────────────────────────
// Swagger (con soporte Bearer Token)
// ─────────────────────────────

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SalesDatesPrediction", Version = "v1" });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// ─────────────────────────────
// Controllers y Middleware
// ─────────────────────────────
//Global Exception Errors I
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();





// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//Global Exception Errors II
app.UseExceptionHandler();
app.UseStatusCodePages();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseHttpsRedirection();

app.UseCors("DevCors");


app.MapControllers();

app.Run();