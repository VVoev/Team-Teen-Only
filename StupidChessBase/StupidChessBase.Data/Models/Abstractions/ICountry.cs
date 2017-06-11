using System.Collections.Generic;

namespace StupidChessBase.Data.Models
{
    public interface ICountry
    {
        string Code { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        ICollection<Player> Players { get; set; }
        ICollection<Tournament> Tounaments { get; set; }
    }
}