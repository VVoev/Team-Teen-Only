using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StupidChessBase.Data.Models.SqlLiteModels;
using StupidChessBase.Data.Migrations.Clubs;

namespace StupidChessBase.Data.Contexts
{
    public class ClubContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Club> Clubs { get; set; }


        public ClubContext()
                : base("SqliteDb", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ClubContext, SqlLiteConfig>(true));
        }

        public static ClubContext Create()
        {
            return new ClubContext();
        }
    }
}
