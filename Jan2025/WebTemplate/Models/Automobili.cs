using System.Text.Json.Serialization;

namespace WebTemplate.Models
{
    public class Automobili
    {
        [Key]

        public int ID { get; set; }

        public required string Model { get; set; }

        public required int PredjenaKilometraza { get; set; }

        public required string Godiste { get; set; }

        public required int BrSedista { get; set; }

        public required int CenaPoDanu{ get; set; }

        public required bool Iznajmljen { get; set; } = false;

        [JsonIgnore]
        public List<Spoj>? Spoj { get; set; }


    }
}