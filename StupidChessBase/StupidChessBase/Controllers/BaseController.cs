using System.Web.Mvc;
using StupidChessBase.Data;
using StupidChessBase.Data.Contexts;
using System.Linq;
using StupidChessBase.Models;
using System.Collections.Generic;
using System;

namespace StupidChessBase.Controllers
{
    public class BaseController : Controller
    {
        public IApplicationDbContext db;
        public IClubContext liteDb;

        public BaseController()
        {
            db = new ApplicationDbContext();
            liteDb = new ClubContext();
        }
        public BaseController(IApplicationDbContext applicationDbContext, IClubContext clubContext)
        {
            db = applicationDbContext;
            liteDb = clubContext;
        }

        protected IEnumerable<PlayerViewModel> GetTopPlayers()
        {
            var players = this.db.Players.OrderByDescending(x => x.Rating).Select(x => new PlayerViewModel()
            {
                FullName = x.FirstName + " " + x.LastName,
                Rating = x.Rating,
                Country = x.Country.Name,
                CountryCode = x.Country.Code.ToLower()
            });

            return players;
        }

        protected IEnumerable<TournamentViewModel> GetAllTournaments()
        {
            var tournaments = this.db.Tournaments
                .OrderByDescending(x => x.StartDate)
                .Select(x => new TournamentViewModel()
                {
                    Id = x.ID,
                    Name = x.Title,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Rounds = x.Rounds,
                    Counrty = x.Country.Name,
                    CounrtyCode = x.Country.Code.ToLower(),
                    Description = x.Description
                });

            return tournaments;
        }

        protected IEnumerable<TournamentViewModel> GetCurrentTournaments(IEnumerable<TournamentViewModel> allTournaments)
        {
            var currentTournaments = allTournaments.Where(t => t.StartDate < DateTime.Now && t.EndDate > DateTime.Now);

            return currentTournaments;
        }
    }
}