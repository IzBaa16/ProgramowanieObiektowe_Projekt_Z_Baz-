

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serwis_drugi;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KlientController : ControllerBase
    {
        private readonly ILogger<KlientController> _logger;
        private readonly Context _context;

        public KlientController(ILogger<KlientController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "PobierzKlient")]
        public Klient PobierzKlient(int id)
        {
            return _context.Klienci.FirstOrDefault(x => x.ID == id);
        }

        [HttpGet(Name = "PobierzKlienci")]
        public List<Klient> PobierzKlienci()
        {
            return _context.Klienci.ToList();
        }

        [HttpPost(Name = "DodajKlient")]
        public int DodajKlient(Klient data)
        {
            var result = _context.Klienci.Add(data);
            _context.SaveChanges();
            return result.Entity.ID;
        }

        [HttpPut(Name = "EdytujKlienta")]
        public IActionResult EdytujKlienta(int id, Klient noweDane)
        {
            var klientToUpdate = _context.Klienci.FirstOrDefault(x => x.ID == id);

            if (klientToUpdate == null)
            {
                return NotFound($"Klient o ID {id} nie zosta³ znaleziony.");
            }

            // Aktualizuj pola klienta na podstawie nowych danych
            klientToUpdate.Imie = noweDane.Imie;
            klientToUpdate.Nazwisko = noweDane.Nazwisko;
            klientToUpdate.RodzajProblemu = noweDane.RodzajProblemu;
            // Dodaj inne pola klienta do aktualizacji, jeœli s¹ dostêpne

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete(Name = "UsunKlient")]
        public IActionResult UsunKlient(int id)
        {
            var klientToDelete = _context.Klienci.FirstOrDefault(x => x.ID == id);

            if (klientToDelete == null)
            {
                return NotFound($"Klient o ID {id} nie zosta³ znaleziony.");
            }

            _context.Klienci.Remove(klientToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

