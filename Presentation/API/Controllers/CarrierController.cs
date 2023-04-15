using Application.Features.CarrierConfigurationFeatures.Commands.DeleteCarrierConfiguration;
using Application.Features.CarrierFeatures.Commands.CreateCarrier;
using Application.Features.CarrierFeatures.Commands.DeleteCarrier;
using Application.Features.CarrierFeatures.Commands.UpdateCarrier;
using Application.Features.CarrierFeatures.Queries.GetAll;
using Application.Features.CarrierFeatures.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly IMediator mediator;
        public CarrierController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarriers()
        {
            var query = new GetAllCarrierQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrier([FromBody]CreateCarrierCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id 0 a eşit yada küçük olmamalıdır" });
            }

            var query = new GetCarrierByIdQuery(id);
            var response = await mediator.Send(query);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrier([FromRoute] int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id 0 a eşit yada küçük olmamalıdır" });
            }

            var command = new DeleteCarrierCommand(id);
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCrrier([FromRoute]int id, [FromBody]UpdateCarrierCommand command)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id 0 a eşit yada küçük olmamalıdır" });
            }

            if (id != command.Id)
            {
                return BadRequest(new { Success = false, Message = "Id eşleşmiyor" });
            }

            var response = await mediator.Send(command);

            return Ok(response);
        }
    }
}
