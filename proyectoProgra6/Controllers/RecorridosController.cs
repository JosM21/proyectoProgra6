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
    public class RecorridosController : ControllerBase
    {
        private readonly proyectoProgra6_1Context _context;

        public RecorridosController(proyectoProgra6_1Context context)
        {
            _context = context;
        }

        //GET: api/Protocols/GetProtocolListByUser?id=4
        //Pensando en colecciones observables esta función podría entregar un enumerable
        //(obviamente usamos su interface)
        [HttpGet("GetRecorridoListByID")]
        public async Task<ActionResult<IEnumerable<Recorrido>>> GetRecorridoListByID(int id)
        {
            if (_context.Recorridos == null)
            {
                return NotFound();
            }
            var recorridoList = await _context.Recorridos.Where(p => p.IdRecorrido.Equals(id)).ToListAsync();

            if (recorridoList == null)
            {
                return NotFound();
            }

            return recorridoList;
        }

        // GET: api/Recorridos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recorrido>>> GetRecorridos()
        {
          if (_context.Recorridos == null)
          {
              return NotFound();
          }
            return await _context.Recorridos.ToListAsync();
        }

        // GET: api/Recorridos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recorrido>> GetRecorrido(int id)
        {
          if (_context.Recorridos == null)
          {
              return NotFound();
          }
            var recorrido = await _context.Recorridos.FindAsync(id);

            if (recorrido == null)
            {
                return NotFound();
            }

            return recorrido;
        }

        // PUT: api/Recorridos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecorrido(int id, Recorrido recorrido)
        {
            if (id != recorrido.IdRecorrido)
            {
                return BadRequest();
            }

            _context.Entry(recorrido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecorridoExists(id))
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

        // POST: api/Recorridos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recorrido>> PostRecorrido(Recorrido recorrido)
        {
          if (_context.Recorridos == null)
          {
              return Problem("Entity set 'proyectoProgra6_1Context.Recorridos'  is null.");
          }
            _context.Recorridos.Add(recorrido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecorrido", new { id = recorrido.IdRecorrido }, recorrido);
        }

        // DELETE: api/Recorridos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecorrido(int id)
        {
            if (_context.Recorridos == null)
            {
                return NotFound();
            }
            var recorrido = await _context.Recorridos.FindAsync(id);
            if (recorrido == null)
            {
                return NotFound();
            }

            _context.Recorridos.Remove(recorrido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecorridoExists(int id)
        {
            return (_context.Recorridos?.Any(e => e.IdRecorrido == id)).GetValueOrDefault();
        }
    }
}
