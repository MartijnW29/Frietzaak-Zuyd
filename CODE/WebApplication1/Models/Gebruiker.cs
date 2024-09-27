namespace WebApplication1.Models
{
    public class Gebruiker
    {
        public int GebruikerID {  get; set; }
        public string? Gebruikersnaam {  get; set; }

        public string? Plaats {  get; set; }

        public string? Straat {  get; set; }

        public string? Huisnummer { get; set; }

        public string? HuisnummerToevoeging { get; set; }

        public string? Emailadres {  get; set; }

        public string? Telefoonnummer { get; set; }


        public List<int>? OrderIDs { get; set; }
        public List<Order>? Orders { get; set; }
    }
}
