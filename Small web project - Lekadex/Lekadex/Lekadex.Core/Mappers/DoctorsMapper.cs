using AutoMapper;
using Lekadex.Core.DTOs;
using Lekadex.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lekadex.Core.Mappers
{
    public class DoctorsMapper
    {
        private IMapper _mapper;

        public DoctorsMapper()
        {
            _mapper = new MapperConfiguration(config => {
                config.CreateMap<Medicine, MedicineDto>().ForMember(x=>x.PriceInTotal, opt=>opt.MapFrom(y=>y.Price*y.Amount)).ReverseMap();
                config.CreateMap<Prescription,PrescriptionDto>().ReverseMap();
                config.CreateMap<Doctor, DoctorDto>().ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Maps
        public MedicineDto Map(Medicine medicine) => _mapper.Map<MedicineDto>(medicine);
        public IEnumerable<MedicineDto> Map(IEnumerable<Medicine> medicines) => _mapper.Map<IEnumerable<MedicineDto>>(medicines);    
        public Medicine Map(MedicineDto medicine) => _mapper.Map<Medicine>(medicine);
        public IEnumerable<Medicine> Map(IEnumerable<MedicineDto> medicines) => _mapper.Map<IEnumerable<Medicine>>(medicines);

        #endregion
        #region Prescription Maps
        public PrescriptionDto Map(Prescription prescription) => _mapper.Map<PrescriptionDto>(prescription);
        public IEnumerable<PrescriptionDto> Map(IEnumerable<Prescription> prescriptions) => _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
        public Prescription Map(PrescriptionDto prescription) => _mapper.Map<Prescription>(prescription);
        public IEnumerable<Prescription> Map(IEnumerable<PrescriptionDto> prescriptions) => _mapper.Map<IEnumerable<Prescription>>(prescriptions);
        #endregion
        #region Doctor Maps

        public DoctorDto Map(Doctor doctor) => _mapper.Map<DoctorDto>(doctor);
        public IEnumerable<DoctorDto> Map(IEnumerable<Doctor> doctors) => _mapper.Map<IEnumerable<DoctorDto>>(doctors);
        public Doctor Map(DoctorDto doctor) => _mapper.Map<Doctor>(doctor);
        public IEnumerable<Doctor> Map(IEnumerable<DoctorDto> doctors) => _mapper.Map<IEnumerable<Doctor>>(doctors);
        #endregion
    }
} 
