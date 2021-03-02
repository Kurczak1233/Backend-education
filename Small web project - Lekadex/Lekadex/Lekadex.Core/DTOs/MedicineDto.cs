using System;

namespace Lekadex.Core.DTOs
{
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string ActiveSubstance { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
        public decimal PriceInTotal { get; set; }
        public int Amount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public  PrescriptionDto Prescription { get; set; }
    }
}
