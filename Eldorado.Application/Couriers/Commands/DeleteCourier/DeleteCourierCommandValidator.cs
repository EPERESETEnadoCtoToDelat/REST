using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Commands.DeleteCourier
{
    public class DeleteCourierCommandValidator : AbstractValidator<DeleteCourierCommand>
    {
        public DeleteCourierCommandValidator()
        {
            RuleFor(deleteCourierCommand => deleteCourierCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
