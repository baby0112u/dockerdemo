using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api.User.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api.User
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            try {
                // mysql的创建 会比web的创建慢
                // 这里防止创建数据库失败，只要抛异常自动重启
                using (var scope = host.Services.CreateScope()) {
                    var services = scope.ServiceProvider;

                    var context = services.GetRequiredService<UserContext>();
                    UserContextSeed.Initialize(context);
                }
                host.Run();
            } catch (Exception) {

                throw;
            }
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://+:8080")
                .UseStartup<Startup>();
    }
}
