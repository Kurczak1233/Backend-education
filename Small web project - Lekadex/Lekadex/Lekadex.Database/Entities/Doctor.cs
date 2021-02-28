using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lekadex.Database
{
    public class Doctor : BaseEntity
    {

        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkYears { get; set; }
        public bool IsAbleToMakePrescriptions { get; set; }

        [NotMapped]
        public virtual List<Prescription> PresiptionsList { get; set; }
    }
}
