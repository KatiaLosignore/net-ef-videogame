// See https://aka.ms/new-console-template for more information

using net_ef_videogame.Database;
using net_ef_videogame.Models;

Console.WriteLine("Benvenuto nel nostro sistema di Videogame e SoftwareHouse!");

while (true)
{
    Console.WriteLine(@"
    - 1: Inserisci un nuovo videogioco;
    - 2: Ricerca un videogioco per id;
    - 3: Ricerca tutti i videogiochi aventi il nome contenente una determinata stringa inserita in input;
    - 4: Cancella un videogioco;
    - 5: Inserisci una nuova software house;
    - 6: Chiudi il programma;
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
        default:
            Console.WriteLine("Non hai selezionato un opzione valida!");
            break;


    }



}