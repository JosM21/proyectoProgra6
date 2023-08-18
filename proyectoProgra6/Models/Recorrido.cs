using System;
using System.Collections.Generic;

namespace proyectoProgra6.Models
{
    public partial class Recorrido
    {
        public Recorrido()
        {
            Itinerarios = new HashSet<Itinerario>();
        }

        public int IdRecorrido { get; set; }
        public string Fecha { get; set; } = null!;
        public string HoraSalida { get; set; } = null!;
        public string Lugar { get; set; } = null!;
        public string CostoPp { get; set; } = null!;
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }

        public virtual ICollection<Itinerario> Itinerarios { get; set; }
    }
}
