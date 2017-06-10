using StupidChessBase.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
