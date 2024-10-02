using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class FrietzaakDBContext : DbContext
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderLine> OrderLines { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = @"Data Source=.;Initial Catalog=Frietzaak2.1;Integrated Security=true;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Gebruiker gebruiker1 = new Gebruiker()
            {
                GebruikerID = 1,
                Gebruikersnaam = "henk",
                Emailadres = "henk@gmail.com",
                Telefoonnummer = "0669476936",
                Plaats = "Heerlen",
                Straat = "HuisWeg",
                Huisnummer = "69",
                HuisnummerToevoeging = "b"
            };

            Product product1 = new Product()
            {
                ProductID = 1,
                ProductNaam = "Frikandel",
                ProductPrijs = 2.25
            };
            Product product2 = new Product()
            {
                ProductID = 2,
                ProductNaam = "Kleine friet",
                ProductPrijs = 2
            };
            Product product3 = new Product()
            {
                ProductID = 3,
                ProductNaam = "Medium friet",
                ProductPrijs = 3.50
            };
            Product product4 = new Product()
            {
                ProductID = 4,
                ProductNaam = "Grote friet",
                ProductPrijs = 4.25
            };
            modelBuilder.Entity<Gebruiker>()
                .HasData(gebruiker1);
            modelBuilder.Entity<Product>()
                .HasData(product1,product2,product3,product4);

        }
    }
}
