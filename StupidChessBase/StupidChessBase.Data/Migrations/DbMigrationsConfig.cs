namespace StupidChessBase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Enums;

    internal sealed class DbMigrationsConfig : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
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
            context.Players.Add(new Player(1, new int[] { 1, 2 }, 7, "Magnus", "Carlsen", new DateTime(1990, 11, 30), 200, 1, 50, null, true, 2832));
            context.Players.Add(new Player(2, new int[] { 1 }, 5, "Wesley", "So", new DateTime(1993, 10, 9), 200, 1, 50, null, true, 2815));
            context.Players.Add(new Player(3, new int[] { 2 }, 8, "Vladimir", "Kramnik", new DateTime(1975, 6, 25), 200, 1, 50, null, true, 2811));
        }

        private void CreateGames(ApplicationDbContext context)
        {
            context.Games.Add(new Game(1, 1, new int[] { 2, 1 }, new DateTime(2016, 6, 12), Result.Black));
            context.Games.Add(new Game(2, 2, new int[] { 1, 3 }, new DateTime(2016, 02, 15), Result.White));
        }

        private void CreatePlayerGames(ApplicationDbContext context)
        {
            context.PlayerGames.Add(new PlayerGame(1, 1));
            context.PlayerGames.Add(new PlayerGame(2, 1));
            context.PlayerGames.Add(new PlayerGame(1, 2));
            context.PlayerGames.Add(new PlayerGame(3, 2));
        }

        private void CreateCountries(ApplicationDbContext context)
        {
            context.Countries.Add(new Country(1, "Bulgaria"));
            context.Countries.Add(new Country(2, "Spain"));
            context.Countries.Add(new Country(3, "Malta"));
            context.Countries.Add(new Country(4, "United Kingdom"));
            context.Countries.Add(new Country(5, "USA"));
            context.Countries.Add(new Country(6, "Germany"));
            context.Countries.Add(new Country(7, "Norway"));
            context.Countries.Add(new Country(8, "Russia"));
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
