using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Persistence.Tests.Infrastructure.Helpers
{
    public static class CustomerHelper
    {
        public static Customer GetOne()
        {
            var customerAddress = CustomerAddressHelper.GetOne();
            var creditCard = CreditCardHelper.GetMany().ToList();

            return new Customer
            {
                FirstName = "Maksim",
                LastName = " Spicin",
                Age = 19,
                Phone = "12345678901",
                Email = "dfsagwge2gmail.com",
                CustomerAddress = customerAddress,
                CreditCards = creditCard
            };
        }

        public static IEnumerable<Customer> GetMany()
        {
            yield return GetOne();
        }
    }
}
