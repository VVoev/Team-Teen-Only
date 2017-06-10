using System.Web.Mvc;
using StupidChessBase.Data;
using StupidChessBase.Data.Contexts;

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
    }
}