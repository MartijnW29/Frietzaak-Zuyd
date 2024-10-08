namespace WebApplication1.Models
{
    public class OrderLine
    {
        public int Id { get; set; }

        public virtual int? ProductId { get; set; }
        public Product? Product { get; set; }

        public virtual int? OrderId { get; set; }
        public Order? Order { get; set; }

        public int? PoductAmount { get; set; }
        public int? ProductTotalprice {  get; set; }

    }
}
