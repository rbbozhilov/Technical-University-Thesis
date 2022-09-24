using Ezam_System.Data;
using Ezam_System.Data.Models;
using Ezam_System.Data.Models.Exam;
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
            SeedStatuses(data);
            SeedTypes(data);

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

        private static void SeedStatuses(EzamDbContext db)
        {

            if (db.Statuses.Any())
            {
                return;
            }

            db.Statuses.AddRange(new[]
            {
                new Status() {StatusName = "Regular"},
                new Status() {StatusName = "Corrective"},
                new Status(){StatusName = "Liquidation"}
            });

            db.SaveChanges();

        }

        private static void SeedTypes(EzamDbContext db)
        {

            if (db.Types.Any())
            {
                return;
            }

            db.Types.AddRange(new[]
            {
                new Data.Models.Exam.Type() {SubjectName = "СЕРВОУПРАВЛЕНИЕ И ЗАДВИЖВАНЕ НА РОБОТИ"},
                new Data.Models.Exam.Type() {SubjectName = "АВТОМАТИЗАЦИЯ НА ПРОИЗВОДСТВЕНИТЕ МЕХАНИЗМИ"},
                new Data.Models.Exam.Type() {SubjectName = "СГРАДНА АВТОМАТИЗАЦИЯ"},
                new Data.Models.Exam.Type() {SubjectName = "СИЛОВА И УПРАВЛЯВАЩА ЕЛЕКТРОНИКА В ЕЛЕКТРОЗАДВИЖВАНИЯТА"},
                new Data.Models.Exam.Type() {SubjectName = "УПРАВЛЕНИЕ НА ЕЛЕКТРОЗАДВИЖВАНИЯТА "},
            });

            db.SaveChanges();
        }

    }
}
