using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }

        [Required]
        //public List<int>? OrderLineIDs { get; set; } hoeft niet
        public virtual List<OrderLine>? OrderLines { get; set; }

        public double? TotalPrice {  get; set; }

        public DateTime? OrderDate { get; set; }

        public bool? Completed { get; set; }

    }
}
