using System.Web.Mvc;
using StupidChessBase.Data;
using StupidChessBase.Data.Contexts;

namespace StupidChessBase.Controllers
{
    public class BaseController : Controller
    {
        protected ApplicationDbContext db  = new ApplicationDbContext();
        protected ClubContext liteDb = new ClubContext();
    }
}