using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, ServiceResponse<List<OrderViewDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _orderRepository = _unitOfWork.OrderRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<OrderViewDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var alllist = await _orderRepository.GetAllAsync();

        var viewModel = alllist.Select(x => _mapper.Map<OrderViewDto>(x)).ToList();

        return new ServiceResponse<List<OrderViewDto>>(viewModel);
    }
}
