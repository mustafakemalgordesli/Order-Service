using Application.DTOs;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Queries.GetById;

public class GetCarrierByIdQuery : IRequest<ServiceResponse<CarrierViewDto>>
{
    public GetCarrierByIdQuery(int id)
    {
        this.id = id;
    }
    public int id { get; set; }
}
