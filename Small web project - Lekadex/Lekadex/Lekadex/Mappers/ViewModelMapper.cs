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
        public IEnumerable<MedicineViewModel> Map(IEnumerable<MedicineDto> medicines) => _Mapper.Map<IEnumerable<MedicineViewModel>>(medicines);
        public MedicineDto Map(MedicineViewModel medicine) => _Mapper.Map<MedicineDto>(medicine);
        public IEnumerable<MedicineDto> Map(IEnumerable<MedicineViewModel> medicines) => _Mapper.Map<IEnumerable<MedicineDto>>(medicines);
        #endregion
        #region Doctor Mapper
        public DoctorViewModel Map(DoctorDto doctor) => _Mapper.Map<DoctorViewModel>(doctor);
        public IEnumerable<DoctorViewModel> Map(IEnumerable<DoctorDto> doctors) => _Mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
        public DoctorDto Map(DoctorViewModel doctor) => _Mapper.Map<DoctorDto>(doctor);
        public IEnumerable<DoctorDto> Map(IEnumerable<DoctorViewModel> doctors) => _Mapper.Map<IEnumerable<DoctorDto>>(doctors);
        #endregion
        #region Prescription Mapper

        public PrescriptionViewModel Map(PrescriptionDto prescription) => _Mapper.Map<PrescriptionViewModel>(prescription);
        public IEnumerable<PrescriptionViewModel> Map(IEnumerable<PrescriptionDto> prescriptions) => _Mapper.Map<IEnumerable<PrescriptionViewModel>>(prescriptions);
        public PrescriptionDto Map(PrescriptionViewModel prescription) => _Mapper.Map<PrescriptionDto>(prescription);
        public IEnumerable<PrescriptionDto> Map(IEnumerable<PrescriptionViewModel> prescriptions) => _Mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
        #endregion
    }
}
