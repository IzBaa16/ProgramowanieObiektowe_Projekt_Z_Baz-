
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serwis_drugi;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PracownikSerwisuController : ControllerBase
    {

        private readonly ILogger<PracownikSerwisuController> _logger;
        private readonly Context _context;

        public PracownikSerwisuController(ILogger<PracownikSerwisuController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "PobierzPracownikSerwisu")]
        public PracownikSerwisu PobierzPracownikSerwisu(int id)
        {
            return _context.PracownicySerwisu.FirstOrDefault(x => x.ID == id);
        }

        [HttpGet(Name = "PobierzPracownikSerwisow")]
        public List<PracownikSerwisu> PobierzPracownikSerwisow()
        {
            return _context.PracownicySerwisu.ToList();
        }

        [HttpPost(Name = "DodajPracownikSerwisu")]
        public int DodajPracownikSerwisu(PracownikSerwisu data)
        {
            var result = _context.PracownicySerwisu.Add(data);
            _context.SaveChanges(); // Use SaveChanges() instead of SaveChangesAsync() for simplicity in this example
            return result.Entity.ID;
        }

        [HttpPut(Name = "EdytujPracownikSerwisu")]
        public IActionResult EdytujPracownikSerwisu(int id, PracownikSerwisu noweDane)
        {
            var pracownikSerwisuToUpdate = _context.PracownicySerwisu.FirstOrDefault(x => x.ID == id);

            if (pracownikSerwisuToUpdate == null)
            {
                return NotFound($"Pracownik serwisu o ID {id} nie zosta³ znaleziony.");
            }

            // Aktualizuj pola pracownika serwisu na podstawie nowych danych
            pracownikSerwisuToUpdate.Imie = noweDane.Imie;
            pracownikSerwisuToUpdate.Nazwisko = noweDane.Nazwisko;
            pracownikSerwisuToUpdate.Doswiadczenie = noweDane.Doswiadczenie;
            // Dodaj inne pola pracownika serwisu do aktualizacji, jeœli s¹ dostêpne

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete(Name = "UsunPracownikSerwisu")]
        public IActionResult UsunPracownikSerwisu(int id)
        {
            var pracownikSerwisuToDelete = _context.PracownicySerwisu.FirstOrDefault(x => x.ID == id);

            if (pracownikSerwisuToDelete == null)
            {
                return NotFound($"Pracownik serwisu o ID {id} nie zosta³ znaleziony.");
            }

            _context.PracownicySerwisu.Remove(pracownikSerwisuToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

