using System;
using System.Collections.Generic;

namespace proyectoProgra6.Models
{
    public  partial class Usuario
    {
        public Usuario()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int FkUsuarioRol { get; set; }

        public virtual UsuarioRol FkUsuarioRolNavigation { get; set; } = null!;
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
