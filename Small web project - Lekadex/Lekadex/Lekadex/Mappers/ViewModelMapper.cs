using AutoMapper;
using Lekadex.Core.DTOs;
using System.Collections.Generic;

namespace Lekadex
{
    public class ViewModelMapper
    {
        private IMapper _Mapper;

        public ViewModelMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<MedicineDto, MedicineViewModel>()
                .ReverseMap();
                config.CreateMap<PrescriptionDto, PrescriptionViewModel>()
                .ReverseMap();
                config.CreateMap<DoctorDto, DoctorViewModel>()
                .ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Mapper
        public MedicineViewModel Map(MedicineDto medicine) => _Mapper.Map<MedicineViewModel>(medicine);
        public List<MedicineViewModel> Map(List<MedicineDto> medicines) => _Mapper.Map<List<MedicineViewModel>>(medicines);
        public MedicineDto Map(MedicineViewModel medicine) => _Mapper.Map<MedicineDto>(medicine);
        public List<MedicineDto> Map(List<MedicineViewModel> medicines) => _Mapper.Map<List<MedicineDto>>(medicines);
        #endregion
        #region Doctor Mapper
        public DoctorViewModel Map(DoctorDto doctor) => _Mapper.Map<DoctorViewModel>(doctor);
        public List<DoctorViewModel> Map(List<DoctorDto> doctors) => _Mapper.Map<List<DoctorViewModel>>(doctors);
        public DoctorDto Map(DoctorViewModel doctor) => _Mapper.Map<DoctorDto>(doctor);
        public List<DoctorDto> Map(List<DoctorViewModel> doctors) => _Mapper.Map<List<DoctorDto>>(doctors);
        #endregion
        #region Prescription Mapper

        public PrescriptionViewModel Map(PrescriptionDto prescription) => _Mapper.Map<PrescriptionViewModel>(prescription);
        public List<PrescriptionViewModel> Map(List<PrescriptionDto> prescriptions) => _Mapper.Map<List<PrescriptionViewModel>>(prescriptions);
        public PrescriptionDto Map(PrescriptionViewModel prescription) => _Mapper.Map<PrescriptionDto>(prescription);
        public List<PrescriptionDto> Map(List<PrescriptionViewModel> prescriptions) => _Mapper.Map<List<PrescriptionDto>>(prescriptions);
        #endregion
    }
}
