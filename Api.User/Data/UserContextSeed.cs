using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Data
{
    public class UserContextSeed
    {
        private ILogger<UserContextSeed> _logger;
        public UserContextSeed(ILogger<UserContextSeed> logger)
        {
            _logger = logger;
        }

        public static async Task SeedAsync(IApplicationBuilder app,ILoggerFactory loggerFactory,int retry = 0)
        {
            
            try {
                using (var scope = app.ApplicationServices.CreateScope()) {
                    var userContext = (UserContext)scope.ServiceProvider.GetService(typeof(UserContext));
                    var logger = (ILogger<UserContextSeed>)scope.ServiceProvider.GetService(typeof(ILogger<UserContextSeed>));
                    logger.LogDebug("Begin UserContextSeed SeedAsync");
                    userContext.Database.Migrate();
                    if (!userContext.Users.Any()) {
                        userContext.Users.Add(new Models.AppUser {
                            Name = "tanzb"
                        });
                        userContext.SaveChanges();
                    }
                }
            } catch (Exception ex) {
                if (retry < 10) {
                    retry++;
                    var logger = loggerFactory.CreateLogger(typeof(ILogger<UserContextSeed>));
                    logger.LogError(ex.Message);
                    await SeedAsync(app, loggerFactory, retry);
                }
            }
        }

        internal static void Initialize(UserContext context)
        {
            context.Database.Migrate();
            if (!context.Users.Any()) {
                context.Users.Add(new Models.AppUser {
                    Name = "tanzb"
                });
                context.SaveChanges();
            }
        }
    }
}
