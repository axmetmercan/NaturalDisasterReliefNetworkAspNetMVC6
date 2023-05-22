using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalDisasterReliefNetwork.Models
{
    public class Addresses
    {
        public int Id { get; set; }
        public string? FullAddress { get; set; }

        // Şehirler ve İlçeler Fk olarak gelcek

        public int CityId { get; set; }
        public Cities? Citiy { get; set; }


        [ForeignKey("Cities")]
        public int CountyId { get; set; }
        public Counties? County { get; set; }

    }
}
