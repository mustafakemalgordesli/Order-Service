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

namespace Application.Features.CarrierConfigurationFeatures.Commands.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommand, ServiceResponse<CarrierConfigurationViewDto>>
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        ICarrierConfigurationRepository _carrierConfigurationRepository;

        public UpdateCarrierConfigurationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, ICarrierConfigurationRepository carrierConfigurationRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _carrierConfigurationRepository = carrierConfigurationRepository;
        }

        public async Task<ServiceResponse<CarrierConfigurationViewDto>> Handle(UpdateCarrierConfigurationCommand request, CancellationToken cancellationToken)
        {
            var carrierConfig = await _carrierConfigurationRepository.GetByIdAsync(request.Id);

            if (carrierConfig == null) throw new Application.Exceptions.NotFoundException(Messages.CarrierConfigurationNotFound);

            carrierConfig.CarrierMaxDesi = request?.CarrierMaxDesi ?? carrierConfig.CarrierMaxDesi;

            carrierConfig.CarrierMinDesi = request?.CarrierMinDesi ?? carrierConfig.CarrierMinDesi;

            carrierConfig.CarrierCost = request?.CarrierCost ?? carrierConfig.CarrierCost;

            _unitOfWork.SaveChanges();

            var viewModel = _mapper.Map<CarrierConfigurationViewDto>(carrierConfig);

            return new ServiceResponse<CarrierConfigurationViewDto>(viewModel);
        }
    }
}
