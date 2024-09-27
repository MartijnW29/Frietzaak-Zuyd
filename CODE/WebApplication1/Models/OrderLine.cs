namespace WebApplication1.Models
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }

        public virtual string? ProductID { get; set; }
        public Product? Product { get; set; }

        public virtual string? OrderID { get; set; }
        public Order? Order { get; set; }

        public int? PoductAmount { get; set; }
        public int? Productprijs {  get; set; }

    }
}
