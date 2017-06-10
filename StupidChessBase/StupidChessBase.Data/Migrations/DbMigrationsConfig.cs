namespace StupidChessBase.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using System.Xml;
    using System.Web;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Enums;

    internal sealed class DbMigrationsConfig : DbMigrationsConfiguration<ApplicationDbContext>
    {
        private readonly bool pendingMigrations;

        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

            var migrator = new DbMigrator(this);
            this.pendingMigrations = migrator.GetPendingMigrations().Any();

            if (pendingMigrations)
            {
                migrator.Update();
                Seed(new ApplicationDbContext());
            }
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                //Asp.Net Users
                CreateUser(context, "vlado@abv.bg", "123");
                CreateUser(context, "test@abv.bg", "123");
                CreateUser(context, "kiro@abv.bg", "123");
                CreateUser(context, "ani@abv.bg", "123");
                CreateUser(context, "vladi@abv.bg", "123");
                CreateUser(context, "ceco@abv.bg", "123");
            }

            List<Country> countries = new List<Country>();
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/xmls/countries.xml"));

            foreach (XmlNode node in doc.SelectNodes("//country"))
            {
                countries.Add(new Country { Name = node.InnerText, Code = node.Attributes["code"].InnerText });
            }

            countries.ForEach(c => context.Countries.AddOrUpdate(n => n.Name, c));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player() { FirstName = "Magnus", LastName = "Carlsen", BornDate = new DateTime(1990, 11, 30), Gender = Gender.Male, Rating = 2832, CountryID = countries.Single(c => c.Name == "Norway").ID, Games = new List<Game>() },
                new Player() { FirstName = "Wesley", LastName = "So", BornDate = new DateTime(1993, 10, 9), Gender = Gender.Male, Rating = 2815, CountryID = countries.Single(c => c.Name == "United States").ID, Games = new List<Game>() },
                new Player() { FirstName = "Vladimir", LastName = "Kramnik", BornDate = new DateTime(1975, 6, 25), Gender = Gender.Male, Rating = 2811, CountryID = countries.Single(c => c.Name == "Russian Federation").ID, Games = new List<Game>() }
            };

            var tournaments = new List<Tournament>
            {
                new Tournament() { Title = "Malta Tournament", StartDate = new DateTime(2000, 5, 1), EndDate = new DateTime(2000, 5, 7), Rounds = 5, Description = "Malta tournament", CountryID = countries.Single(c => c.Name == "Malta").ID, Players = new List<Player>() },

                new Tournament() { Title = "USA Tournament", StartDate = new DateTime(2000, 5, 1), EndDate = new DateTime(2000, 5, 7), Rounds = 5, Description = "USA tournament", CountryID = countries.Single(c => c.Name == "United States").ID, Players = new List<Player>() }
            };

            tournaments.ForEach(t => context.Tournaments.AddOrUpdate(tt => tt.Title, t));
            context.SaveChanges();


            var games = new List<Game>
            {
                new Game() { Date = new DateTime(2016, 6, 12), Result = Result.Black, TournamentID = tournaments.Single(t => t.Title == "Malta Tournament").ID, Players = new List<Player>(), Table = 1, Round = 1},
                new Game() { Date = new DateTime(2016, 02, 15), Result = Result.White, TournamentID = tournaments.Single(t => t.Title == "USA Tournament").ID, Players = new List<Player>(), Table = 1, Round = 1 }
            };

            games.ForEach(g => context.Games.Add(g));
            context.SaveChanges();

            players[1].Games.Add(games[0]);
            players[0].Games.Add(games[0]);

            players[0].Games.Add(games[1]);
            players[2].Games.Add(games[1]);

            players.ForEach(p => context.Players.AddOrUpdate(l => l.LastName, p));
            context.SaveChanges();

            context.SaveChanges();
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
    }
}
