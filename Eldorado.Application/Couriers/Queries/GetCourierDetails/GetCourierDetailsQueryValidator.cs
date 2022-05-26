using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Queries.GetCourierDetails
{
    public class GetCourierDetailsQueryValidator : AbstractValidator<GetCourierDetailsQuery>
    {
        public GetCourierDetailsQueryValidator()
        {
            RuleFor(getCourierDetailsQuery => getCourierDetailsQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
