using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Commands.CreateCarrier;

public class CreateCarrierCommand : IRequest<ServiceResponse<CarrierViewDto>>
{
    public string CarrierName { get; set; }
    public int CarrierPlusDesiCost { get; set; }
}
