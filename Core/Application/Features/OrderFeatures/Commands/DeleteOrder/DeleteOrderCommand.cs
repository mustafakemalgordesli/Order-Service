using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<ServiceResponse>
    {
        public DeleteOrderCommand(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
