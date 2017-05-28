using System.Collections.Generic;

namespace StupidChessBase.Data.Models
{
    public class Country
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Tournament> Tounaments { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
