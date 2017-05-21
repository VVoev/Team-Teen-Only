using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidChessBase.Data.Models
{
    public class PlayerGame
    {
        public PlayerGame(int playerId, int gameId)
        {
            this.PlayerId = playerId;
            this.GameId = gameId;
        }

        [Key]
        [Column(Order = 1)]
        public int PlayerId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int GameId { get; set; }

        public virtual Player Player { get; set; }
        public virtual Game Game { get; set; }
    }
}
