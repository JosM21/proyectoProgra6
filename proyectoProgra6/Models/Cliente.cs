using System;
using System.Collections.Generic;

namespace proyectoProgra6.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteViajes = new HashSet<ClienteViaje>();
        }

        public int IdCliente { get; set; }
        public string Cedula { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NombreCompleto { get; set; } = null!;
        public string FechaNacimiento { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string? Direccion { get; set; }
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }

        public virtual ICollection<ClienteViaje> ClienteViajes { get; set; }
    }
}
