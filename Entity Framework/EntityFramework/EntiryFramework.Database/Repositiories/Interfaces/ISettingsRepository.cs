﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EntiryFramework.Database
{
    public interface ISettingsRepository
    {
        List<Setting> GetAll();
        public void UpdateSettings(Setting setting);
        public Setting GetSettingByName(string name);
        void SaveChanges();
    }
}
