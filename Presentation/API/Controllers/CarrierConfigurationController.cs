using Application.Features.CarrierConfigurationFeatures.Commands.CreateCarrierConfiguration;
using Application.Features.CarrierConfigurationFeatures.Commands.DeleteCarrierConfiguration;
using Application.Features.CarrierConfigurationFeatures.Commands.UpdateCarrierConfiguration;
using Application.Features.CarrierConfigurationFeatures.Queries.GetAllCarrierConfigurations;
using Application.Features.CarrierConfigurationFeatures.Queries.GetAllCarrierConfigurationsByCarrier;
using Application.Features.CarrierFeatures.Commands.UpdateCarrier;
using Application.Features.CarrierFeatures.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarrierConfigurationController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarrierConfiguration([FromBody]CreateCarrierConfigurationCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllByCarrierId([FromRoute] int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id 0 a eşit yada küçük olmamalıdır" });
            }

            var query = new GetAllCarrierConfigurationsByCarrierIdQuery(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllCarrierConfigurationsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrierConfiguration([FromRoute] int id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id 0 a eşit yada küçük olmamalıdır" });
            }

            var command = new DeleteCarrierConfigurationCommand(id);
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarrierConfiguration([FromRoute] int id, [FromBody] UpdateCarrierConfigurationCommand command)
        {
            if (id == null || id <= 0)
            {
                return BadRequest(new { Success = false, Message = "Id 0 a eşit yada küçük olmamalıdır" });
            }

            if (id != command.Id)
            {
                return BadRequest(new { Success = false, Message = "Id eşleşmiyor" });
            }

            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
