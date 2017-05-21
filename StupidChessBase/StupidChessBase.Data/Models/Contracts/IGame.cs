using System;
using System.Collections.Generic;
using StupidChessBase.Data.Enums;

namespace StupidChessBase.Data.Models
{
    public interface IGame
    {
        DateTime Date { get; set; }
        int GameId { get; set; }
        IEnumerable<IPlayerGame> PlayersGames { get; set; }
        IEnumerable<int> PlayersId { get; set; }
        Result Result { get; set; }
        ITournament Tournament { get; set; }
        int TournamentId { get; set; }
    }
}