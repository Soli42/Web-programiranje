using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Spoj
    {
        [Key]

        public int ID { get; set; }
        
        public Korisnik? Korisnik  { get; set; }

        public Automobili? Automobili {get; set;}

        public required int  BrDana { get; set; }



    }
}