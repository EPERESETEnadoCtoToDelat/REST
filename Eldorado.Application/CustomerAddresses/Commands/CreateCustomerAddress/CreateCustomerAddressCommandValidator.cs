using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Commands.CreateCustomerAddress
{
    public class CreateCustomerAddressCommandValidator : AbstractValidator<CreateCustomerAddressCommand>
    {
        public CreateCustomerAddressCommandValidator()
        {
            RuleFor(createCustomerAddressCommand =>
                createCustomerAddressCommand.CustomerId).NotEqual(Guid.Empty);
            RuleFor(createCustomerAddressCommand =>
                createCustomerAddressCommand.Street).NotEqual(string.Empty);
            RuleFor(createCustomerAddressCommand =>
                createCustomerAddressCommand.City).NotEqual(string.Empty);
            RuleFor(createCustomerAddressCommand =>
                createCustomerAddressCommand.House).NotEmpty();
            RuleFor(createCustomerAddressCommand =>
                createCustomerAddressCommand.Apartment).NotEmpty();
        }
    }
}
