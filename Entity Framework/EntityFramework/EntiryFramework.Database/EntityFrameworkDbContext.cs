using Microsoft.EntityFrameworkCore;

namespace EntiryFramework.Database
{
    public class EntityFrameworkDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public EntityFrameworkDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
