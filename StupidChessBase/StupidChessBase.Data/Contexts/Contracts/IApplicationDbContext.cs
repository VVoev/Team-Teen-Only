using StupidChessBase.Data.Models;
using System.Data.Entity;

namespace StupidChessBase.Data.Contexts
{
    public interface IApplicationDbContext
    {
        IDbSet<Player> Players { get; }

        IDbSet<Tournament> Tournaments { get; }

        IDbSet<Country> Countries { get; }

        IDbSet<Game> Games { get; }

        int SaveChanges();
    }
}
