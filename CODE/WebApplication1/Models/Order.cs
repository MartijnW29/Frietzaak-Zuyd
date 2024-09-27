using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        public int GebruikerID { get; set; }
        public virtual Gebruiker? Gebruiker { get; set; }

        [Required]
        public List<int>? OrderLineIDs { get; set; }
        public virtual List<OrderLine>? OrderLine { get; set; }

    }
}
