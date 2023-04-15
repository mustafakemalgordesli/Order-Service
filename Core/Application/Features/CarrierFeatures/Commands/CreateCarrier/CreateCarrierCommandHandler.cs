using Application.DTOs;
using Application.Features.CarrierFeatures.Queries.GetAll;
using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Application.Mapping;
using Application.Wrappers;
using AutoMapper;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Commands.CreateCarrier;

public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommand, ServiceResponse<CarrierViewDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarrierRepository _carrierRepository;
    IMapper _mapper;
    public CreateCarrierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _carrierRepository = _unitOfWork.CarrierRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<CarrierViewDto>> Handle(CreateCarrierCommand command, CancellationToken cancellationToken)
    {
        Carrier carrier = _mapper.Map<Carrier>(command);
        await _carrierRepository.AddAsync(carrier);
        await _unitOfWork.SaveChangesAsync();
        CarrierViewDto viewDto = _mapper.Map<CarrierViewDto>(carrier);
        return new ServiceResponse<CarrierViewDto>(viewDto, Messages.CarrierAdded);
    }
}
