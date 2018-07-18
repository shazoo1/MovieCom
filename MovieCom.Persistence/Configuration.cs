using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieCom.Common.Enums;
using MovieCom.Domain.Entities.Identity;
using MovieCom.Domain.Store;

namespace MovieCom.Persistence
{
    internal sealed class Configuration : DbMigrationsConfiguration<MovieComDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MovieComDbContext context)
        {
            base.Seed(context);

            var userManager = new UserManager<User, Guid>(new UserStore(context));
            var roleManager = new RoleManager<Role, Guid>(new RoleStore(context));

            var roles = typeof(Roles).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(x => x.Name).ToList();

            roles.ForEach(x =>
            {
                if (!roleManager.RoleExists(x))
                {
                    roleManager.Create(new Role { Id = Guid.NewGuid(), Name = x });
                }
            });

            var admin = new User
            {
                Id = new Guid("437c58f9-3184-428a-b169-44ad0a05fc03"),
                Email = "admin@admin.com",
                EmailConfirmed = true,
                UserName = "Admin"
            };

            var adminPassword = "AdminPass";

            if (userManager.FindByName(admin.UserName) == null)
            {
                userManager.Create(admin, adminPassword);
                userManager.SetLockoutEnabled(admin.Id, false);
            }

            var adminRole = Roles.Admin;
            var rolesForUser = userManager.GetRoles(admin.Id);
            if (!rolesForUser.Contains(adminRole))
                userManager.AddToRole(admin.Id, Roles.Admin);
            context.SaveChanges();
        }
    }
}
