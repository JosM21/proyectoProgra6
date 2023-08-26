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
    //[ApiKey]
    public class VuelosController : ControllerBase
    {
        private readonly proyectoProgra6_1Context _context;

        public VuelosController(proyectoProgra6_1Context context)
        {
            _context = context;
        }



        // GET: api/Vuelos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelo>>> GetVuelos()
        {
          if (_context.Vuelos == null)
          {
              return NotFound();
          }
            return await _context.Vuelos.ToListAsync();
        }

        //GET: api/Protocols/GetProtocolListByUser?id=4
        //Pensando en colecciones observables esta función podría entregar un enumerable
        //(obviamente usamos su interface)
        [HttpGet("GetVuelosListByID")]
        public async Task<ActionResult<IEnumerable<Vuelo>>> GetVuelosListByID(int id)
        {
            if (_context.Vuelos == null)
            {
                return NotFound();
            }
            var vuelosList = await _context.Vuelos.Where(p => p.IdVuelo.Equals(id)).ToListAsync();

            if (vuelosList == null)
            {
                return NotFound();
            }

            return vuelosList;
        }

        // GET: api/Vueloes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vuelo>> GetVuelo(int id)
        {
          if (_context.Vuelos == null)
          {
              return NotFound();
          }
            var vuelo = await _context.Vuelos.FindAsync(id);

            if (vuelo == null)
            {
                return NotFound();
            }

            return vuelo;
        }

        // PUT: api/Vueloes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVuelo(int id, Vuelo vuelo)
        {
            if (id != vuelo.IdVuelo)
            {
                return BadRequest();
            }

            _context.Entry(vuelo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VueloExists(id))
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

        // POST: api/Vueloes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vuelo>> PostVuelo(Vuelo vuelo)
        {
          if (_context.Vuelos == null)
          {
              return Problem("Entity set 'proyectoProgra6_1Context.Vuelos'  is null.");
          }
            _context.Vuelos.Add(vuelo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVuelo", new { id = vuelo.IdVuelo }, vuelo);
        }

        // DELETE: api/Vueloes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVuelo(int id)
        {
            if (_context.Vuelos == null)
            {
                return NotFound();
            }
            var vuelo = await _context.Vuelos.FindAsync(id);
            if (vuelo == null)
            {
                return NotFound();
            }

            _context.Vuelos.Remove(vuelo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VueloExists(int id)
        {
            return (_context.Vuelos?.Any(e => e.IdVuelo == id)).GetValueOrDefault();
        }
    }
}
