
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces;

namespace SalesDatePrediction.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class ShippersController : ControllerBase
{
    private readonly IShippersService _serv;
    public ShippersController(IShippersService serv) => _serv = serv;

    /// <summary>
    /// Listar todos los transportistas (Shippers)
    /// </summary>
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllShippers()
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
