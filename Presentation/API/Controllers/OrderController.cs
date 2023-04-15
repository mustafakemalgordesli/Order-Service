using Application.Features.CarrierFeatures.Commands.DeleteCarrier;
using Application.Features.OrderFeatures.Commands.CreateOrder;
using Application.Features.OrderFeatures.Commands.DeleteOrder;
using Application.Features.OrderFeatures.Queries.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] CreateOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
        {
            var response = await _mediator.Send(new GetAllOrdersQuery());

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id 0 a eşit yada küçük olmamalıdır" });
            }

            var command = new DeleteOrderCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

    }
}
