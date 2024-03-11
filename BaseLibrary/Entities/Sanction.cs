
using System.ComponentModel.DataAnnotations;

namespace BaseLibrary.Entities
{
    public class Sanction : TableEntityBase
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Punishment {  get; set; }= string.Empty;
        [Required]
        public DateTime PunishmentDate { get; set; }

        //Many to one relationship with sanction type
        public SanctionType? SanctionType { get; set; }

        public int SanctionTypeId { get; set; }
    }
}
