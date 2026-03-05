using Microsoft.EntityFrameworkCore;
using ServerManagement.Data;
using ServerManagement.Models;

namespace ServerManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }
       

        public virtual DbSet<Server> Servers { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Server>().HasData(
                new Server { Id = 1, Name = "Server 1", CityId = 1, IsOnline = true },
                new Server { Id = 2, Name = "Server 2", CityId = 1, IsOnline = false },
                new Server { Id = 3, Name = "Server 3", CityId = 1, IsOnline = false },
                new Server { Id = 4, Name = "Server 4", CityId = 1, IsOnline = true },
                new Server { Id = 5, Name = "Server 5", CityId = 2, IsOnline = true },
                new Server { Id = 6, Name = "Server 6", CityId = 2, IsOnline = false },
                new Server { Id = 7, Name = "Server 7", CityId = 2, IsOnline = true },
                new Server { Id = 8, Name = "Server 8", CityId = 2, IsOnline = true },
                new Server { Id = 9, Name = "Server 9", CityId = 3, IsOnline = false },
                new Server { Id = 10, Name = "Server 10", CityId = 3, IsOnline = false },
                new Server { Id = 11, Name = "Server 11", CityId = 3, IsOnline = true },
                new Server { Id = 12, Name = "Server 12", CityId = 4, IsOnline = false },
                new Server { Id = 13, Name = "Server 13", CityId = 3, IsOnline = true },
                new Server { Id = 14, Name = "Server 14", CityId = 4, IsOnline = false },
                new Server { Id = 15, Name = "Server 15", CityId = 1, IsOnline = true }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Nashville" },
                new City { Id = 2, Name = "Nolensville" },
                new City { Id = 3, Name = "Franklin" },
                new City { Id = 4, Name = "Knoxville" }
            );
            modelBuilder.Entity<City>()
                .HasMany(s => s.Servers)
                .WithOne(c => c.City)
                .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<Server>()
                .HasOne(c => c.City)
                .WithMany(s => s.Servers)
                .HasForeignKey(s => s.CityId);

            // Additional model configuration can go here
        }
    }
    
}
