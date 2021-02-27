using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace WpfApp2.Database
{
    public class WpfApp2DbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"databaseForWPF.sqlite")}");
        }
    }
}
