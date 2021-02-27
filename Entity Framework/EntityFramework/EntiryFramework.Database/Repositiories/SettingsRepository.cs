using EntiryFramework.Database.Repositiories.BaseRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntiryFramework.Database
{
    public class SettingsRepository : BaseRepostirory<Setting>, ISettingsRepository
    {
        protected override DbSet<Setting> DbSet => _db.Settings;
        public SettingsRepository(EntityFrameworkDbContext dbContext) : base(dbContext) { }

        public void UpdateSettings(Setting setting)
        {
            var foundSetting = DbSet.Where(c => c.Id == setting.Id).FirstOrDefault();
            if (foundSetting == null)
            {
                DbSet.Add(setting);
                SaveChanges();
                return;
            }
            else
            {
                foundSetting.Name = setting.Name;
                foundSetting.Value = setting.Value;
                SaveChanges();
                return;
            }
        }

        public Setting GetSettingByName(string name)
        {
            var foundSetting = DbSet.Where(c => c.Name == name).FirstOrDefault();
            return foundSetting;
        }
    }
}
