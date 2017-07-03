using System.Linq;
using Ads.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Ads.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Ads.Models.AdsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(Ads.Models.AdsDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var adminRole = new IdentityRole { Name = "Admin" };

                manager.Create(adminRole);
            }
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var userRole = new IdentityRole(MigrationsNamespace = "User");

                manager.Create(userRole);
            }

            if (!context.Users.Any(u => u.UserName == "admin@ads.com"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var admin = new User { UserName = "admin@ads.com", Email = "admin@ads.com"};

                var createResult = manager.Create(admin, "123456");
                if (createResult.Succeeded)
                {
                    manager.AddToRole(admin.Id, "Admin");
                }
            }
        }
    }
}
