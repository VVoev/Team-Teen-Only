using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StupidChessBase.Data.Models
{
    public class Player
    {
        private string firstName;
        private string lastName;
        private DateTime bornYear;
        private int wins;
        private int loses;
        private int draws;
        private bool isMale;
        private int rating;

        public Player(int playerId,
            IEnumerable<int> gamesId,
            int countryId,
            string firstName,
            string lastName,
            DateTime bornYear,
            int wins,
            int loses,
            int draws,
            int? coachId = null,
            bool isMale = true,
            int rating = 0)
        {
            this.PlayerId = playerId;
            this.GamesId = gamesId;
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
        public int PlayerId { get; set; }

        public IEnumerable<int> GamesId { get; set; }

        [ForeignKey("GamesId")]
        public virtual IEnumerable<PlayerGame> PlayersGames { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        public int? CoachId { get; set; }

        [ForeignKey("CoachId")]
        public virtual Player Coach { get; set; }

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

        //public string GetCountryById(int id, ApplicationDbContext db)
        //{
        //    id = this.CountryId;
        //
        //    var country = db.Countries
        //        .FirstOrDefault(x => x.CountryId == id);
        //
        //    return country.Name;           
        //}
    }
}
