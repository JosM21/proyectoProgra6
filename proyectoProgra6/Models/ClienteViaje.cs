using System;
using System.Collections.Generic;

namespace proyectoProgra6.Models
{
    public partial class ClienteViaje
    {
        public int FkCliente { get; set; }
        public int FkViaje { get; set; }
        public int IdClienteViaje { get; set; }

        public virtual Cliente FkClienteNavigation { get; set; } = null!;
        public virtual Viaje FkViajeNavigation { get; set; } = null!;
    }
}
