﻿using Microsoft.EntityFrameworkCore;

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
            string connection = @"Data Source=.;Initial Catalog=Frietzaak2.0;Integrated Security=true;TrustServerCertificate=True;";
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
            modelBuilder.Entity<Gebruiker>()
                .HasData(gebruiker1);
            modelBuilder.Entity<Product>()
                .HasData(product1);

        }
    }
}
