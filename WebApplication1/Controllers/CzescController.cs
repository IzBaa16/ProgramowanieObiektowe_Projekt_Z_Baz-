

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serwis_drugi;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CzescController : ControllerBase
    {
        private readonly ILogger<CzescController> _logger;
        private readonly Context _context;

        public CzescController(ILogger<CzescController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "PobierzCzesc")]
        public Czesc PobierzCzesc(int id)
        {
            return _context.Czesci.FirstOrDefault(x => x.ID == id);
        }

        [HttpGet(Name = "PobierzCzesci")]
        public List<Czesc> PobierzCzesci()
        {
            return _context.Czesci.ToList();
        }

        [HttpPost(Name = "DodajCzesc")]
        public int DodajCzesc(Czesc data)
        {
            _context.Czesci.Add(data);
            _context.SaveChanges();
            return data.ID;
        }

        [HttpPut(Name = "EdytujCzesc")]
        public IActionResult EdytujCzesc(int id, Czesc noweDane)
        {
            var czescToUpdate = _context.Czesci.FirstOrDefault(x => x.ID == id);

            if (czescToUpdate == null)
            {
                return NotFound($"Czesc o ID {id} nie zosta³a znaleziona.");
            }

            // Aktualizuj pola czêœci na podstawie nowych danych
            czescToUpdate.Nazwa = noweDane.Nazwa;
            czescToUpdate.Nazwa2 = noweDane.Nazwa2;
            // Dodaj inne pola czêœci do aktualizacji, jeœli s¹ dostêpne

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete(Name = "UsunCzesc")]
        public IActionResult UsunCzesc(int id)
        {
            var czescToDelete = _context.Czesci.FirstOrDefault(x => x.ID == id);

            if (czescToDelete == null)
            {
                return NotFound($"Czesc o ID {id} nie zosta³a znaleziona.");
            }

            _context.Czesci.Remove(czescToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

