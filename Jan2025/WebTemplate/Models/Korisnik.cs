using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Korisnik
    {
        [Key]

        public int ID { get; set; }

        public required string ImePrezime { get; set; }

        [StringLength(13, MinimumLength = 13)]
        [RegularExpression(@"^[0-9]{13}$")]
        public required string JMBG { get; set; }

        [StringLength(9, MinimumLength = 9)]
        public required  string BrVozake { get; set; }

        [JsonIgnore]
        public List<Spoj>? Spoj { get; set; }
    }
}