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
    public class ClienteViajesController : ControllerBase
    {
        private readonly proyectoProgra6_1Context _context;

        public ClienteViajesController(proyectoProgra6_1Context context)
        {
            _context = context;
        }

        // GET: api/ClienteViajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViaje>>> GetClienteViajes()
        {
          if (_context.ClienteViajes == null)
          {
              return NotFound();
          }
            return await _context.ClienteViajes.ToListAsync();
        }

        // GET: api/ClienteViajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViaje>> GetClienteViaje(int id)
        {
          if (_context.ClienteViajes == null)
          {
              return NotFound();
          }
            var clienteViaje = await _context.ClienteViajes.FindAsync(id);

            if (clienteViaje == null)
            {
                return NotFound();
            }

            return clienteViaje;
        }

        // PUT: api/ClienteViajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteViaje(int id, ClienteViaje clienteViaje)
        {
            if (id != clienteViaje.IdClienteViaje)
            {
                return BadRequest();
            }

            _context.Entry(clienteViaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteViajeExists(id))
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

        // POST: api/ClienteViajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ClienteViaje>> PostClienteViaje(ClienteViaje clienteViaje)
        {
          if (_context.ClienteViajes == null)
          {
              return Problem("Entity set 'proyectoProgra6_1Context.ClienteViajes'  is null.");
          }
            _context.ClienteViajes.Add(clienteViaje);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ClienteViajeExists(clienteViaje.IdClienteViaje))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetClienteViaje", new { id = clienteViaje.IdClienteViaje }, clienteViaje);
        }

        // DELETE: api/ClienteViajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteViaje(int id)
        {
            if (_context.ClienteViajes == null)
            {
                return NotFound();
            }
            var clienteViaje = await _context.ClienteViajes.FindAsync(id);
            if (clienteViaje == null)
            {
                return NotFound();
            }

            _context.ClienteViajes.Remove(clienteViaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteViajeExists(int id)
        {
            return (_context.ClienteViajes?.Any(e => e.IdClienteViaje == id)).GetValueOrDefault();
        }
    }
}
