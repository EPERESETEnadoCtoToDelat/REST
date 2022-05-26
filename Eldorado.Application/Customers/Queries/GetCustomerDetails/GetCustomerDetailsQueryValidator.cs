using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryValidator : AbstractValidator<GetCustomerDetailsQuery>
    {
        public GetCustomerDetailsQueryValidator()
        {
            RuleFor(getCustomerDetailsQuery => getCustomerDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
