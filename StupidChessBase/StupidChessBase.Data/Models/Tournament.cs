using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidChessBase.Data.Models
{
    public class Tournament
    {
        private int countryId;
        private DateTime date;
        private IEnumerable<int> playerIds;
        private int rounds;
        private string title;
        private int tournamentId;

        public Tournament(int tournamentId,
            int countryId,
            IEnumerable<int> playerIds,
            string title,
            DateTime date,
            int rounds)
        {
            this.TournamentId = tournamentId;
            this.CountryId = countryId;
            this.PlayerIds = playerIds;
            this.Title = title;
            this.Date = date;
            this.Rounds = rounds;
        }

        [Key]
        public int TournamentId
        {
            get
            {
                return tournamentId;
            }

            set
            {
                tournamentId = value;
            }
        }

        [ForeignKey("Country")]
        public int CountryId
        {
            get
            {
                return countryId;
            }

            set
            {
                countryId = value;
            }
        }

        [ForeignKey("Player")]
        public IEnumerable<int> PlayerIds
        {
            get
            {
                return playerIds;
            }

            set
            {
                playerIds = value;
            }
        }

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
