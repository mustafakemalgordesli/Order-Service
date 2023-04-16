using Application.Interfaces.Repository;
using Application.Interfaces.UnitOfWork;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierReportFeatures.Queries.GetAll
{
    public class GetAllCarrierReportQueryHandler : IRequestHandler<GetAllCarrierReportQuery, ServiceResponse<List<CarrierReport>>>
    {
        IUnitOfWork _unitOfWork;
        ICarrierReportRepository _carrierReportRepository;

        public GetAllCarrierReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _carrierReportRepository = _unitOfWork.CarrierReportRepository;
        }

        public async Task<ServiceResponse<List<CarrierReport>>> Handle(GetAllCarrierReportQuery request, CancellationToken cancellationToken)
        {
            return new ServiceResponse<List<CarrierReport>>(await _carrierReportRepository.GetAllAsync());
        }
    }
}
