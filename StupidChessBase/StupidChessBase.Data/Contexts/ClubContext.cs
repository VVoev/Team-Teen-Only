using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StupidChessBase.Data.Models.SqlLiteModels;

namespace StupidChessBase.Data.Contexts
{
    public class ClubContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Club> Clubs { get; set; }


        public ClubContext()
                : base("SqliteDb", throwIfV1Schema: false)
        {
        }

        public static ClubContext Create()
        {
            return new ClubContext();
        }
    }
}
