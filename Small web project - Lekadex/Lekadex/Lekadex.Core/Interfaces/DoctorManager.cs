using Lekadex.Core.DTOs;
using System.Collections.Generic;

namespace Lekadex.Core
{
    public interface IDoctorManager
    {
        void AddNewMedicine(MedicineDto medicine, int prescriptionId);
        void AddNewPrescription(DoctorDto doctor);
        void AddNewPrescription(PrescriptionDto prescription, int doctorsId);
        bool DeleteMedicine(MedicineDto medicine);
        void DeletePrescription(DoctorDto doctor);
        bool DeletePrescription(PrescriptionDto prescription);
        IEnumerable<DoctorDto> GetAllDoctors(string filter);
        IEnumerable<MedicineDto> GetAllMedicinesForAPrescription(int prescriptionId, string filter);
        IEnumerable<PrescriptionDto> GetAllPrescriptionsForADoctor(int doctorId, string filter);
    }
}
