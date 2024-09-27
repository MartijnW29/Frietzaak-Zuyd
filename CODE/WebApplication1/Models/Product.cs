namespace WebApplication1.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string? ProductNaam { get; set; }

        public string? ProductBeschrijving { get; set; }

        public double ProductPrijs {  get; set; }

        public List<int>? OrderlineID { get; set; }
        public List<OrderLine>? Orderlines { get; set; }
    }
}
