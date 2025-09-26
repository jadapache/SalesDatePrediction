
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces;
using Serilog;

namespace SalesDatePrediction.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesService _serv;
    public EmployeesController(IEmployeesService serv) => _serv = serv;

    /// <summary>   
    /// Listar todos los empleados
    /// </summary>
    /// <response code="200">Devuelve la lista de empleados.</response>
    /// <response code="500">Si ocurre un error interno del servidor.</response>
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetEmployees()
    {
        try
        {
            var result = await _serv.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            Log.Write(Serilog.Events.LogEventLevel.Error, ex, "Error en EmployeesController.GetEmployees");
            return StatusCode(500, $"Error interno: {ex.Message}");
        }

    }
}
