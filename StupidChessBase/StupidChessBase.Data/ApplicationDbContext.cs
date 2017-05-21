using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StupidChessBase.Data.Models;

namespace StupidChessBase.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Player> Players { get; set; }     
        public IDbSet<Tournament> Tournaments { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Game> Games { get; set; }
        public IDbSet<PlayerGame> PlayerGame { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}