using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AutofacNectore3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseAutofac()
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();

                    /**
                     * This doesn't work anymore. There is an exception thrown during runtime
                     * webBuilder.UseStartup<Startup>()
                        .ConfigureServices(sp => sp.AddAutofac());
                     */
                });
    }
}
