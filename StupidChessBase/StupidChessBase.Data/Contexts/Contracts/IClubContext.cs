using StupidChessBase.Data.Models.SqlLiteModels;
using System.Data.Entity;

namespace StupidChessBase.Data.Contexts
{
    public interface IClubContext
    {
        IDbSet<Club> Clubs { get; set; }

        int SaveChanges();
    }
}
