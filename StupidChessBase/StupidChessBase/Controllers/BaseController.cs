using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.Mvc;
using StupidChessBase.Data;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;

namespace StupidChessBase.Controllers
{
    public class BaseController : Controller
    {
        private IApplicationDbContext db;

        public BaseController()
        {
            this.Db = new ApplicationDbContext();
        }

        public BaseController(IApplicationDbContext applicationDbContext)
        {
            this.Db = applicationDbContext;
        }

        public IApplicationDbContext Db
        {
            get
            {
                return this.db;
            }

            set
            {
                this.db = value;
            }
        }

        public IEnumerable<TournamentViewModel> GetCurrentTournaments(IEnumerable<TournamentViewModel> allTournaments)
        {
            var currentTournaments = allTournaments.Where(t => t.StartDate < DateTime.Now && t.EndDate > DateTime.Now);

            return currentTournaments;
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
    }
}