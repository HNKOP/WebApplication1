using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.DAL
{
    public class WebApplicationContext : DbContext
    {
        public WebApplicationContext(DbContextOptions<WebApplicationContext> options)
            : base(options)
        {   
            Database.EnsureCreatedAsync();
        }

        public DbSet<DataEntity> DataEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DataEntity>()
                .HasKey(e => e.Id);
        }
    }
}
