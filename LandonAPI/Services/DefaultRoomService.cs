using AutoMapper;
using LandonAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LandonAPI.Services
{
    public class DefaultRoomService : IRoomService
    {
        private HotelApiContext _context;

        public DefaultRoomService(HotelApiContext context)
        {
            _context = context;
        }

        public async Task<Room> GetRoomAsync(Guid id, CancellationToken ct)
        {
            var entity =  await _context.Rooms.SingleOrDefaultAsync(r => r.Id == id, ct);
            if (entity == null) return null;

            return Mapper.Map<Room>(entity);
        }
    }
}
