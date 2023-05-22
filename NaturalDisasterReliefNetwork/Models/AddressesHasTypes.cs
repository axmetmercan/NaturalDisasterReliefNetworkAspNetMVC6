using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalDisasterReliefNetwork.Models
{
    public class AddressesHasTypes
    {
        public int Id { get; set; }
        [ForeignKey("Types")]
        public int typesId { get; set; }
        public Types? type { get; set; }
        [ForeignKey("Addresses")]
        public int addressId { get; set; }
        public Addresses? address { get; set; }
        [ForeignKey("Cities")]
        public int? CityId { get; set; }
        public Cities City { get; set; }
        [ForeignKey("Counties")]
        public int? CountyId { get; set; }
        public Counties county { get; set; }


    }
}
