using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoProgra6.Attributes;
using proyectoProgra6.Models;
using proyectoProgra6.ModelsDTOs;

namespace proyectoProgra6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiKey]
    public class UsuariosController : ControllerBase
    {
        private readonly proyectoProgra6_1Context _context;

        public UsuariosController(proyectoProgra6_1Context context)
        {
            _context = context;
        }

        [HttpGet("ValidateLogin")]
        public async Task<ActionResult<Usuario>> ValidateLogin(string username, string password)
        {
            var user = await _context.Usuarios.SingleOrDefaultAsync(e => e.Email.Equals(username) &&
                                                                 e.Contrasenia == password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (_context.Usuarios == null)
          {
              return NotFound();
          }
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }


        [HttpGet("GetUserInfoByEmail")]
        public ActionResult<IEnumerable<UsuarioDTO>> GetUserInfoByEmail(string Pemail)
        {
            //acá creamos un linq que combina información de dos entidades 
            //(user inner join userrole) y la agreaga en el objeto dto de usuario 

            var query = (from u in _context.Usuarios
                         join ur in _context.UsuarioRols on
                         u.FkUsuarioRol equals ur.IdUsuarioRol
                         where u.Email == Pemail && u.Active == true &&
                         u.IsBlocked == false
                         select new
                         {
                             iduser = u.IdUsuario,
                             email = u.Email,
                             password = u.Contrasenia,
                             name = u.Nombre,
                             backupemail = u.BackUpEmail,
                             phone = u.Telefono,
                             address = u.Direccion,
                             active = u.Active,
                             isBlocked = u.IsBlocked,
                             idrol = ur.IdUsuarioRol,
                             descripcionrol = ur.Descripcion
                         }).ToList();


            //creamos un objeto del tipo que retorna la función 
            List<UsuarioDTO> list = new List<UsuarioDTO>();

            foreach (var item in query)
            {
                UsuarioDTO NewItem = new UsuarioDTO()
                {
                    IDUser = item.iduser,
                    Email = item.email,
                    Password = item.password,
                    Name = item.name,
                    BackupEmail = item.backupemail,
                    Phone = item.phone,
                    Addres = item.address,
                    Activa = item.active,
                    ItsBlocked = item.isBlocked,
                    IDRol = item.idrol,
                    DescriptionRol = item.descripcionrol
                };

                list.Add(NewItem);
            }

            if (list == null) { return NotFound(); }

            return list;

        }


        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
          if (_context.Usuarios == null)
          {
              return Problem("Entity set 'proyectoProgra6_1Context.Usuarios'  is null.");
          }
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

      

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
