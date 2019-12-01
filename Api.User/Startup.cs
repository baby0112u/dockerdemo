using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.User.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Api.User.Filters;

namespace Api.User
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 总结下来，官方包不可靠
            services.AddDbContext<UserContext>(options => {
                options.UseMySql(Configuration.GetConnectionString("MysqlConn"));
            });
            services.AddMvc(options=> {
                options.Filters.Add(typeof(GlobalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            //InitUserDatabase(app);

            app.UseMvc();

            //UserContextSeed.SeedAsync(app, loggerFactory).Wait();
        }

        public void InitUserDatabase(IApplicationBuilder app)
        {
            using(var scope = app.ApplicationServices.CreateScope()) {
                var userContext = scope.ServiceProvider.GetRequiredService<UserContext>();
                if (!userContext.Users.Any()) {
                    userContext.Users.Add(new Models.AppUser {
                        Name = "tanzb"
                    });
                    userContext.SaveChanges();
                }
            }
        }
    }
}
