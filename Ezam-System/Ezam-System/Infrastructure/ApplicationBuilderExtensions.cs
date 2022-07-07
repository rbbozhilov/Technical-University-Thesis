using Ezam_System.Data;
using Ezam_System.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ezam_System.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {


        //Method create on each start project new migration and put some data in database
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopeServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopeServices.ServiceProvider;
            var data = serviceProvider.GetService<EzamDbContext>();

            data.Database.Migrate();

            //Add here seed
            SeedAdminRole(serviceProvider);
      
            return app;
        }

        private static void SeedAdminRole(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();


            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Administrator"))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = "Administrator" };

                    await roleManager.CreateAsync(role);

                    const string adminEmail = "admin@abv.bg";
                    const string adminPassword = "admin123";

                    var user = new User
                    {
                        Email = adminEmail,
                        UserName = adminEmail
                    };

                    await userManager.CreateAsync(user, adminPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }



    }
}
