using System;
using System.Collections.Generic;

namespace StupidChessBase.Data.Models
{
    public interface ITournament
    {
        DateTime Date { get; set; }
        IEnumerable<IPlayer> Players { get; set; }
        IEnumerable<int> PlayersId { get; set; }
        int Rounds { get; set; }
        string Title { get; set; }
        int TournamentId { get; set; }
    }
}