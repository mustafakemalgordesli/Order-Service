using Application.Behaviors;
using Application.DTOs;
using Application.Wrappers;
using Domain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Commands.CreateCarrier;

public class CreateCarrierCommandValidateBehavior : ValidationBehavior<CreateCarrierCommand, CarrierViewDto>
{
    public CreateCarrierCommandValidateBehavior(IValidator<CreateCarrierCommand> validator) : base(validator, Messages.CarrierNotValidate)
    {

    }
}
