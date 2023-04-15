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

namespace Application.Features.CarrierConfigurationFeatures.Queries.GetAllCarrierConfigurationsByCarrier;

public class GetAllCarrierConfigurationsByCarrierIdHandler : IRequestHandler<GetAllCarrierConfigurationsByCarrierIdQuery, ServiceResponse<List<CarrierConfigurationViewDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
    IMapper _mapper;
    public GetAllCarrierConfigurationsByCarrierIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _carrierConfigurationRepository = _unitOfWork.CarrierConfigurationRepository;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<List<CarrierConfigurationViewDto>>> Handle(GetAllCarrierConfigurationsByCarrierIdQuery request, CancellationToken cancellationToken)
    {
        var alllist = _carrierConfigurationRepository.FindAllByCondition(x => x.CarrierId == request.CarrierId);
        var viewModel = alllist.Select(x => _mapper.Map<CarrierConfigurationViewDto>(x)).ToList();
        return new ServiceResponse<List<CarrierConfigurationViewDto>>(viewModel);
    }
}
