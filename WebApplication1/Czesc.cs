
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serwis_drugi
{
    public class Czesc
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Nazwa2 { get; set; }

        public Czesc(int id, string nazwa, string nazwa2)
        {
            ID = id;
            Nazwa = nazwa;
            Nazwa2 = nazwa2;
        }

        public Czesc()
        {
                
        }

        public List<Czesc> WczytajZCSV()
        {
            string sciezkaDoPlikuCsv = "czesc.csv";
            var list = new List<Czesc>();
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
                            Czesc czesc = new Czesc(id, kolumny[1], kolumny[1]);
                            list.Add(czesc);
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
                return new List<Czesc>();
            }
        }
    }
}
