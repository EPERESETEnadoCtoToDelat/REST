using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Commands.DeleteCustomerAddress
{
    public class DeleteCustomerAddressCommandValidator : AbstractValidator<DeleteCustomerAddressCommand>
    {
        public DeleteCustomerAddressCommandValidator()
        {
            RuleFor(deleteCustomerAddressCommand =>
                deleteCustomerAddressCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteCustomerAddressCommand =>
                deleteCustomerAddressCommand.CustomerId).NotEqual(Guid.Empty);
        }
    }
}
