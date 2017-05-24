using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StupidChessBase.Models
{
    public class PlayersViewModel
    {
        public IEnumerable<PlayerViewModel> PlayersData { get; set; }
    }
}