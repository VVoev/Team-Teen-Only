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
    public class Game : IGame
    {
        private DateTime date;
        private Result result;

        public Game(int gameId,
            int tournamentId,
            IEnumerable<int> playersId,
            DateTime date,
            Result result)
        {
            this.GameId = gameId;
            this.TournamentId = tournamentId;
            this.PlayersId = playersId;
            this.Date = date;
            this.Result = result;
        }

        [Key]
        public int GameId {get;set;}

        public int TournamentId { get; set; }

        [ForeignKey("TournamentId")]
        public virtual ITournament Tournament { get; set; }

        public IEnumerable<int> PlayersId { get; set; }

        [ForeignKey("PlayersId")]
        public virtual IEnumerable<IPlayerGame> PlayersGames { get; set; }

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
