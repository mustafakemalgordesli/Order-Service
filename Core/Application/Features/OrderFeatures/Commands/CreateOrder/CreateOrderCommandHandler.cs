using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Features.OrderFeatures.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, ServiceResponse<OrderViewDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
    private readonly ICarrierRepository _carrierRepository;

    public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _carrierConfigurationRepository = _unitOfWork.CarrierConfigurationRepository;
        _carrierRepository = _unitOfWork.CarrierRepository;
        _orderRepository = _unitOfWork.OrderRepository;
    }

    public async Task<ServiceResponse<OrderViewDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = _mapper.Map<Order>(request);

        var carrierConfig = _carrierConfigurationRepository.FindByDesi(request.OrderDesi);

        if (carrierConfig == null) { 
            carrierConfig = _carrierConfigurationRepository.FindByDesiMostSuit(request.OrderDesi);

            if (carrierConfig == null)
            {
                throw new BusinessRuleValidationException(Messages.SuitableCarrierNotFound);
            }
            order.OrderCarrierCost = carrierConfig.CarrierCost + Convert.ToDecimal((request.OrderDesi - carrierConfig.CarrierMaxDesi) * carrierConfig.Carrier.CarrierPlusDesiCost);
        }
        else
        {
            order.OrderCarrierCost = carrierConfig.CarrierCost;
        }
     
        order.CarrierId = carrierConfig.CarrierId;


        await _orderRepository.AddAsync(order);
        await _unitOfWork.SaveChangesAsync();
        var viewDto = _mapper.Map<OrderViewDto>(order);
        return new ServiceResponse<OrderViewDto>(viewDto);  
    }
}
