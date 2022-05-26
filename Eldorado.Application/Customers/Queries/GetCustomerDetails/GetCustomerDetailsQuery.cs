using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Customers.Queries.GetCustomerDetails
{
    public  class GetCustomerDetailsQuery : IRequest<CustomerDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
