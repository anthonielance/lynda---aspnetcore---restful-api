using LandonAPI.Models;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LandonAPI.Services
{
    public interface IUserService
    {
        Task<PagedResults<User>> GetUsersAsync(
            PagingOptions pagingOptions,
            SortOptions<User, UserEntity> sortOptions,
            SearchOptions<User, UserEntity> searchOptions,
            CancellationToken ct);

        Task<(bool Succeeded, string Errors)> CreateUserAsync(RegisterForm form);
        Task<User> GetUsersAsync(ClaimsPrincipal user);
    }
}
