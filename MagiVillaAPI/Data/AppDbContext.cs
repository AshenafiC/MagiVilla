using MagiVillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagiVillaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                { 
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "This is the detail of Royal Villa",
                    ImageUrl="",
                    Occupancy = 5,
                    Rate = 500,
                    Sqft = 800,
                    Amenity="",
                    CreatedDate = DateTime.Now,
                },
                new Villa
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    Details = "This is the detail of Premium Pool Villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 600,
                    Sqft = 900,
                    Amenity = "",
                    CreatedDate = DateTime.Now,
                },
                new Villa
                {
                    Id = 3,
                    Name = "Luxury Pool Villa",
                    Details = "This is the detail of Luxury Pool Villa",
                    ImageUrl = "",
                    Occupancy = 4,
                    Rate = 400,
                    Sqft = 700,
                    Amenity = "",
                   CreatedDate= DateTime.Now,
                }
                );
        }
    }
    
}
