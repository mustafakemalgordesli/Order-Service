using Application.Exceptions;
using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierConfigurationFeatures.Commands.DeleteCarrierConfiguration;

public class DeleteCarrierConfigurationCommandHandler : IRequestHandler<DeleteCarrierConfigurationCommand, ServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;

    public DeleteCarrierConfigurationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _carrierConfigurationRepository = _unitOfWork.CarrierConfigurationRepository;
    }

    public async Task<ServiceResponse> Handle(DeleteCarrierConfigurationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _carrierConfigurationRepository.GetByIdAsync(request.id);
        if (entity == null) throw new NotFoundException(Messages.CarrierConfigurationNotFound);
        _carrierConfigurationRepository.Delete(entity);
        _unitOfWork.SaveChanges();
        return new ServiceResponse(true, Messages.CarrierConfigurationDeleted);
    }
}
