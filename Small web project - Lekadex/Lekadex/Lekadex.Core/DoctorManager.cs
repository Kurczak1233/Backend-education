using Lekadex.Core.DTOs;
using Lekadex.Core.Mappers;
using Lekadex.Database;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Lekadex.Core
{
    public class DoctorManager
    {
        private readonly IDoctorRepostiory _DoctorRepostiory;
        private readonly IMedicineRepository _MedicineRepostiory;
        private readonly IPrescriptionRepository _PrescriptionRepository;
        private readonly DoctorsMapper _DoctorsMapper;

        public DoctorManager(IDoctorRepostiory doctorRepository, IPrescriptionRepository prescriptionRepository, IMedicineRepository medicineRepository, DoctorsMapper docmap)
        {
            _DoctorRepostiory = doctorRepository;
            _PrescriptionRepository = prescriptionRepository;
            _MedicineRepostiory = medicineRepository;
            _DoctorsMapper = docmap;
        }

        public IEnumerable<DoctorDto> GetAllDoctors(string filter)
        {
            var doctorEntities = _DoctorRepostiory.GetAllDoctors();
            if (string.IsNullOrEmpty(filter))
            {
                doctorEntities = doctorEntities.Where(x => x.FirstName.Contains(filter) || x.LastName.Contains(filter));
            }
            return _DoctorsMapper.Map(doctorEntities);
        }
    }
}
