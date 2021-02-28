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

        public void DoSth()
        {
            var foundSth = DbSet.Where(x => x.Id > 3).Select(x=>x.Value); //Select wybiera tylko kolumnę nie cała encję.
            var foundSth2 = DbSet.Where(x => x.Id > 3).Select(x => new { 
            NameXXX = x.Name,
            ValueXXX = x.Value}); //Obiekt anonimowy
        }
    }
}
