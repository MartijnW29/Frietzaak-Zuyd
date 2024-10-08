﻿namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Price {  get; set; }

        public List<OrderLine>? Orderlines { get; set; }
    }
}
