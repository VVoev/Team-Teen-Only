using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using StupidChessBase.Data.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace StupidChessBase.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Player> Players { get; set; }     
        public IDbSet<Tournament> Tournaments { get; set; }
        public IDbSet<Country> Countries { get; set; }
        public IDbSet<Game> Games { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(p => p.Games).WithMany(g => g.Players)
                .Map(pg => pg.MapLeftKey("PlayerID")
                    .MapRightKey("GameID")
                    .ToTable("PlayerGame"));

           
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId});
            
        }
    }
}