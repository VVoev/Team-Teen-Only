using System.Web.Mvc;
using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;

namespace StupidChessBase.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() 
            : base()
        {
        }

        public HomeController(IApplicationDbContext applicationDbContext, IClubContext clubContext) 
            : base(applicationDbContext, clubContext)
        {
        }

        public ActionResult Index()
        {
            return this.View(new IndexViewModels()
            {
                Players = this.GetTopPlayers(),
                CurrentTournaments = this.GetCurrentTournaments(this.GetAllTournaments())
            });    
        }
    }
}