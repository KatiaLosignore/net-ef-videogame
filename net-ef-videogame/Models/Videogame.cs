using Microsoft.EntityFrameworkCore.Query;
using net_ef_videogame.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame.Models
{
    public class Videogame
    {
        // ATTRIBUTI
        public int VideogameId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }




        public int SoftwareHouseId { get; set; }

        public SoftwareHouse SoftwareHouse { get; set; }




        // METODI

        public static Videogame SearchById(int id)
        {
            using (VideogameSoftContext db = new VideogameSoftContext())
            {
                try
                {
                    Videogame result = db.Videogames.Where(game => game.VideogameId == id).First();

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
        }
        




        public override string ToString()
        {
            return $"ID: {VideogameId} Nome: {Name} Descrizione: {Overview} Data di rilascio: {ReleaseDate.ToString("dd/MM/yyyy")}";
        }


    }
}

