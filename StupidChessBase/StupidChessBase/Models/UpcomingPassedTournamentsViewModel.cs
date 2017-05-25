using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StupidChessBase.Models
{
    public class UpcomingPassedTournamentsViewModel
    {
        public IEnumerable<TournamentViewModel> UpcomingTournaments { get; set; }

        public IEnumerable<TournamentViewModel> CurrentTournaments { get; set; }

        public IEnumerable<TournamentViewModel> PassedTournaments { get; set; }
    }
}