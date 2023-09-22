using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class SoftwareHouse
    {
        [Key]
        public int SoftwareHouseId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string TaxId { get; set; }

        public string City { get; set; }

        public string Country { get; set; }



        public List<Videogame> Videogames { get; set; }



        public override string ToString()
        {
            return $"{SoftwareHouseId}: {Name} - {TaxId} - {City} {Country}";
        }
    }

    }
}
