using EntiryFramework.Database;

namespace EntityFramework
{
    public class SettingMapper
    {
        public SettingDataModel Map(Setting setting)
        {
            return new SettingDataModel
            {
                Name = setting.Name,
                Value = setting.Value
            };
        }
    }
}
