using AutoMapper;
using Lekadex.Core.DTOs;
using Lekadex.Database;
using System.Collections.Generic;

namespace Lekadex.Core.Mappers
{
    public class DTOMapper
    {
        private readonly IMapper _Mapper;

        public DTOMapper()
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
        public List<MedicineDto> Map(List<Medicine> medicines) => _Mapper.Map<List<MedicineDto>>(medicines);
        public Medicine Map(MedicineDto medicine) => _Mapper.Map<Medicine>(medicine);
        public List<Medicine> Map(List<MedicineDto> medicines) => _Mapper.Map<List<Medicine>>(medicines);
        #endregion
        #region Doctor Mapper
        public DoctorDto Map(Doctor doctor) => _Mapper.Map<DoctorDto>(doctor);
        public List<DoctorDto> Map(List<Doctor> doctors) => _Mapper.Map<List<DoctorDto>>(doctors);
        public Doctor Map(DoctorDto doctor) => _Mapper.Map<Doctor>(doctor);
        public List<Doctor> Map(List<DoctorDto> doctors) => _Mapper.Map<List<Doctor>>(doctors);
        #endregion
        #region Prescription Mapper

        public PrescriptionDto Map(Prescription prescription) => _Mapper.Map<PrescriptionDto>(prescription);
        public List<PrescriptionDto> Map(List<Prescription> prescriptions) => _Mapper.Map<List<PrescriptionDto>>(prescriptions);
        public Prescription Map(PrescriptionDto prescription) => _Mapper.Map<Prescription>(prescription);
        public List<Prescription> Map(List<PrescriptionDto> prescriptions) => _Mapper.Map<List<Prescription>>(prescriptions);
        #endregion
    }
}
