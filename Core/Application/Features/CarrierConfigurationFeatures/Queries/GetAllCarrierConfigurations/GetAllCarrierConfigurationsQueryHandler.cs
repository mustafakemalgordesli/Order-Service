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

namespace Application.Features.CarrierConfigurationFeatures.Queries.GetAllCarrierConfigurations;

public class GetAllCarrierConfigurationsQueryHandler : IRequestHandler<GetAllCarrierConfigurationsQuery, ServiceResponse<List<CarrierConfigurationViewDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
    private readonly IMapper _mapper;

    public GetAllCarrierConfigurationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _carrierConfigurationRepository = _unitOfWork.CarrierConfigurationRepository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<CarrierConfigurationViewDto>>> Handle(GetAllCarrierConfigurationsQuery request, CancellationToken cancellationToken)
    {
        var allist = await _carrierConfigurationRepository.GetAllAsync();
        var viewModel = allist.Select(x => _mapper.Map<CarrierConfigurationViewDto>(x)).ToList();
        return new ServiceResponse<List<CarrierConfigurationViewDto>>(viewModel);
    }
}
