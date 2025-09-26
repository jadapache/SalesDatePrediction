
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces;

namespace SalesDatePrediction.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _serv;
    public ProductsController(IProductsService serv) => _serv = serv;

    /// <summary>
    /// Listar todos los productos
    /// </summary>
    /// <response code="200">Devuelve la lista de todos los productos.</response>
    /// <response code="500">Si ocurre un error interno del servidor.</response>
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var result = await _serv.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }

    }
}
