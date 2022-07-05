using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MQTTnet.Server.Web;
using System;
using System.IO;

namespace MQTTnet.Server
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.ConfigureKestrel(serverOptions =>
                        {
                        })
                        .UseWebRoot(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web", "wwwroot"))
                        .UseStartup<Startup>();
                    })
                    .UseWindowsService()
                    .Build()
                    .Run();

                return 0;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return -1;
            }
        }
    }
}