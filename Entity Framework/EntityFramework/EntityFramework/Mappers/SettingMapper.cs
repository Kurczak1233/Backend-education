using AutoMapper;
using EntiryFramework.Database;

namespace EntityFramework
{
    public class SettingMapper
    {
        private IMapper _Mapper;

        public SettingMapper()
        {
            _Mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Setting, SettingDataModel>().ReverseMap();
            }).CreateMapper();
        }
        public SettingDataModel Map(Setting setting)
        {
            return _Mapper.Map<SettingDataModel>(setting);
        }
    }
}
