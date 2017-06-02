using System;
using System.ComponentModel.DataAnnotations;

namespace StupidChessBase.Models
{
    public class TournamentViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public int Rounds { get; set; }

        public string Description { get; set; }

  
    }
}