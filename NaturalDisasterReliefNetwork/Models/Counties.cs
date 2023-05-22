using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalDisasterReliefNetwork.Models
{
    public class Counties
    {

        public int? Id { get; set; }
        public string? County { get; set; }

        [ForeignKey("Cities")]
        public int CityId { get; set; }
        public Cities? City { get; set; }
    }
}
