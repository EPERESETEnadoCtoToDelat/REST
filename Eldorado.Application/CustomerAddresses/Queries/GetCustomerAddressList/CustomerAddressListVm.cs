using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Queries.GetCustomerAddressList
{
    public class CustomerAddressListVm
    {
        public IList<CustomerAddressLookupDto>? CustomerAddresses { get; set; }
    }
}
