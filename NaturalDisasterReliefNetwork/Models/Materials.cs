using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalDisasterReliefNetwork.Models
{
    public class Materials
    {
        public int id {  get; set; }

        public string? Name { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Categories? Categories { get; set; }
    }
}
