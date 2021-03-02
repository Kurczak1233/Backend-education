using Lekadex.Core.DTOs;
using System.Collections.Generic;

namespace Lekadex.Core
{
    public interface IDoctorManager
    {
        void AddNewMedicine(MedicineDto medicine, int prescriptionId);
        void AddNewDoctor(DoctorDto doctor);
        void AddNewPrescription(PrescriptionDto prescription, int doctorsId);
        bool DeleteMedicine(MedicineDto medicine);
        void DeleteDoctor(DoctorDto doctor);
        bool DeletePrescription(PrescriptionDto prescription);
        List<DoctorDto> GetAllDoctors(string filter);
        List<MedicineDto> GetAllMedicinesForAPrescription(int prescriptionId, string filter);
        List<PrescriptionDto> GetAllPrescriptionsForADoctor(int doctorId, string filter);
    }
}
