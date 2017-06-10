using StupidChessBase.Data.Contexts;
using StupidChessBase.Models;
using System.Web.Mvc;

namespace StupidChessBase.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() : base()
        { }
        public HomeController(IApplicationDbContext applicationDbContext, IClubContext clubContext) : base(applicationDbContext, clubContext)
        { }
        public ActionResult Index()
        {
            return View(new IndexViewModels()
            {
                Players = this.GetTopPlayers(),
                CurrentTournaments = this.GetCurrentTournaments(this.GetAllTournaments())
            });    
        }
    }
}