using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lekadex.Database
{
    public class Prescription : BaseEntity
    {

        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [NotMapped]
        public virtual List<Medicine> MedicinesList {get; set;}
    }
}
