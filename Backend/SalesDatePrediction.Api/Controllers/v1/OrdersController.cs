
using Microsoft.AspNetCore.Mvc;
using SalesDatePrediction.Application.Interfaces;
using SalesDatePrediction.Application.DTOs;
using SalesDatePrediction.Domain.Entities.Sales;
using SalesDatePrediction.Infraestructure.Services;

namespace SalesDatePrediction.Api.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _ordServ;
    private readonly IProductsService _prodServ;
    public OrdersController(IOrdersService ordServ, IProductsService prodServ)
    {
        _ordServ = ordServ;
        _prodServ = prodServ;
    }

    /// <summary>
    /// Crear una orden nueva con un producto
    /// </summary>
    [HttpPost("NewOrder")]
    public async Task<IActionResult> Create([FromBody] NewOrderDto request)
    {
        if (!ModelState.IsValid)
            return ValidationProblem(ModelState);

        var chkProd = await _prodServ.GetById(request.Detail.ProductId);
        if (chkProd== null)
        {
            return BadRequest($"El producto {request.Detail.ProductId} no existe.");
        }

        try
        {
            var newOrder = await _ordServ.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { id = newOrder }, new
            {
                message = $"La orden fue creada exitosamente con ID {newOrder}.",
                orderId = newOrder
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al crear nueva orden: {ex.Message}");
        }

        
    }

    /// <summary>
    /// Listar ordenes por cliente.
    /// </summary>
    /// <response code="200">Devuelve la lista de ordes por cliente.</response>
    /// <response code="500">Si ocurre un error interno del servidor.</response>
    [HttpGet("GetByCustomerId/{customerId:int}")]
    public async Task<IActionResult> GetOrdersByCustomer(int customerId)
    {
        try
        {
            var result = await _ordServ.GetByCustomerId(customerId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error interno: {ex.Message}");
        }   
    }
}
