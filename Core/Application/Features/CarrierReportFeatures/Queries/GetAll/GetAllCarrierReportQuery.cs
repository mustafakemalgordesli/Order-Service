using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierReportFeatures.Queries.GetAll;

public class GetAllCarrierReportQuery : IRequest<ServiceResponse<List<CarrierReport>>>
{
}
