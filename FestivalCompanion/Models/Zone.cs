namespace FestivalCompanion.Models
{
    public class Zone
    {
        public int Zone_ID { get; set; }
        public string Naam { get; set; }
        public decimal Lengtegraad { get; set; }
        public decimal Breedtegraad { get; set; }
        public string Grootte { get; set; }
        public List<Location> Locatie { get; set; }

    }
}
