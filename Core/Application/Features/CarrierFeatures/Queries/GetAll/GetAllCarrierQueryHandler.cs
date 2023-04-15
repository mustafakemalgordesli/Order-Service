using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Application.Mapping;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Queries.GetAll;

public class GetAllCarrierQueryHandler : IRequestHandler<GetAllCarrierQuery, ServiceResponse<List<CarrierViewDto>>>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ICarrierRepository _carrierRepository;
	private readonly IMapper _mapper;
	public GetAllCarrierQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_carrierRepository = _unitOfWork.CarrierRepository;
		_mapper = mapper;
	}

    public async Task<ServiceResponse<List<CarrierViewDto>>> Handle(GetAllCarrierQuery request, CancellationToken cancellationToken)
    {
        var allist = await _carrierRepository.GetAllAsync();

        List<CarrierViewDto> viewModel = allist.Select(x => _mapper.Map<CarrierViewDto>(x)).ToList();

        return new ServiceResponse<List<CarrierViewDto>>(viewModel);
    }
}
