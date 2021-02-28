using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntiryFramework.Database
{
    public class EntityFrameworkDbContext : IdentityDbContext<ApplicationUser>
    {
        public EntityFrameworkDbContext(DbContextOptions<EntityFrameworkDbContext> options) : base(options)
        {

        }

        public DbSet<Setting> Settings { get; set; }

        //Fluent API
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Setting>(config =>
            {
                config.HasOne(x => x.User);

            });

            builder.Entity<ApplicationUser>(config =>
            {
                config.HasMany(x => x.SettingList);

            });

            builder.Entity<ApplicationUser>(config =>
            {
                config.Property(x => x.PhoneNumber).IsRequired();

            });


            builder.Entity<Setting>(config =>
            {
                config.Property(x => x.Name).HasMaxLength(100);

            });
        }
    }
}
