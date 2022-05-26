using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(createCustomerCommand =>
                createCustomerCommand.FirstName).NotEqual(string.Empty).MaximumLength(50);
            RuleFor(createCustomerCommand =>
                createCustomerCommand.LastName).NotEqual(string.Empty).MaximumLength(50);
            RuleFor(createCustomerCommand =>
                createCustomerCommand.Age).NotNull();
            RuleFor(createCustomerCommand =>
                createCustomerCommand.Phone).NotEqual(string.Empty).MaximumLength(11);
            RuleFor(createCustomerCommand =>
                createCustomerCommand.Email).MaximumLength(50);
        }
    }
}
