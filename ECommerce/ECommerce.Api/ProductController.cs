using ECommerce.Api.Core.Application.Product.Commands;
using ECommerce.Api.Core.Application.Product.Commands.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api;

[ApiController]
[Route("api/orders/")]
public class ProductBasicsController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    [ProducesResponseType<CustomerOrderVm>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Product([FromBody] CreateOrderCommand request)
    {
        return Ok(await mediator.Send(request: request));
    }
}
