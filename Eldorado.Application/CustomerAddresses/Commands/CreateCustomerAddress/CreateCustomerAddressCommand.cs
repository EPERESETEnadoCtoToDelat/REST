using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Commands.CreateCustomerAddress
{
    public class CreateCustomerAddressCommand : IRequest<Guid>
    {
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int House { get; set; }
        public int Apartment { get; set; }
        public Guid CustomerId { get; set; }
    }
}
