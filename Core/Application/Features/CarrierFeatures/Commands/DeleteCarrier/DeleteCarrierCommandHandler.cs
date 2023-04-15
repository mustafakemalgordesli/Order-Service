using Application.Exceptions;
using Application.Features.CarrierConfigurationFeatures.Commands.DeleteCarrierConfiguration;
using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Common;
using MediatR;

namespace Application.Features.CarrierFeatures.Commands.DeleteCarrier;

public class DeleteCarrierCommandHandler : IRequestHandler<DeleteCarrierCommand, ServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICarrierRepository _carrierRepository;

    public DeleteCarrierCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _carrierRepository = _unitOfWork.CarrierRepository;
    }

    public async Task<ServiceResponse> Handle(DeleteCarrierCommand request, CancellationToken cancellationToken)
    {
        var entity = await _carrierRepository.GetByIdAsync(request.id);
        if (entity == null) throw new NotFoundException(Messages.CarrierNotFound);
        _carrierRepository.Delete(entity);
        _unitOfWork.SaveChanges();
        return new ServiceResponse(true, Messages.CarrierDeleted);
    }
}
