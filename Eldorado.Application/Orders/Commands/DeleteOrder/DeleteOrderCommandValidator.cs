using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(deleteOrderCommand => 
                deleteOrderCommand.Id).NotNull().NotEqual(Guid.Empty);
            RuleFor(deleteOrderCommand => 
                deleteOrderCommand.CustomerId).NotNull().NotEqual(Guid.Empty);
        }
    }
}
