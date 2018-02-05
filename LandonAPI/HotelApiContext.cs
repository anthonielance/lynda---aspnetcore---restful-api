using LandonAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace LandonAPI
{
    public class HotelApiContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public HotelApiContext(DbContextOptions options)
            : base(options) { }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
    }
}
