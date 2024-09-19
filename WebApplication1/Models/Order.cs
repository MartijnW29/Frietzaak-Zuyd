using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required]
        public int GebruikerID { get; set; }
        public virtual Gebruiker Gebruiker { get; set; } = null!;

        [Required]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; } = null!;

        public double Totaalprijs {  get; set; }
    }
}
