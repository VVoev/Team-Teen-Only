using StupidChessBase.Data.Models;

namespace StupidChessBase.Models
{
    public class PlayerViewModel
    {
        public string FullName { get; set; }

        public int Wins { get; set; }

        public int Loses { get; set; }

        public int Draws { get; set; }

        public int Rating { get; set; }

        public string Country { get; set; }
    }
}