using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Persistence.Tests.Infrastructure.Helpers
{
    public static class CustomerAddressHelper
    {
        public static CustomerAddress GetOne()
        {
            return new CustomerAddress
            {
                City = "Balakovo",
                Street = "Lenina",
                House = 4,
                Apartment = 21
            };
        }

        public static IEnumerable<CustomerAddress> GetMany()
        {
            yield return GetOne();
        }
    }
}
