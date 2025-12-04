namespace FestivalCompanion.Models
{
    public class User
    {
        public int Gebruiker_ID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public DateOnly Leeftijd { get; set; }
        public required string Wachtwoord { get; set; }

        // DIT IS DE HASH: Zorgt dat er nooit een plaintext wachtwoord in de database staat
    }
}
