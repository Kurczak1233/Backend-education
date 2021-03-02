using AutoMapper;
using Lekadex.Core.DTOs;
using Lekadex.Database;
using System.Collections.Generic;

namespace Lekadex.Core.Mappers
{
    public class DoctorsMapper
    {
        private IMapper _Mapper;

        public DoctorsMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Medicine, MedicineDto>()
                .ForMember(x => x.PriceInTotal, opt => opt.MapFrom(y => y.Price * y.Amount))
                .ReverseMap();
                config.CreateMap<Prescription, PrescriptionDto>()
                .ReverseMap();
                config.CreateMap<Doctor, DoctorDto>()
                .ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Mapper
        public MedicineDto Map(Medicine medicine) => _Mapper.Map<MedicineDto>(medicine);
        public IEnumerable<MedicineDto> Map(IEnumerable<Medicine> medicines) => _Mapper.Map<IEnumerable<MedicineDto>>(medicines);
        public Medicine Map(MedicineDto medicine) => _Mapper.Map<Medicine>(medicine);
        public IEnumerable<Medicine> Map(IEnumerable<MedicineDto> medicines) => _Mapper.Map<IEnumerable<Medicine>>(medicines);
        #endregion
        #region Doctor Mapper
        public DoctorDto Map(Doctor doctor) => _Mapper.Map<DoctorDto>(doctor);
        public IEnumerable<DoctorDto> Map(IEnumerable<Doctor> doctors) => _Mapper.Map<IEnumerable<DoctorDto>>(doctors);
        public Doctor Map(DoctorDto doctor) => _Mapper.Map<Doctor>(doctor);
        public IEnumerable<Doctor> Map(IEnumerable<DoctorDto> doctors) => _Mapper.Map<IEnumerable<Doctor>>(doctors);
        #endregion
        #region Prescription Mapper

        public PrescriptionDto Map(Prescription prescription) => _Mapper.Map<PrescriptionDto>(prescription);
        public IEnumerable<PrescriptionDto> Map(IEnumerable<Prescription> prescriptions) => _Mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
        public Prescription Map(PrescriptionDto prescription) => _Mapper.Map<Prescription>(prescription);
        public IEnumerable<Prescription> Map(IEnumerable<PrescriptionDto> prescriptions) => _Mapper.Map<IEnumerable<Prescription>>(prescriptions);
        #endregion
    }
}
