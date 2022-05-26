using Eldorado.Domain;
using Eldorado.Persistence;
using Microsoft.EntityFrameworkCore;

ApplicationDbContext applicationDbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
DbInitializer.Initialize(applicationDbContext);



using (ApplicationDbContext dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
{
    void CheackCaregories()
    {
        var categories = dbContext.ProductCategories.Include(p => p.Products).ToList();

        foreach (var category in categories)
        {
            Console.WriteLine($"Category: {category.Name}");

            foreach (var phone in category.Products ?? new())
            {
                Console.WriteLine($"Phone: {phone.Name}");
            }

            Console.WriteLine($"\n{new string('_', 30)}");
        }

        Console.WriteLine($"\n{new string('_', 80)}");
    }

    ProductCategory phoneCategory = new ProductCategory
    {
        Name = "Phones",
    };

    ProductCategory notebookCategory = new ProductCategory
    {
        Name = "Notebooks",
    };

    await dbContext.ProductCategories.AddRangeAsync(phoneCategory, notebookCategory);
    await dbContext.SaveChangesAsync();

    Product phoneIphone = new Product
    {
        Name = "Iphone",
        Count = 200,
        Image = "none",
        Price = 1300,
        Description = "Iphone  cool phoneIphone",
        Specifications = "Iphone  cool phoneX",
        Producer = "Apple",
        ProductCategory = phoneCategory
    };

    Product phoneSamsung = new Product
    {
        Name = "Samsung",
        Count = 233,
        Image = "none",
        Price = 1000,
        Description = "Samsung  cool phoneIphone",
        Specifications = "Samsung  cool Flip",
        Producer = "Samsung",
        ProductCategory = phoneCategory
    };

    Product notebookMac = new Product
    {
        Name = "Macbook",
        Count = 113,
        Image = "none",
        Price = 3000,
        Description = "Apple  cool notebook",
        Specifications = "Apple  cool notebookMacUltraHd16k",
        Producer = "Apple",
        ProductCategory = notebookCategory
    };

    Product notebookXiaomi = new Product
    {
        Name = "XiaomiBook",
        Count = 190,
        Image = "none",
        Price = 1500,
        Description = "Xiaomi  cool notebook",
        Specifications = "Xiaomi  cool notebookUltra3000",
        Producer = "Xiaomi",
        ProductCategory = notebookCategory
    };

    await dbContext.Products.AddRangeAsync(phoneIphone, phoneSamsung, notebookMac, notebookXiaomi);
    await dbContext.SaveChangesAsync();

    //CheackCaregories();

    //dbContext.ProductCategories.Remove(phoneCategory);
    //dbContext.SaveChanges();

    //CheackCaregories();

    //var products = dbContext.Products.ToList();

    //foreach (var product in products)
    //{
    //    Console.WriteLine($"Product: {product.Name}");
    //    product.ProductCategory = notebookCategory;
    //}

    //dbContext.UpdateRange(products);
    //dbContext.SaveChanges();

    //Console.Clear();
    //CheackCaregories();

    //dbContext.Products.Remove(phoneSamsung);
    //dbContext.SaveChanges();

    //Console.Clear();
    //CheackCaregories();




    Customer customer = new Customer
    {
        FirstName = "Maksim",
        LastName = " Spicin",
        Age = 19,
        Phone = "12345678901",
        Email = "dfsagwge2gmail.com",
        CustomerAddress = new CustomerAddress
        {
            City = "Balakovo",
            Street = "Lenina",
            House = 4,
            Apartment = 21
        },
        CreditCards = new List<CreditCard>
        {
            new CreditCard
            {
                Number = 9124567894325678,
                CVV2 = 123,
                EndDate = DateTime.Now,
                OwnerName = "Maksim Spicin"
            },

            new CreditCard
            {
                Number = 6374927561936427,
                CVV2 = 213,
                EndDate = DateTime.Now,
                OwnerName = "Maksim Spicin"
            }
        },
        
    };

    SelectedProduct selectedProduct1= new SelectedProduct { Product = phoneIphone};
    SelectedProduct selectedProduct2= new SelectedProduct { Product = notebookMac};
    DeliveryPoint deliveryPoint = new DeliveryPoint
    {
        DeliveryPointAddress = new DeliveryPointAddress
        {
            City = "Balakovo",
            Street = "Lenina",
            House = 4
        },
        WorkingTime = DateTime.Now,
    };
    
    
    dbContext.Customers.Add(customer);
    dbContext.SelectedProducts.AddRange(selectedProduct1,selectedProduct2);
    dbContext.DeliveryPoints.Add(deliveryPoint);
    
    dbContext.SaveChanges();

    //customer.Cart.SelectedProducts.Add(selectedProduct1);
    //customer.Cart.SelectedProducts.Add(selectedProduct2);
    Order order = (new Order
    {
        Date = DateTime.Now,
        Price = 300,
        SelectedProducts = new List<SelectedProduct> { selectedProduct1, selectedProduct2 },
        DeliveryPoint = deliveryPoint,
        Customer = customer
    });

    dbContext.Orders.Add(order);
    customer.Orders.Add(order);
    customer.Cart.SelectedProducts.Add(selectedProduct1);
    customer.Cart.SelectedProducts.Add(selectedProduct2);
    dbContext.Customers.Update(customer);
    dbContext.SaveChanges();

    Courier courier = new Courier
    {
        FirstName = "Abdula",
        LastName = "Gahmedov",
        Phone = "4239084903",
        PassportNumber = 49023740923,
        Age = 21,

    };

    dbContext.Couriers.Add(courier);
    courier.Orders.Add(dbContext.Orders.First());
    dbContext.SaveChanges();
    //customer.Cart.SelectedProducts = new();
    //dbContext.Customers.Update(customer);
    //dbContext.SaveChanges();
    //dbContext.Customers.Remove(dbContext.Customers.FirstOrDefault());
    //dbContext.SelectedProducts.Remove(dbContext.SelectedProducts.FirstOrDefault());
    //dbContext.Carts.Remove(dbContext.Carts.FirstOrDefault());
    //dbContext.Products.Remove(phoneIphone);
    //dbContext.DeliveryPoints.Remove(dbContext.DeliveryPoints.FirstOrDefault());
    dbContext.Orders.Remove(dbContext.Orders.FirstOrDefault());
    //dbContext.DeliveryPoints.Remove(dbContext.DeliveryPoints.FirstOrDefault());
    //dbContext.Couriers.Remove(courier);
    dbContext.SaveChanges();
}


