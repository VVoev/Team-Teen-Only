using System;
using System.ComponentModel.DataAnnotations;

namespace StupidChessBase.Models
{
    public class TournamentInputModel
    {
        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be between {2} and {1} symbols long", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(1, 100)]
        public int Rounds { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be between {2} and {1} symbols long", MinimumLength = 5)]
        public string Description { get; set; }
    }
}