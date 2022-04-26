using DornadzorTestWebApi.DAL.Entity;
using Microsoft.EntityFrameworkCore;


namespace DornadzorTestWebApi.DAL
{
    public class DornadzorContext: DbContext 
    {
        public DornadzorContext(DbContextOptions<DornadzorContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(
                new Role[]
                {
                    new Role() { Id = 1, Name ="USer"},
                    new Role() { Id = 2, Name ="Admin"}
                });
        }
    }
}
