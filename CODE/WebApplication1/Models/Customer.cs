namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id {  get; set; }
        public string? Name {  get; set; }

        public string? Place {  get; set; }

        public string? Street {  get; set; }

        public string? HomeNumber { get; set; }

        public string? HomeNumberAddition { get; set; }

        public string? Email {  get; set; }

        public string? PhoneNumber { get; set; }


        //public List<int>? OrderIDs { get; set; } hoeft niet
        public List<Order>? Orders { get; set; }
    }
}
