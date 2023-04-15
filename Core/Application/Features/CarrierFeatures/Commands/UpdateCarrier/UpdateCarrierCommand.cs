using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Commands.UpdateCarrier
{
    public class UpdateCarrierCommand : IRequest<ServiceResponse<CarrierViewDto>>
    {
        public int Id { get; set; }
        public string? CarrierName { get; set; }
        public bool? CarrierIsActive { get; set; }
        public int? CarrierPlusDesiCost { get; set; }
    }
}
