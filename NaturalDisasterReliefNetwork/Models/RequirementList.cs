using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalDisasterReliefNetwork.Models
{
    public class RequirementList
    {
        public int Id { get; set; }
        public int Priority { get; set; }
        public int Quantitiy { get; set; }
        public int status { get; set; }

        public DateTime createdDate { get; set; }

        public DateTime endDate { get; set; }

        [ForeignKey("User")]
        public int userID { get; set; }

        public User? User { get; set; }
        [ForeignKey("Addresses")]
        public int addressId { get; set; }
        public Addresses? Addresses { get; set; }
       
        [ForeignKey("Materials")]
        public int materialId { get; set; }
        public Materials? Materials { get; set; }
        

        public RequirementList()
        {
            createdDate = DateTime.Now;
        }
       
    }
}
