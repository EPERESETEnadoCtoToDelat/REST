using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Queries.GetCustomerAddressDetails
{
    public class GetCustomerAddressDetailsValidator : AbstractValidator<GetCustomerAddressDetailsQuery>
    {
        public GetCustomerAddressDetailsValidator()
        {
            RuleFor(getCustomerAddressDetailsQuery => getCustomerAddressDetailsQuery.CustomerId).NotEqual(Guid.Empty);
        }
    }
}
