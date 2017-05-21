using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidChessBase.Data.Models
{
    public class Country
    {
        private int countryId;
        private IEnumerable<int> playerIds;
        private IEnumerable<int> tournamentIds;

        public Country(int countryId,
            IEnumerable<int> tournamentIds,
            IEnumerable<int> playerIds,
            string name)
        {
            this.CountryId = countryId;
            this.TournamentIds = tournamentIds;
            this.PlayerIds = playerIds;
        }

        [Key]
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

        [ForeignKey("Tournament")]
        public IEnumerable<int> TournamentIds
        {
            get
            {
                return tournamentIds;
            }

            set
            {
                tournamentIds = value;
            }
        }
    }
}
