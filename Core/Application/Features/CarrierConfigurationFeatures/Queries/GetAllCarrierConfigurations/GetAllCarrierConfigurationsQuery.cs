using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierConfigurationFeatures.Queries.GetAllCarrierConfigurations;

public class GetAllCarrierConfigurationsQuery : IRequest<ServiceResponse<List<CarrierConfigurationViewDto>>>
{
}
