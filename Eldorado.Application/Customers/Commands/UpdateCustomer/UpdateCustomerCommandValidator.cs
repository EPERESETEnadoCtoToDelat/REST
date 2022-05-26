using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.FirstName).NotEqual(string.Empty).MaximumLength(50);
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.LastName).NotEqual(string.Empty).MaximumLength(50);
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.Age).NotNull();
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.Phone).NotEqual(string.Empty).MaximumLength(11);
            RuleFor(updateCustomerCommand =>
                updateCustomerCommand.Email).MaximumLength(50);
        }
    }
}
