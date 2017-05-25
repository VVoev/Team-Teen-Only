using System;

namespace StupidChessBase.Models
{
    public class TournamentViewModel
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Rounds { get; set; }

        public string Description { get; set; }
    }
}