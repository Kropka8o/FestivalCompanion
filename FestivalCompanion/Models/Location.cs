namespace FestivalCompanion.Models
{
    public class Location
    {
        public int Locatie_ID { get; set; }
        public int Zone_ID { get; set; }
        public Zone Zone { get; set; }
        public string Naam {  get; set; }
        public string Type { get; set; } // Could be an enum in the future
        public decimal Lengtegraad {  get; set; }
        public decimal Breedtegraad { get; set; }

    }
}
