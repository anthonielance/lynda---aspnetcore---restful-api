using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LandonAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .UseDatabaseInitializer()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
