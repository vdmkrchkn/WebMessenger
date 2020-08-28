using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuild(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuild(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, logging) => logging.AddSerilog(dispose:true)
                    //logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"))
                );
    }
}
