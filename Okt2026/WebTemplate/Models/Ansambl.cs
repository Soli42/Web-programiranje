using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Ansambl
    {
        [Key]

        public int ID { get; set; }

        public required string Naziv { get; set; }

        [JsonIgnore]
        public List<Clanovi>? Clanovi { get; set; }

    }
}