using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using StupidChessBase.Utils;

namespace StupidChessBase.Data.Models
{
    public class Tournament
    {
        public int ID { get; set; }

        [StringLength(100, ErrorMessage = GlobalConstants.ErrorMessageForStringLength, MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        public int Rounds { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Player> Players { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public int? CountryID { get; set; }

        public virtual Country Country { get; set; }
    }
}
