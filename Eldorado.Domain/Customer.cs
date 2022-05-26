using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? FullName { get; set; } = string.Empty;
        public CustomerAddress? CustomerAddress { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string? Email { get; set; }
        public List<CreditCard>? CreditCards { get; set; } = new();
        public Cart Cart { get; set; } = new();
        public List<Order>? Orders { get; set; } = new();
    }
}
