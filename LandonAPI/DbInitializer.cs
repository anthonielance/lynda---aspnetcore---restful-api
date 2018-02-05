using LandonAPI.Models;
using LandonAPI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LandonAPI
{
    public static class DbInitializer
    {
        public static void Initialize(HotelApiContext context, IDateLogicService dateLogicService)
        {
            context.Database.EnsureCreated();

            if (context.Rooms.Any()) return;

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9195976"),
                Name = "Driscoll Suite",
                Rate = 23959
            });

            var oxford = context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("301df04d-8679-4b1b-ab92-0a586ae53d08"),
                Name = "Oxford Suite",
                Rate = 10119
            }).Entity;

            var today = DateTimeOffset.Now;
            var start = dateLogicService.AlignStartTime(today);
            var end = start.Add(dateLogicService.GetMinimumStay());

            context.Bookings.Add(new BookingEntity
            {
                Id = Guid.Parse("2eac8dea-2749-42b3-9d21-8eb2fc0fd6bd"),
                Room = oxford,
                CreatedAt = DateTimeOffset.UtcNow,
                StartAt = start,
                EndAt = end,
                Total = oxford.Rate,
            });

            context.SaveChanges();
        }

        public static async Task InitializeUsers(RoleManager<UserRoleEntity> roleManager, UserManager<UserEntity> userManager)
        {
            // Add a test role
            await roleManager.CreateAsync(new UserRoleEntity("Admin"));

            // Add a test user
            var user = new UserEntity
            {
                Email = "admin@landon.local",
                UserName = "admin@landon.local",
                FirstName = "Admin",
                LastName = "Testerman",
                CreatedAt = DateTimeOffset.UtcNow
            };

            await userManager.CreateAsync(user,"Supersecret123!");

            // Put the user in the admin role
            await userManager.AddToRoleAsync(user, "Admin");
            await userManager.UpdateAsync(user);
        }

        public static IWebHost UseDatabaseInitializer(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var roleManager = services.GetRequiredService<RoleManager<UserRoleEntity>>();
                    var userManager = services.GetRequiredService<UserManager<UserEntity>>();
                    InitializeUsers(roleManager, userManager).Wait();

                    var context = services.GetRequiredService<HotelApiContext>();
                    var dateLogicService = services.GetRequiredService<IDateLogicService>();
                    Initialize(context, dateLogicService);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            return host;
        }
    }
}
