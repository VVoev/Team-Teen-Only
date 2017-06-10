using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StupidChessBase.Data.Models.SqlLiteModels;
using SQLite.CodeFirst;

namespace StupidChessBase.Data.Contexts
{
    public class ClubContext : DbContext, IClubContext
    {
        public virtual IDbSet<Club> Clubs { get; set; }

        public ClubContext()
                : base("SqliteDb")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<ClubContext>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}
