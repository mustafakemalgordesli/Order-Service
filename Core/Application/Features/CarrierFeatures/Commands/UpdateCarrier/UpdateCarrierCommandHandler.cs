using Application.DTOs;
using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using AutoMapper;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Commands.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommand, ServiceResponse<CarrierViewDto>>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        ICarrierRepository _carrierRepository;
        public UpdateCarrierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _carrierRepository = _unitOfWork.CarrierRepository;
        }
        public async Task<ServiceResponse<CarrierViewDto>> Handle(UpdateCarrierCommand request, CancellationToken cancellationToken)
        {
            var carrier = await _carrierRepository.GetByIdAsync(request.Id);

            if (carrier == null) throw new Application.Exceptions.NotFoundException(Messages.CarrierNotFound);

            carrier.CarrierPlusDesiCost = request?.CarrierPlusDesiCost ?? carrier.CarrierPlusDesiCost;
            carrier.CarrierName = request?.CarrierName ?? carrier.CarrierName;
            carrier.CarrierIsActive = request?.CarrierIsActive ?? carrier.CarrierIsActive;

            _unitOfWork.SaveChanges();

            var viewModel = _mapper.Map<CarrierViewDto>(carrier);

            return new ServiceResponse<CarrierViewDto>(viewModel);
        }
    }
}
