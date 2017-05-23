namespace StupidChessBase.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class DbMigrationsConfig : DbMigrationsConfiguration<StupidChessBase.Data.ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StupidChessBase.Data.ApplicationDbContext context)
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

            if (!context.Users.Any())
            {
                //Asp.Net Users
                CreateUser(context, "vlado@abv.bg", "123");
                CreateUser(context, "test@abv.bg", "123");
                CreateUser(context, "kiro@abv.bg", "123");
                CreateUser(context, "ani@abv.bg", "123");
                CreateUser(context, "vladi@abv.bg", "123");
                CreateUser(context, "ceco@abv.bg", "123");

                CreateCountries(context);
                CreateTournaments(context);
                CreatePlayers(context);
            }

        }

        private void CreatePlayers(ApplicationDbContext context)
        {
            // throw new NotImplementedException();
        }

        private void CreateCountries(ApplicationDbContext context)
        {
            context.Countries.Add(new Country(1, "Bulgaria"));
            context.Countries.Add(new Country(2, "Spain"));
            context.Countries.Add(new Country(3, "Malta"));
            context.Countries.Add(new Country(4, "United Kingdom"));
            context.Countries.Add(new Country(5, "USA"));
            context.Countries.Add(new Country(6, "Germany"));
        }

        private void CreateUser(ApplicationDbContext context, string email, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }

        }

        private void CreateTournaments(ApplicationDbContext context)
        {
            context.Tournaments.Add(new Tournament(1, "Malta Tournament", new DateTime(2000, 5, 1),2));
            context.Tournaments.Add(new Tournament(2, "Bulgaria Tournament", new DateTime(1995, 5, 1),2));
            context.Tournaments.Add(new Tournament(3, "Usa Tournament", new DateTime(1990, 5, 1),2));
            context.Tournaments.Add(new Tournament(4, "United Kingdom Tournament", new DateTime(1999, 5, 1),2));
            context.Tournaments.Add(new Tournament(5, "Germany Tournament", new DateTime(2015, 5, 1),2));
            context.Tournaments.Add(new Tournament(6, "France Tournament", new DateTime(2020, 5, 1),2));
        }

       
    }
}
