using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Commands.DeleteCarrier;

public class DeleteCarrierCommand : IRequest<ServiceResponse>
{
    public DeleteCarrierCommand(int id)
    {
        this.id = id;
    }
    public int id { get; set; }
}
