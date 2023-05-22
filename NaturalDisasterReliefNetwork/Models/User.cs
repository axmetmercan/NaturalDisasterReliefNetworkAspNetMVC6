using System.ComponentModel.DataAnnotations.Schema;

namespace NaturalDisasterReliefNetwork.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }

        public string? Email { get; set; } 
        public string? Phone { get; set; }
        public string? Password { get; set; }

        // Requirement list fk olarak gelcek

        [ForeignKey("Authority")]
        public int authorityID { get; set; }
        public Authority? authority { get; set; }
    }
}
