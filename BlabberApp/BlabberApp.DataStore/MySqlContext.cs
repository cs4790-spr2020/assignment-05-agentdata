using Microsoft.EntityFrameworkCore;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStore.Plugins
{
    public class MySqlContext : DbContext
    {
        public DbSet<Blab> Blab { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=142.93.114;database=agentdata;user=agentdata;password=letmein");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.LastLoginDTTM).IsRequired();
                entity.Property(e => e.RegisterDTTM).IsRequired();
            });

            modelBuilder.Entity<Blab>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DTTM).IsRequired();
                entity.Property(e => e.Message);
                entity.HasOne(u => u.User);
            });
        }
    }
}