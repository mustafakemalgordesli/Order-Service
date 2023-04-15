using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierConfigurationFeatures.Commands.DeleteCarrierConfiguration;

public class DeleteCarrierConfigurationCommand : IRequest<ServiceResponse>
{
    public DeleteCarrierConfigurationCommand(int id)
    {
        this.id = id;
    }
    public int id { get; set; }
}
