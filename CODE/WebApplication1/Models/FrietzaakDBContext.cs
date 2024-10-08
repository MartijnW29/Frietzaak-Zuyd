using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class FrietzaakDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=.;Initial Catalog=Frietzaak2.2;Integrated Security=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Customer customer1 = new Customer()
            {
                Id = 1,
                Name = "henk",
                Email = "henk@gmail.com",
                PhoneNumber = "0669476936",
                Place = "Heerlen",
                Street = "HuisWeg",
                HomeNumber = "69",
                HomeNumberAddition = "b"
            };

            Product product1 = new Product()
            {
                Id = 1,
                Name = "Frikandel",
                Price = 2.25
            };
            Product product2 = new Product()
            {
                Id = 2,
                Name = "Kleine friet",
                Price = 2
            };
            Product product3 = new Product()
            {
                Id = 3,
                Name = "Medium friet",
                Price = 3.50
            };
            Product product4 = new Product()
            {
                Id = 4,
                Name = "Grote friet",
                Price = 4.25
            };

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderLines)  // Order heeft meerdere OrderLines
                .WithOne(ol => ol.Order)      // Elke OrderLine heeft één Order
                .HasForeignKey(ol => ol.OrderId)  // Foreign key is OrderId in OrderLines
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete inschakelen

            modelBuilder.Entity<Customer>()
                .HasData(customer1);
            modelBuilder.Entity<Product>()
                .HasData(product1,product2,product3,product4);

        }
    }
}
