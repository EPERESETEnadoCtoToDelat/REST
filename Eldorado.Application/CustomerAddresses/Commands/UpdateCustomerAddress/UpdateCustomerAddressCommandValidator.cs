using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Commands.UpdateCustomerAddress
{
    public class UpdateCustomerAddressCommandValidator : AbstractValidator<UpdateCustomerAddressCommand>
    {
        public UpdateCustomerAddressCommandValidator()
        {
            RuleFor(updateCustomerAddressCommand =>
                updateCustomerAddressCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateCustomerAddressCommand =>
                updateCustomerAddressCommand.CustomerId).NotEqual(Guid.Empty);
            RuleFor(updateCustomerAddressCommand =>
                updateCustomerAddressCommand.Street).NotEqual(string.Empty);
            RuleFor(updateCustomerAddressCommand =>
                updateCustomerAddressCommand.City).NotEqual(string.Empty);
            RuleFor(updateCustomerAddressCommand =>
                updateCustomerAddressCommand.House).NotEmpty();
            RuleFor(updateCustomerAddressCommand =>
                updateCustomerAddressCommand.Apartment).NotEmpty();
        }
    }
}
