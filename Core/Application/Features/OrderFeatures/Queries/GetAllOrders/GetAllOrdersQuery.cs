using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<ServiceResponse<List<OrderViewDto>>>
{
}
