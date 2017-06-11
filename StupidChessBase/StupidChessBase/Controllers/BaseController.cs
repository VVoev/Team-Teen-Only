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
        private IApplicationDbContext db;
        private IClubContext liteDb;

        public IApplicationDbContext Db
        {
            get
            {
                return db;
            }

            set
            {
                db = value;
            }
        }

        public IClubContext LiteDb
        {
            get
            {
                return liteDb;
            }

            set
            {
                liteDb = value;
            }
        }

        public BaseController()
        {
            Db = new ApplicationDbContext();
            LiteDb = new ClubContext();
        }
        public BaseController(IApplicationDbContext applicationDbContext, IClubContext clubContext)
        {
            Db = applicationDbContext;
            LiteDb = clubContext;
        }

        protected IEnumerable<PlayerViewModel> GetTopPlayers()
        {
            var players = this.Db.Players.OrderByDescending(x => x.Rating).Select(x => new PlayerViewModel()
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
            var tournaments = this.Db.Tournaments
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

        public IEnumerable<TournamentViewModel> GetCurrentTournaments(IEnumerable<TournamentViewModel> allTournaments)
        {
            var currentTournaments = allTournaments.Where(t => t.StartDate < DateTime.Now && t.EndDate > DateTime.Now);

            return currentTournaments;
        }
    }
}