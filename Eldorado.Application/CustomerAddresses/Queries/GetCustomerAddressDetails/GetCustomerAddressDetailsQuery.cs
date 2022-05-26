using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Queries.GetCustomerAddressDetails
{
    public class GetCustomerAddressDetailsQuery : IRequest<CustomerAddressDetailsVm>
    {
        public Guid CustomerId { get; set; }
    }
}
