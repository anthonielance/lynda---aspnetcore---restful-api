using LandonAPI.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LandonAPI.Services
{
    public interface IRoomService
    {
        Task<Room> GetRoomAsync(
            Guid id,
            CancellationToken ct);

        Task<PagedResults<Room>> GetRoomsAsync(
            PagingOptions pagingOptions,
            SortOptions<Room, RoomEntity> sortOptions,
            SearchOptions<Room, RoomEntity> searchOptions,
            CancellationToken ct);
    }
}
