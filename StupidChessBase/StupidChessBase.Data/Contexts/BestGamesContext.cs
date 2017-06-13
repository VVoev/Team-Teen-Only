using Microsoft.AspNet.Identity.EntityFramework;
using StupidChessBase.Data;
using StupidChessBase.Data.Models.PosgtreModels;
using System.Data.Entity;

namespace StupidChessBase.Data.Contexts
{
    public class BestGamesContext : IdentityDbContext<ApplicationUser>
    {
        public BestGamesContext()
                : base("PostgresDotNet", throwIfV1Schema: false)
        {
        }

        public IDbSet<BestGame> BestGames { get; set; }

        public static BestGamesContext Create()
        {
            return new BestGamesContext();
        }
    }
}