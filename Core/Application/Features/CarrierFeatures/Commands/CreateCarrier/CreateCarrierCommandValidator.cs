using Domain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CarrierFeatures.Commands.CreateCarrier;

public class CreateCarrierCommandValidator : AbstractValidator<CreateCarrierCommand>
{
	public CreateCarrierCommandValidator()
	{
		RuleFor(x => x.CarrierName).NotEmpty().NotNull().WithMessage(Messages.CarrierNameNotEmpty).MinimumLength(3).MaximumLength(255);
		RuleFor(x => x.CarrierPlusDesiCost).NotNull().GreaterThanOrEqualTo(0);
    }
}
