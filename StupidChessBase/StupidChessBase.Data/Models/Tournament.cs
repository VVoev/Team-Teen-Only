using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StupidChessBase.Data.Models
{
    public class Tournament
    {
        private DateTime startDate;
        private DateTime endDate;
        private int rounds;
        private string title;
        private string description;

        public Tournament(int tournamentId,
            string title,
            DateTime startDate,
            DateTime endDate,
            int rounds,
            string description)
        {
            this.TournamentId = tournamentId;
            this.Title = title;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Rounds = rounds;
            this.Description = description;
        }

        [Key]
        public int TournamentId { get; set; }

        public IEnumerable<int> PlayersId { get; set; }

        [ForeignKey("PlayersId")]
        public virtual IEnumerable<Player> Players { get; set; }
       
        [Required]
        public int Rounds
        {
            get
            {
                return rounds;
            }

            set
            {
                rounds = value;
            }
        }

        [Required]
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        [Required]
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        [Required]
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        [Required]
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }


    }
}
