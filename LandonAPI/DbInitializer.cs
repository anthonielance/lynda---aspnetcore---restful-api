using LandonAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace LandonAPI
{
    public static class DbInitializer
    {
        public static void Initialize(HotelApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Rooms.Any()) return;

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("301df04d-8679-4b1b-ab92-0a586ae53d08"),
                Name = "Oxford Suite",
                Rate = 10119
            });

            context.Rooms.Add(new RoomEntity
            {
                Id = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9195976"),
                Name = "Driscoll Suite",
                Rate = 23959
            });

            context.SaveChanges();
        }

        public static IWebHost UseDatabaseInitializer(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<HotelApiContext>();
                    Initialize(context);
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
