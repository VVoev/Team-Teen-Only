using System;
using System.Collections.Generic;
using StupidChessBase.Data.Enums;

namespace StupidChessBase.Data.Models
{
    public interface IPlayer
    {
        DateTime BornDate { get; set; }

        Player Coach { get; set; }

        int? CoachID { get; set; }

        Country Country { get; set; }

        int CountryID { get; set; }

        string FirstName { get; set; }

        ICollection<Game> Games { get; set; }

        Gender Gender { get; set; }

        int ID { get; set; }

        string LastName { get; set; }

        int Rating { get; set; }
    }
}