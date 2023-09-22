// See https://aka.ms/new-console-template for more information

using net_ef_videogame.Database;
using net_ef_videogame.Models;
using net_ef_videogame;

Console.WriteLine("Benvenuto nel nostro sistema di Videogame e SoftwareHouse!");

while (true)
{
    Console.WriteLine(@"
    - 1: Inserisci un nuovo videogioco;
    - 2: Ricerca un videogioco per id;
    - 3: Ricerca tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input;
    - 4: Cancella un videogioco;
    - 5: Inserisci una nuova software house;
    - 6: Inserisci l'id della software house della quale mostrare i videogames;
    - 7: Chiudi il programma;
    ");


    Console.Write("Seleziona l'opzione desiderata: ");

    int selectOption = int.Parse(Console.ReadLine());

    switch (selectOption)
    {
        case 1:
            Console.WriteLine("Inserisci i dati del nuovo Videogioco: ");
            Console.Write("Inserisci il nome del videogioco: ");
            string name = Console.ReadLine();

            Console.Write("Inserisci la descrizione del videogioco: ");
            string overview = Console.ReadLine();

            Console.Write("Inserisci la data di rilascio del videogioco (dd/mm/yyyy): ");
            DateTime releaseDate;

            while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
                Console.WriteLine("Inserisci formato Valido! (dd/mm/yyyy)");

            Console.Write("Inserisci l'ID della Software House del videogioco: ");
            int softwareHouseId = int.Parse(Console.ReadLine());

            Videogame newVideogame = new Videogame()
            {
                Name = name,
                Overview = overview,
                ReleaseDate = releaseDate,
                SoftwareHouseId = softwareHouseId
            };

            using (VideogameSoftContext db = new VideogameSoftContext())
            {
                try
                {
                    db.Add(newVideogame);
                    db.SaveChanges();

                    Console.WriteLine("Il videogioco è stato aggiunto!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Errore nell'aggiunta del videogioco!");
                }
            }
           break;
        case 2:
            Console.Write("Inserisci l'id del videogioco da cercare: ");
            int idGame = int.Parse(Console.ReadLine());

            Videogame videogameSerched = VideogameManager.SearchById(idGame);

            if (videogameSerched == null)
            {
                Console.WriteLine($"Il videogioco con ID {idGame} non esiste!");
            }
            else
            {
                Console.WriteLine($"Il videogioco con ID {idGame} è: ");
                Console.WriteLine($"- {videogameSerched}");
            }
            Console.WriteLine();
            break;
        case 3:
            Console.WriteLine("Inserisci il nome del gioco da ricercare: ");
            string nameSearch = Console.ReadLine();

            Console.WriteLine(VideogameManager.ListToString(VideogameManager.SearchByName(nameSearch)));

            break;
        case 4:
            Console.Write("Inserisci l'id del videogioco che vuoi eliminare: ");
            int idVideogameToDelete = int.Parse(Console.ReadLine());

            bool deleted = VideogameManager.DeleteVideogame(idVideogameToDelete);

            if (deleted)
            {
                Console.WriteLine($"Il tuo videogioco con ID {idVideogameToDelete} è stato eliminato correttamente!");
            }
            else
            {
                Console.WriteLine("Il videogioco non è stato eliminato!");
            }
            break;
        case 5:
            Console.WriteLine("Inserisci i dati della Software House: ");
            Console.Write("Inserisci il nome della software house: ");
            string nameSoftwareHouse = Console.ReadLine();

            Console.Write("Inserisci il taxID della software house: ");
            string taxId = Console.ReadLine();

            Console.Write("Inserisci la città della software house: ");
            string city = Console.ReadLine();

            Console.Write("Inserisci la nazione della software house: ");
            string country = Console.ReadLine();

            SoftwareHouse newSoftwareHouse = new SoftwareHouse()
            {
                Name = nameSoftwareHouse,
                TaxId = taxId,
                City = city,
                Country = country
            };
            using (VideogameSoftContext db = new VideogameSoftContext())
            {
                try
                {
                    db.Add(newSoftwareHouse);
                    db.SaveChanges();

                    Console.WriteLine("La Software House è stata aggiunta!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Errore nell'aggiunta della software house!");
                }
            }
            break;
        case 6:
            Console.WriteLine("Inserisci id della software-house");

            int idSoftware;
            while (!int.TryParse(Console.ReadLine(), out idSoftware))
                Console.WriteLine("Inserisci un NUMERO!");

            Console.WriteLine(VideogameManager.ListToString(VideogameManager.SearchBySoftwareHouse(idSoftware)));

            break;
        case 7:
            Console.WriteLine("Il programma è chiuso!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Non hai selezionato un opzione valida!");
            break;

    }

}