using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StupidChessBase.Data.Enums;
using StupidChessBase.Utils;

namespace StupidChessBase.Data.Models
{
    public class Player : IPlayer
    {
        public int ID { get; set; }

        [StringLength(50, ErrorMessage = GlobalConstants.ErrorMessageForStringLength, MinimumLength = 1)]
        [RegularExpression(GlobalConstants.NameValidationPattern, ErrorMessage = GlobalConstants.NameValidationError)]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = GlobalConstants.ErrorMessageForStringLength, MinimumLength = 1)]
        [RegularExpression(GlobalConstants.NameValidationPattern,  ErrorMessage = GlobalConstants.NameValidationError)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime BornDate { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Range(0, 4000, ErrorMessage = "Rating should be between 0 and 4000")]
        public int Rating { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        public int? CoachID { get; set; }

        public virtual Player Coach { get; set; }
    }
}
