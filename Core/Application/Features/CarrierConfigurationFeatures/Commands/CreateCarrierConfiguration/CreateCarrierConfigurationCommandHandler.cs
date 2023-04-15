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

namespace Application.Features.CarrierConfigurationFeatures.Commands.CreateCarrierConfiguration;

public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommand, ServiceResponse<CarrierConfigurationViewDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
    IMapper _mapper;
    public CreateCarrierConfigurationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    { 
        _unitOfWork = unitOfWork;
        _carrierConfigurationRepository = _unitOfWork.CarrierConfigurationRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<CarrierConfigurationViewDto>> Handle(CreateCarrierConfigurationCommand request, CancellationToken cancellationToken)
    {
        var carrierConfig = _mapper.Map<Domain.Entities.CarrierConfiguration>(request);
        await _carrierConfigurationRepository.AddAsync(carrierConfig);
        await _unitOfWork.SaveChangesAsync();
        CarrierConfigurationViewDto viewDto = _mapper.Map<CarrierConfigurationViewDto>(carrierConfig);
        return new ServiceResponse<CarrierConfigurationViewDto>(viewDto);
    }
}
