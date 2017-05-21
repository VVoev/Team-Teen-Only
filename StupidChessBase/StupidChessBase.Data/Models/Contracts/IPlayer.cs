using System;
using System.Collections.Generic;

namespace StupidChessBase.Data.Models
{
    public interface IPlayer
    {
        DateTime BornYear { get; set; }
        IPlayer Coach { get; set; }
        int CoachId { get; set; }
        ICountry Country { get; set; }
        int CountryId { get; set; }
        int Draws { get; set; }
        string FirstName { get; set; }
        IEnumerable<int> GamesId { get; set; }
        bool IsMale { get; set; }
        string LastName { get; set; }
        int Loses { get; set; }
        int PlayerId { get; set; }
        IEnumerable<IPlayerGame> PlayersGames { get; set; }
        int Rating { get; set; }
        int Wins { get; set; }
    }
}