using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoProgra6.Attributes;
using proyectoProgra6.Models;

namespace proyectoProgra6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ItinerariosController : ControllerBase
    {
        private readonly proyectoProgra6_1Context _context;

        public ItinerariosController(proyectoProgra6_1Context context)
        {
            _context = context;
        }

        // GET: api/Itinerarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itinerario>>> GetItinerarios()
        {
          if (_context.Itinerarios == null)
          {
              return NotFound();
          }
            return await _context.Itinerarios.ToListAsync();
        }

        // GET: api/Itinerarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itinerario>> GetItinerario(int id)
        {
          if (_context.Itinerarios == null)
          {
              return NotFound();
          }
            var itinerario = await _context.Itinerarios.FindAsync(id);

            if (itinerario == null)
            {
                return NotFound();
            }

            return itinerario;
        }

        // PUT: api/Itinerarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItinerario(int id, Itinerario itinerario)
        {
            if (id != itinerario.IdItinerario)
            {
                return BadRequest();
            }

            _context.Entry(itinerario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItinerarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Itinerarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itinerario>> PostItinerario(Itinerario itinerario)
        {
          if (_context.Itinerarios == null)
          {
              return Problem("Entity set 'proyectoProgra6_1Context.Itinerarios'  is null.");
          }
            _context.Itinerarios.Add(itinerario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ItinerarioExists(itinerario.IdItinerario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetItinerario", new { id = itinerario.IdItinerario }, itinerario);
        }

        // DELETE: api/Itinerarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItinerario(int id)
        {
            if (_context.Itinerarios == null)
            {
                return NotFound();
            }
            var itinerario = await _context.Itinerarios.FindAsync(id);
            if (itinerario == null)
            {
                return NotFound();
            }

            _context.Itinerarios.Remove(itinerario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItinerarioExists(int id)
        {
            return (_context.Itinerarios?.Any(e => e.IdItinerario == id)).GetValueOrDefault();
        }
    }
}
