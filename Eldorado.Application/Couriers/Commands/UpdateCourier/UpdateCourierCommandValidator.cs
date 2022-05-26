using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierCommandValidator : AbstractValidator<UpdateCourierCommand>
    {
        public UpdateCourierCommandValidator()
        {
            RuleFor(updateCourieCommand => updateCourieCommand.FirstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateCourieCommand => updateCourieCommand.LastName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(updateCourieCommand => updateCourieCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
