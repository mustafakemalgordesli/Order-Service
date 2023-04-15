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

namespace Application.Features.CarrierFeatures.Queries.GetById
{
    public class GetCarrierByIdQueryHandler : IRequestHandler<GetCarrierByIdQuery, ServiceResponse<CarrierViewDto>>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetCarrierByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _carrierRepository = _unitOfWork.CarrierRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CarrierViewDto>> Handle(GetCarrierByIdQuery request, CancellationToken cancellationToken)
        {
            var carrier = await _carrierRepository.GetByIdAsync(request.id);
            var dto = _mapper.Map<CarrierViewDto>(carrier);
            return new ServiceResponse<CarrierViewDto>(dto);
        }
    }
}
