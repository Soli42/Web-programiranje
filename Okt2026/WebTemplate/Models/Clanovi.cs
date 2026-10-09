namespace WebTemplate.Models
{
    public class Clanovi
    {
        [Key]

        public int ID { get; set; }

        public required string Ime { get; set; }

        public required int Visina { get; set; }

        public required int BrGodineIskustva { get; set; }

        public Ansambl? Ansambl { get; set; }
    }
}