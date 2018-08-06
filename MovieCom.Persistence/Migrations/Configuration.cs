namespace MovieCom.Persistence.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MovieCom.Common.Enums;
    using MovieCom.Domain.Entities.Identity;
    using MovieCom.Domain.Store;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieCom.Persistence.MovieComDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieCom.Persistence.MovieComDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
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

            var adminPassword = "123456";

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
