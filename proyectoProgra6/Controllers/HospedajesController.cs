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
    public class HospedajesController : ControllerBase
    {
        private readonly proyectoProgra6_1Context _context;

        public HospedajesController(proyectoProgra6_1Context context)
        {
            _context = context;
        }

        // GET: api/Hospedajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospedaje>>> GetHospedajes()
        {
          if (_context.Hospedajes == null)
          {
              return NotFound();
          }
            return await _context.Hospedajes.ToListAsync();
        }

        // GET: api/Hospedajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospedaje>> GetHospedaje(int id)
        {
          if (_context.Hospedajes == null)
          {
              return NotFound();
          }
            var hospedaje = await _context.Hospedajes.FindAsync(id);

            if (hospedaje == null)
            {
                return NotFound();
            }

            return hospedaje;
        }

        // PUT: api/Hospedajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospedaje(int id, Hospedaje hospedaje)
        {
            if (id != hospedaje.IdHotel)
            {
                return BadRequest();
            }

            _context.Entry(hospedaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospedajeExists(id))
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

        // POST: api/Hospedajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hospedaje>> PostHospedaje(Hospedaje hospedaje)
        {
          if (_context.Hospedajes == null)
          {
              return Problem("Entity set 'proyectoProgra6_1Context.Hospedajes'  is null.");
          }
            _context.Hospedajes.Add(hospedaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHospedaje", new { id = hospedaje.IdHotel }, hospedaje);
        }

        // DELETE: api/Hospedajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospedaje(int id)
        {
            if (_context.Hospedajes == null)
            {
                return NotFound();
            }
            var hospedaje = await _context.Hospedajes.FindAsync(id);
            if (hospedaje == null)
            {
                return NotFound();
            }

            _context.Hospedajes.Remove(hospedaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospedajeExists(int id)
        {
            return (_context.Hospedajes?.Any(e => e.IdHotel == id)).GetValueOrDefault();
        }
    }
}
