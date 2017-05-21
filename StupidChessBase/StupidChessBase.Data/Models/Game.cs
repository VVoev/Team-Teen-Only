using StupidChessBase.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidChessBase.Data.Models
{
    public class Game
    {
        private int gameId;
        //private Player black;
        private DateTime date;
        private Result result;

        public Game(int gameId,
            int tournamentId,
            int whiteId,
            // Player black,
            DateTime date,
            Result result)
        {
            this.GameId = gameId;
            this.TournamentId = tournamentId;
            this.WhiteId = whiteId;
            //this.Black = black;
            this.Date = date;
            this.Result = result;
        }

        [Key]
        public int GameId
        {
            get
            {
                return gameId;
            }

            set
            {
                gameId = value;
            }
        }

        public int TournamentId { get; set; }

        [ForeignKey("TournamentId")]
        public virtual Tournament Tournament { get; set; }

        public int WhiteId { get; set; }

        [ForeignKey("WhiteId")]
        public virtual Player White { get; set; }

        //[ForeignKey("Player")]
        //public virtual Player Black
        //{
        //    get
        //    {
        //        return black;
        //    }

        //    set
        //    {
        //        black = value;
        //    }
        //}

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
        public Result Result
        {
            get
            {
                return result;
            }

            set
            {
                result = value;
            }
        }
    }
}
