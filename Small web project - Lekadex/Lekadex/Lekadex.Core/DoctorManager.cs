using Lekadex.Core.DTOs;
using Lekadex.Core.Mappers;
using Lekadex.Database;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Lekadex.Core
{

    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepostiory _DoctorRepostiory;
        private readonly IMedicineRepository _MedicineRepostiory;
        private readonly IPrescriptionRepository _PrescriptionRepository;
        private readonly DTOMapper _DoctorsMapper;

        public DoctorManager(IDoctorRepostiory doctorRepository, IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository, DTOMapper docmap)
        {
            _DoctorRepostiory = doctorRepository;
            _PrescriptionRepository = prescriptionRepository;
            _MedicineRepostiory = medicineRepository;
            _DoctorsMapper = docmap;
        }

        public List<DoctorDto> GetAllDoctors(string filter)
        {
            var doctorEntities = _DoctorRepostiory.GetAllDoctors().ToList();
            if (!string.IsNullOrEmpty(filter))
            {
                doctorEntities = doctorEntities.Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter)).ToList();
            }
            return _DoctorsMapper.Map(doctorEntities);
        }

        public List<PrescriptionDto> GetAllPrescriptionsForADoctor(int doctorId, string filter)
        {
            var prescriptionsEntities = _PrescriptionRepository.GetAllPrescriptions().Where(x => x.DoctorId == doctorId).ToList(); //Trzeba jeszcze zawęźić te doctor ID's
            if (!string.IsNullOrEmpty(filter))
            {
                prescriptionsEntities = prescriptionsEntities.Where(x => x.Name.Contains(filter)).ToList();
            }
            return _DoctorsMapper.Map(prescriptionsEntities); //Są tam też inne mappery
        }

        public List<MedicineDto> GetAllMedicinesForAPrescription(int prescriptionId, string filter)
        {
            var medicinesEntities = _MedicineRepostiory.GetAllMedicines().Where(x => x.PrescriptionId == prescriptionId).ToList(); //Trzeba jeszcze zawęźić te doctor ID's
            if (!string.IsNullOrEmpty(filter))
            {
                medicinesEntities = medicinesEntities.Where(x => x.ActiveSubstance.Contains(filter) || x.Name.Contains(filter) || x.CompanyName.Contains(filter)).ToList();
            }
            return _DoctorsMapper.Map(medicinesEntities); //Są tam też inne mappery
        }

        public void AddNewMedicine(MedicineDto medicine, int prescriptionId)
        {
            var entity = _DoctorsMapper.Map(medicine);

            entity.PrescriptionId = prescriptionId;

            _MedicineRepostiory.AddNew(entity);
        }

        public void AddNewPrescription(PrescriptionDto prescription, int doctorsId)
        {
            var entity = _DoctorsMapper.Map(prescription);

            entity.DoctorId = doctorsId;

            _PrescriptionRepository.AddNew(entity);
        }

        public void AddNewDoctor(DoctorDto doctor)
        {
            var entity = _DoctorsMapper.Map(doctor);

            _DoctorRepostiory.AddNew(entity);
        }

        public bool DeleteMedicine(MedicineDto medicine)
        {
            var entity = _DoctorsMapper.Map(medicine);

            return _MedicineRepostiory.Delete(entity);
        }

        public bool DeletePrescription(PrescriptionDto prescription)
        {
            var entity = _DoctorsMapper.Map(prescription);
            return _PrescriptionRepository.Delete(entity);
        }

        public void DeleteDoctor(DoctorDto doctor)
        {
            var entity = _DoctorsMapper.Map(doctor);

            _DoctorRepostiory.Delete(entity);
        }
    }
}
