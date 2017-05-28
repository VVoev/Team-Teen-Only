using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StupidChessBase.Data.Enums;

namespace StupidChessBase.Data.Models
{
    public class Game
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public Result Result { get; set; }

        [Required]
        public int Round { get; set; }

        [Required]
        public int Table { get; set; }

        public int TournamentID { get; set; }

        public virtual Tournament Tournament { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
