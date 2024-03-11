
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BaseLibrary.Entities
{
    public class Employee : BaseEntity

    {
        [Required]
        public string? CivilId { get; set; }
        [Required]
        public string? FileNumber { get; set;}
   
        [Required]
        public string? JobName{ get; set; }
        [Required]
        public string? Address { get; set;}
        [Required]
        public string? TelephoneNumber{ get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string Photo { get; set; } = string.Empty;
        public string? Other { get; set;} 

        //Relationship: Many to One with Branch
        public Branch? Branch { get; set; }
        public int BranchId { get; set; }   
        //Relationship Many to one with Town
        public Town? Town { get; set; }
        public int TownId { get; set;}

    }
}
