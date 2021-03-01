using Lekadex.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lekadex.Core.DTOs
{
    class DoctorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkYears { get; set; }
        public bool IsAbleToMakePrescriptions { get; set; }
        public List<PrescriptionDto> PresiptionsList { get; set; }
    }
}
