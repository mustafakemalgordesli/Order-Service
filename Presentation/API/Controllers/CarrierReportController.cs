using Application.Features.CarrierReportFeatures.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierReportController : ControllerBase
    {
        IMediator mediator;
        public CarrierReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarrierConfiguration()
        {
            return Ok(await mediator.Send(new GetAllCarrierReportQuery()));
        }
    }
}
