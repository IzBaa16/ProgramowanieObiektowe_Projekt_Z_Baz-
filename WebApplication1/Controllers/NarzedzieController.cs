

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serwis_drugi;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NarzedzieController : ControllerBase
    {

        private readonly ILogger<NarzedzieController> _logger;
        private readonly Context _context;

        public NarzedzieController(ILogger<NarzedzieController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "PobierzNarzedzie")]
        public Narzedzie PobierzNarzedzie(int id)
        {
            return _context.Narzedzia.FirstOrDefault(x => x.ID == id);
        }

        [HttpGet(Name = "PobierzNarzedzia")]
        public List<Narzedzie> PobierzNarzedzia()
        {
            return _context.Narzedzia.ToList();
        }


        [HttpPost(Name = "DodajNarzedzie")]
        public int DodajNarzedzie(Narzedzie data)
        {
            var result = _context.Narzedzia.Add(data);
            _context.SaveChanges(); // Use SaveChanges() instead of SaveChangesAsync() for simplicity in this example
            return result.Entity.ID;
        }

        [HttpPut(Name = "EdytujNarzedzie")]
        public IActionResult EdytujNarzedzie(int id, Narzedzie noweDane)
        {
            var narzedzieToUpdate = _context.Narzedzia.FirstOrDefault(x => x.ID == id);

            if (narzedzieToUpdate == null)
            {
                return NotFound($"Narzêdzie o ID {id} nie zosta³o znalezione.");
            }

            // Aktualizuj pola narzêdzia na podstawie nowych danych
            narzedzieToUpdate.Rodzaj = noweDane.Rodzaj;
            narzedzieToUpdate.Wytrzymalosc = noweDane.Wytrzymalosc;
            // Dodaj inne pola narzêdzia do aktualizacji, jeœli s¹ dostêpne

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete(Name = "UsunNarzedzie")]
        public IActionResult UsunNarzedzie(int id)
        {
            var narzedzieToDelete = _context.Narzedzia.FirstOrDefault(x => x.ID == id);

            if (narzedzieToDelete == null)
            {
                return NotFound($"Narzêdzie o ID {id} nie zosta³o znalezione.");
            }

            _context.Narzedzia.Remove(narzedzieToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
