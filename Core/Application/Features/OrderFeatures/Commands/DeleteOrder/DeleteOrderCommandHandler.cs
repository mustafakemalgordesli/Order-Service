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

namespace Application.Features.OrderFeatures.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, ServiceResponse>
    {
        IUnitOfWork _unitOfWork;
        IOrderRepository _orderRepository;
        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _orderRepository = _unitOfWork.OrderRepository;
        }

        public async Task<ServiceResponse> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _orderRepository.GetByIdAsync(request.id);
            if (entity == null) throw new NotFoundException(Messages.OrderNotFound);
            _orderRepository.Delete(entity);
            _unitOfWork.SaveChanges();
            return new ServiceResponse(true, Messages.OrderDeleted);
        }
    }
}
