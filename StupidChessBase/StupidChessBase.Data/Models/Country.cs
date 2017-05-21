using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidChessBase.Data.Models
{
    public class Country : ICountry
    {

        public Country(int countryId, string name)
        {
            this.CountryId = countryId;
            this.Name = name;
        }

        [Key]
        public int CountryId { get; set; }
        public string Name { get; set; }

    }
}
