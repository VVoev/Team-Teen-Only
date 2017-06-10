using System.Collections.Generic;

namespace StupidChessBase.Models
{
    public class IndexViewModels
    {
        public IEnumerable<PlayerViewModel> Players { get; set; }

        public IEnumerable<TournamentViewModel> CurrentTournaments { get; set; }
    }
}