using System;
using System.Collections.Generic;

namespace proyectoProgra6.Models
{
    public partial class Hospedaje
    {
        public Hospedaje()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int IdHotel { get; set; }
        public string NombreHotel { get; set; } = null!;
        public string Ubicacion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }

        public virtual ICollection<Viaje>? Viajes { get; set; }
    }
}
