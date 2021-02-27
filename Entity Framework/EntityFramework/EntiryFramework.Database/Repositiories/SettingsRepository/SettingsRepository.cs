using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntiryFramework.Database.Repositiories.SettingsRepository
{
    public  class SettingsRepository
    {
        private readonly EntityFrameworkDbContext _db;
        private DbSet<Setting> DbSet => _db.Settings; //Relacja Settings
        public SettingsRepository(EntityFrameworkDbContext dbContext)
        {
            _db = dbContext;
        }
        public List<Setting> GetAllSettings()
        {
            var list = new List<Setting>();
            //var list2 = await _db.Settings.ToListAsync(); Simplier?
            var settings = DbSet; //Wszystkie settingi się tutaj znajdą.
            foreach(var setting in settings)
            {
                list.Add(setting);
            }
            return list;
        }

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

        public void SaveChanges()
        {
            _db.SaveChangesAsync();
        }
    }
}
