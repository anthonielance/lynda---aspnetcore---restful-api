using LandonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LandonAPI
{
    public class HotelApiContext : DbContext
    {
        public HotelApiContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<RoomEntity> Rooms { get; set; }
    }
}
