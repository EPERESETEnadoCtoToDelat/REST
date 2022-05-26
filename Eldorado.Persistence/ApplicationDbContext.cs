using DocumentFormat.OpenXml.Drawing;
using Eldorado.Application.Interfaces;
using Eldorado.Application.Orders.Queries.GetOrderDetails;
using Eldorado.Domain;
using Eldorado.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Persistence
{
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Courier> Couriers { get; set; } = null!;
        public DbSet<CreditCard> CreditCards { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<CustomerAddress> CustomersAddresses { get; set; } = null!;
        public DbSet<DeliveryPoint> DeliveryPoints { get; set; } = null!;
        public DbSet<DeliveryPointAddress> DeliveryPointsAddress { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<ProductCategory> ProductCategories { get; set; } = null!;
        public DbSet<SelectedProduct> SelectedProducts { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CartConfiguration());
            builder.ApplyConfiguration(new CourierConfiguration());
            builder.ApplyConfiguration(new CreditCardConfiguration());
            builder.ApplyConfiguration(new CustomerAddressConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new DeliveryPointAddressConfiguration());
            builder.ApplyConfiguration(new DeliveryPointCofiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new ProductCategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new SelectedProductConfiguration());
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //        optionsBuilder.UseSqlite("Data Source=eldorado.db");

        //    //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EldoradoSqlServerDb;Trusted_Connection=True;");
        //}
    }
}
