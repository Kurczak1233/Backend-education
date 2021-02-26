using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntiryFramework.Database
{
    public class EntityFrameworkDbContext : IdentityDbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public EntityFrameworkDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
