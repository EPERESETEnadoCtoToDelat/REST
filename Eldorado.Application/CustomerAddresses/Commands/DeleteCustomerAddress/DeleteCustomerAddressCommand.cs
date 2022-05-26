using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Commands.DeleteCustomerAddress
{
    public class DeleteCustomerAddressCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
    }
}
