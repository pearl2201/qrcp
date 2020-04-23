using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace qrserver
{
    public enum ProgramAction
    {
        SEND,
        RECEIVE
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddCommandLine(args);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        private static IHost host;
        public async static Task RunServerAtPort(string[] args, string[] urls, string pathToken, string pathFile, ProgramAction action)
        {
            host = CreateHostBuilder(args, urls, pathToken, pathFile, action).Build();
            await host.StartAsync();
        }

        public async static Task StopServer()
        {
            await host.StopAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, string[] urls, string pathToken, string pathFile, ProgramAction action)
        {
            var Dict = new Dictionary<string, string>
                        {
                           {"PathToken", pathToken},
                           {"PathFile", pathFile},
                           {"Action",action.ToString() }
                        };

            return Host.CreateDefaultBuilder(args)
              .ConfigureAppConfiguration((hostingContext, config) =>
              {
                  config.AddInMemoryCollection(Dict);
              })
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseWebRoot("wwwroot");
                  webBuilder.UseStartup<Startup>();
                  webBuilder.UseUrls(urls);
              });
        }
    }
}
