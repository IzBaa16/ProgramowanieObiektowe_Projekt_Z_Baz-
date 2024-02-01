/*using Microsoft.AspNetCore.Mvc;
using serwis_drugi;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NaprawaController : ControllerBase
    {

        private readonly ILogger<NaprawaController> _logger;
        private readonly Context _context;

        public NaprawaController(ILogger<NaprawaController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "PobierzNaprawa")]
        public Naprawa GetNaprawa(int id)
        {
            return _context.Naprawy.FirstOrDefault(x => x.ID == id);
        }

        [HttpGet(Name = "PobierzNaprawy")]
        public List<Naprawa> GetNaprawy()
        {
            return _context.Naprawy.ToList();
        }

        [HttpPost(Name = "DodajNaprawa")]   
        public int DodajNaprawa(Naprawa data)
        {
            var result = _context.Naprawy.Add(data);
            _context.SaveChangesAsync();
            return result.Entity.ID;
        }

    }
}


using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serwis_drugi;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NaprawaController : ControllerBase
    {

        private readonly ILogger<NaprawaController> _logger;
        private readonly Context _context;

        public NaprawaController(ILogger<NaprawaController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "PobierzNaprawa")]
        public Naprawa GetNaprawa(int id)
        {
            return _context.Naprawy.FirstOrDefault(x => x.ID == id);
        }

        [HttpGet(Name = "PobierzNaprawy")]
        public List<Naprawa> GetNaprawy()
        {
            return _context.Naprawy.ToList();
        }

        [HttpPost(Name = "DodajNaprawa")]   
        public int DodajNaprawa(Naprawa data)
        {
            var result = _context.Naprawy.Add(data);
            _context.SaveChanges(); // Use SaveChanges() instead of SaveChangesAsync() for simplicity in this example
            return result.Entity.ID;
        }




        [HttpDelete(Name = "UsunNaprawa")]
        public IActionResult UsunNaprawa(int id)
        {
            var naprawaToDelete = _context.Naprawy.FirstOrDefault(x => x.ID == id);

            if (naprawaToDelete == null)
            {
                return NotFound($"Naprawa o ID {id} nie zosta³a znaleziona.");
            }

            _context.Naprawy.Remove(naprawaToDelete);
            _context.SaveChanges(); // Use SaveChanges() instead of SaveChangesAsync() for simplicity in this example

            return NoContent();
        }
    }
}
*/

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using serwis_drugi;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NaprawaController : ControllerBase
    {

        private readonly ILogger<NaprawaController> _logger;
        private readonly Context _context;

        public NaprawaController(ILogger<NaprawaController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "PobierzNaprawa")]
        public Naprawa PobierzNaprawa(int id)
        {
            return _context.Naprawy.FirstOrDefault(x => x.ID == id);
        }

        [HttpGet(Name = "PobierzNaprawy")]
        public List<Naprawa> PobierzNaprawy()
        {
            return _context.Naprawy.ToList();
        }

        [HttpPost(Name = "DodajNaprawa")]
        public int DodajNaprawa(Naprawa data)
        {
            var result = _context.Naprawy.Add(data);
            _context.SaveChanges(); // Use SaveChanges() instead of SaveChangesAsync() for simplicity in this example
            return result.Entity.ID;
        }

        [HttpPut(Name = "EdytujNaprawe")]
        public IActionResult EdytujNaprawe(int id, Naprawa noweDane)
        {
            var naprawaToUpdate = _context.Naprawy.FirstOrDefault(x => x.ID == id);

            if (naprawaToUpdate == null)
            {
                return NotFound($"Naprawa o ID {id} nie zosta³a znaleziona.");
            }

            // Aktualizuj pola naprawy na podstawie nowych danych
            //naprawaToUpdate.Opis = noweDane.Opis;
            naprawaToUpdate.Koszt = noweDane.Koszt;
            naprawaToUpdate.Rower = noweDane.Rower;
            naprawaToUpdate.RowerId = noweDane.RowerId;
            // Dodaj inne pola naprawy do aktualizacji, jeœli s¹ dostêpne

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete(Name = "UsunNaprawa")]
        public IActionResult UsunNaprawa(int id)
        {
            var naprawaToDelete = _context.Naprawy.FirstOrDefault(x => x.ID == id);

            if (naprawaToDelete == null)
            {
                return NotFound($"Naprawa o ID {id} nie zosta³a znaleziona.");
            }

            _context.Naprawy.Remove(naprawaToDelete);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
