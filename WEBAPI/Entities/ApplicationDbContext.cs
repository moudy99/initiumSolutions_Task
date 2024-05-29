using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI.Entities
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<HotelBranch> HotelBranches { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HotelBranch>().HasData(
                new HotelBranch
                {
                    ID = 1,
                    Name = "Conrad Cairo",
                    Location = "1191 Nile Corniche, Cairo, Egypt"
                },
                new HotelBranch
                {
                    ID = 2,
                    Name = "Fairmont Nile City",
                    Location = "Nile City Towers "
                },
                new HotelBranch
                {
                    ID = 3,
                    Name = "Kempinski Nile Hotel Cairo",
                    Location = "12 Ahmed Ragheb St, Cairo, Egypt"
                },
                new HotelBranch
                {
                    ID = 4,
                    Name = "InterContinental Cairo Semiramis",
                    Location = " Garden City, Cairo, Egypt"
                },
                new HotelBranch
                {
                    ID = 5,
                    Name = "Four Seasons Hotel ",
                    Location = " , Cairo, Egypt"
                },
                new HotelBranch
                {
                    ID = 6,
                    Name = "Ramses Hilton",
                    Location = "1115 , Cairo, Egypt"
                }
            );
        }
    }
}
