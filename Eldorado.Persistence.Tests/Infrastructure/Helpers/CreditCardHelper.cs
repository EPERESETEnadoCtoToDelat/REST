using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Persistence.Tests.Infrastructure.Helpers
{
    public static class CreditCardHelper
    {
        public static CreditCard GetOne()
        {
            return new CreditCard
            {
                Number = 9124567894325678,
                CVV2 = 123,
                EndDate = DateTime.Now,
                OwnerName = "Maksim Spicin"
            };
        }

        public static IEnumerable<CreditCard> GetMany()
        {
            yield return GetOne();
        }
    }
}
