using Microsoft.EntityFrameworkCore;
using net_ef_videogame.Database;
using net_ef_videogame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace net_ef_videogame
{
    public class VideogameManager
    {
        // Metodo per ricercare un videogioco per id
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

        //  Metodo per ricercare tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input
        public static List<Videogame> SearchByName(string name)
        {

            using (VideogameSoftContext db = new VideogameSoftContext())
            {
                try
                {
                    List<Videogame> videogameList = db.Videogames.Where(list => list.Name.Contains(name)).Include(Videogames => Videogames.SoftwareHouse).ToList();

                    return videogameList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return null;

            }
        }

        // Metodo per restituire una stringa della lista dei videogames
        public static string ListToString(List<Videogame> videogameList)
        {
            if (videogameList.Count == 0)
                return "Non ci sono videogiochi che corrispondono alla tua ricerca!";

            string result = string.Empty;

            foreach (Videogame videogame in videogameList)
            {
                result += $"\r\n\t{videogame}";

            }

            return result;
        }

        // Metodo per eliminare un videogioco
        public static bool DeleteVideogame(int idToDelete)
        {
            using (VideogameSoftContext db = new VideogameSoftContext())
            {
                try
                {
                    Videogame idDelete = db.Videogames.Where(id => id.VideogameId == idToDelete).First();

                    db.Remove(idDelete);
                    db.SaveChanges();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return false;
            }
        }

        /* Metodo per stampare tutti i videogiochi prodotti da una software house
           (all’utente verrà chiesto l’id della software house della quale mostrare i videogame)  */
        public static List<Videogame> SearchBySoftwareHouse(int idSoft)
        {
            using (VideogameSoftContext db = new VideogameSoftContext())
            {
                List<Videogame> resultList = db.Videogames.Where(Videogame => Videogame.SoftwareHouseId == idSoft).Include(Videogames => Videogames.SoftwareHouse).ToList();

                return resultList;
            }
        }


    }
}
