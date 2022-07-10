
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Models
{
    public class Entity:IdentityDbContext<ApplicationUser>
    {

        public Entity() : base()
        {

        }

        public Entity(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<RoomType> RoomTypes { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<HotelBranch> HotelBranches { get; set; }


    }
}
