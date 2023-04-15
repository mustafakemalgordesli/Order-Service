using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<ServiceResponse<OrderViewDto>>
{
    public int OrderDesi { get; set; }
    public DateTime OrderDate { get; set; }
}
