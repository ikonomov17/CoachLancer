namespace CoachLancer.Data.Migrations
{
    using CoachLance.Data.Models;
    using CoachLance.Data.Models.Enums;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CoachLancer.Data.MsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
            this.ContextKey = "CoachLancer.Data.MsSqlDbContext";
        }

        protected override void Seed(CoachLancer.Data.MsSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedEnumValues<Gender, GenderEnum>(context.Genders, @enum => @enum);
            this.SeedEnumValues<Position, PositionEnum>(context.Positions, @enum => @enum);
            context.SaveChanges();
        }

        private void SeedAdmin(MsSqlDbContext context)
        {
            const string AdministratorUserName = "info@coachlancer.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var admin = new IdentityRole { Name = "Admin" };
                var coach = new  IdentityRole { Name = "Coach" };
                var player = new  IdentityRole { Name = "Player" };
                roleManager.Create(admin);
                roleManager.Create(coach);
                roleManager.Create(player);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void SeedEnumValues<T, TEnum>(IDbSet<T> dbSet, Func<TEnum, T> converter)
            where T : class => Enum.GetValues(typeof(TEnum))
            .Cast<object>()
            .Select(value => converter((TEnum)value))
            .ToList()
            .ForEach(instance => dbSet.AddOrUpdate(instance));
    }
}
