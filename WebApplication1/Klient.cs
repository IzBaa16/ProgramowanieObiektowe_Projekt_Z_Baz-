using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serwis_drugi
{
    public class Klient : Osoba
    {
        public int ID { get; set; }

        public string RodzajProblemu { get; set; }

        public Klient(int id, string imie, string nazwisko, string rodzajProblemu)
        {
            ID = id;
            Imie = imie;
            Nazwisko = nazwisko;
            RodzajProblemu = rodzajProblemu;
        }

        public Klient()
        {
             
        }
       /* public List<Klient> WczytajZCSVklient()
        {
            string sciezkaDoPlikuCsv = "klient.csv";
            var list = new List<Klient>();
            try
            {
                // Otwórz plik do odczytu
                using (StreamReader reader = new StreamReader(sciezkaDoPlikuCsv))
                {
                    while (!reader.EndOfStream)
                    {
                        // Odczytaj linię z pliku
                        string linia = reader.ReadLine();

                        // Podziel linię na kolumny (przyjmujemy, że kolumny są oddzielone przecinkiem)
                        string[] kolumny = linia.Split(',');

                        // Sprawdź, czy udało się prawidłowo odczytać ID i Nazwę
                        if (kolumny.Length >= 2 && int.TryParse(kolumny[0], out int id))
                        {
                            // Utwórz nowy obiekt Czesc i dodaj do listy
                            Klient klient = new Klient(id, kolumny[1], kolumny[2], kolumny[3]);
                            list.Add(klient);
                        }
                        else
                        {
                            Console.WriteLine("Błąd odczytu danych z pliku.");
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas wczytywania pliku: {ex.Message}");
                return new List<Klient>();
            }
        }*/
    }
}
