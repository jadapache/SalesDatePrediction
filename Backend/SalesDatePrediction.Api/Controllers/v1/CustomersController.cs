
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SalesDatePrediction.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomersService _serv;
    public CustomersController(ICustomersService serv) => _serv = serv;



    /// <summary>
    /// Listar clientes con fecha de última orden y fecha de posible siguiente orden.
    /// </summary>
    /// <param name="search">Predicado opcional para filtrar las predicciones.</param>
    /// <param name="page">Número de página actual. El valor predeterminado es 1.</param>
    /// <param name="pageSize">Número de registros por página. El valor predeterminado es 10.</param>
    /// <param name="sort">Ordenar los resultados por un campo especifico.</param>
    /// <param name="desc">Booleano para odenar descentemente los resultados. El valor predeterminado es falso.</param>
    /// <returns>Una lista paginada de predicciones de clientes.</returns>
    /// <response code="200">Devuelve una lista paginada de predicciones de clientes.</response>
    /// <response code="500">Si ocurre un error interno del servidor.</response>
    [HttpGet("GetOrderPredictions")]
    public async Task<IActionResult> GetCustomerPredictions(
        [FromQuery]
        [SwaggerParameter("Propiedad a filtrar.")]
        string? search,
        [FromQuery]
        [SwaggerParameter("Página actual.")]
        int page = 1,
        [FromQuery]
        [SwaggerParameter("El número de elementos por página.")]
        int pageSize = 10,
        [FromQuery]
        [SwaggerParameter("El campo por el cual ordenar los resultados (por ejemplo, 'nombre' o 'fecha').")]
        string? sort = null,
        [FromQuery]
        [SwaggerParameter("Establece a 'true' para ordenar en orden descendente.")]
        bool desc = false)
    {
        try
        {
            var result = await _serv.GetFilteredPaginated(search, page, pageSize, sort, desc);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }
    }

}
