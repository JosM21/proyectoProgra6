using System;
using System.Collections.Generic;

namespace proyectoProgra6.Models
{
    public partial class UsuarioRol
    {
        public UsuarioRol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdUsuarioRol { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
