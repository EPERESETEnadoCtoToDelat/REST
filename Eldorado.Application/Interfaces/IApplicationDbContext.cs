using Eldorado.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Interfaces
{
    public interface IApplicationDbContext 
    {
        DbSet<Cart> Carts { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Courier> Couriers { get; set; }
        DbSet<CreditCard> CreditCards { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerAddress> CustomersAddresses { get; set; }
        DbSet<DeliveryPoint> DeliveryPoints { get; set; }
        DbSet<DeliveryPointAddress> DeliveryPointsAddress { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategory> ProductCategories { get; set; }
        DbSet<SelectedProduct> SelectedProducts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
