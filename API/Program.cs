using Dal;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = BuildWebHost(args);
      using (var scope = host.Services.CreateScope())
      {
        var context = scope.ServiceProvider.GetService<ApplicationContext>();
      }
      host.Run();

    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
  }
}