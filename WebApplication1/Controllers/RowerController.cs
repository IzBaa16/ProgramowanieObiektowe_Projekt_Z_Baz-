

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serwis_drugi;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RowerController : ControllerBase
    {

        private readonly ILogger<RowerController> _logger;
        private readonly Context _context;

        public RowerController(ILogger<RowerController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "PobierzRower")]
        public Rower PobierzRower(int id)
        {
            return _context.Rowery.FirstOrDefault(x => x.ID == id);
        }

        [HttpGet(Name = "PobierzRowery")]
        public List<Rower> PobierzRowery()
        {
            return _context.Rowery.ToList();
        }

        [HttpPost(Name = "DodajRower")]
        public int DodajRower(Rower data)
        {
            var result = _context.Rowery.Add(data);
            _context.SaveChanges(); // Use SaveChanges() instead of SaveChangesAsync() for simplicity in this example
            return result.Entity.ID;
        }

        [HttpPut(Name = "EdytujRower")]
        public IActionResult EdytujRower(int id, Rower noweDane)
        {
            var rowerToUpdate = _context.Rowery.FirstOrDefault(x => x.ID == id);

            if (rowerToUpdate == null)
            {
                return NotFound($"Rower o ID {id} nie zosta³ znaleziony.");
            }

            // Aktualizuj pola roweru na podstawie nowych danych
            rowerToUpdate.DataPrzyjecia = noweDane.DataPrzyjecia;
            // Dodaj inne pola roweru do aktualizacji, jeœli s¹ dostêpne

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete(Name = "UsunRower")]
        public IActionResult UsunRower(int id)
        {
            var rowerToDelete = _context.Rowery.FirstOrDefault(x => x.ID == id);

            if (rowerToDelete == null)
            {
                return NotFound($"Rower o ID {id} nie zosta³ znaleziony.");
            }

            _context.Rowery.Remove(rowerToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
