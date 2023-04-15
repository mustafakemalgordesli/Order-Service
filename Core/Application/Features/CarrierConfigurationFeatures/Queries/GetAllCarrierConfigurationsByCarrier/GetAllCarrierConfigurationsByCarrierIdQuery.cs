using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierConfigurationFeatures.Queries.GetAllCarrierConfigurationsByCarrier
{
    public class GetAllCarrierConfigurationsByCarrierIdQuery : IRequest<ServiceResponse<List<CarrierConfigurationViewDto>>>
    {
        public GetAllCarrierConfigurationsByCarrierIdQuery(int carrierId)
        {
            CarrierId = carrierId;
        }
        public int CarrierId { get; set;}
    }
}
