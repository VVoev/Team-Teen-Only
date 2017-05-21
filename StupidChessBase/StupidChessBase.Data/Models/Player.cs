using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidChessBase.Data.Models
{
    public class Player
    {
        private IEnumerable<int> gameIds;
        private int playerId;
        private int countryId;
        private int? coachId;
        private string firstName;
        private string lastName;
        private DateTime bornYear;
        private int wins;
        private int loses;
        private int draws;
        private bool isMale;
        private int rating;

        public Player(int playerId, 
            IEnumerable<int> gameIds,
            int countryId,
            string firstName, 
            string lastName, 
            DateTime bornYear,
            int wins,
            int loses,
            int draws,
            int? coachId,
            bool isMale = true,
            int rating = 0)
        {
            this.PlayerId = playerId;
            this.GameIds = gameIds;
            this.CountryId = countryId;
            this.CoachId = coachId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BornYear = bornYear;
            this.Wins = wins;
            this.Loses = loses;
            this.Draws = draws;
            this.IsMale = isMale;
            this.Rating = rating;

        }

        [Key]
        public int PlayerId
        {
            get
            {
                return playerId;
            }

            set
            {
                playerId = value;
            }
        }

        [ForeignKey("Game")]
        [Required]
        public IEnumerable<int> GameIds
        {
            get
            {
                return gameIds;
            }

            set
            {
                gameIds = value;
            }
        }

        [ForeignKey("Country")]
        [Required]
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
        public int? CoachId
        {
            get
            {
                return coachId;
            }

            set
            {
                coachId = value;
            }
        }

        [Required]
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        [Required]
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        [Required]
        public DateTime BornYear
        {
            get
            {
                return bornYear;
            }

            set
            {
                bornYear = value;
            }
        }

        [Required]
        public int Wins
        {
            get
            {
                return wins;
            }

            set
            {
                wins = value;
            }
        }

        [Required]
        public int Loses
        {
            get
            {
                return loses;
            }

            set
            {
                loses = value;
            }
        }

        [Required]
        public int Draws
        {
            get
            {
                return draws;
            }

            set
            {
                draws = value;
            }
        }

        public bool IsMale
        {
            get
            {
                return isMale;
            }

            set
            {
                isMale = value;
            }
        }

        [Range(0, 4000)]
        public int Rating
        {
            get
            {
                return rating;
            }

            set
            {
                rating = value;
            }
        }
    }
}
