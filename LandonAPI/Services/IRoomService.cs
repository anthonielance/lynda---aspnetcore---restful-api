using LandonAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LandonAPI.Services
{
    public interface IRoomService
    {
        Task<Room> GetRoomAsync(Guid id, CancellationToken ct);
        Task<IEnumerable<Room>> GetRoomsAsync(CancellationToken ct);
    }
}
