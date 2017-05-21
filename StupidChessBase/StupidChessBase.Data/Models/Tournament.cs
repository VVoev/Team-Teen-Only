using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidChessBase.Data.Models
{
    public class Tournament : ITournament
    {
        private DateTime date;
        private int rounds;
        private string title;

        public Tournament(int tournamentId,
            IEnumerable<int> playersId,
            string title,
            DateTime date,
            int rounds)
        {
            this.TournamentId = tournamentId;
            this.PlayersId = playersId;
            this.Title = title;
            this.Date = date;
            this.Rounds = rounds;
        }

        [Key]
        public int TournamentId { get; set; }

        public IEnumerable<int> PlayersId { get; set; }

        [ForeignKey("PlayersId")]
        public virtual IEnumerable<IPlayer> Players { get; set; }

        [Required]
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

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
    }
}
