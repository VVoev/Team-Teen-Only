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
        private int blackId;
        private DateTime date;
        private int gameId;
        private Result result;
        private int tournamentId;
        private int whiteId;

        public Game(int gameId,
            int tournamentId,
            int whiteId,
            int blackId,
            DateTime date,
            Result result)
        {
            this.GameId = gameId;
            this.TournamentId = tournamentId;
            this.WhiteId = whiteId;
            this.BlackId = blackId;
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

        [ForeignKey("Tournament")]
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

        [ForeignKey("Player")]
        public int WhiteId
        {
            get
            {
                return whiteId;
            }

            set
            {
                whiteId = value;
            }
        }

        [ForeignKey("Player")]
        public int BlackId
        {
            get
            {
                return blackId;
            }

            set
            {
                blackId = value;
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
