using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Commands.CreateCourier
{
    public class CreateCourierCommandValidator : AbstractValidator<CreateCourierCommand>
    {
        public CreateCourierCommandValidator()
        {
            RuleFor(createCourieCommand => createCourieCommand.FirstName).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(createCourieCommand => createCourieCommand.LastName).NotNull().NotEmpty().MaximumLength(50);
            
        }
    }
}
