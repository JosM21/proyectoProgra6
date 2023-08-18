using System;
using System.Collections.Generic;

namespace proyectoProgra6.Models
{
    public partial class Viaje
    {
        public Viaje()
        {
            ClienteViajes = new HashSet<ClienteViaje>();
            Itinerarios = new HashSet<Itinerario>();
            Vuelos = new HashSet<Vuelo>();
        }

        public int IdViaje { get; set; }
        public string Destino { get; set; } = null!;
        public string FechaSalida { get; set; } = null!;
        public string FechaRegreso { get; set; } = null!;
        public string Costo { get; set; } = null!;
        public bool? Active { get; set; }
        public bool? IsBlocked { get; set; }
        public int FkHospedaje { get; set; }
        public int? FkUsuario { get; set; }

        public virtual Hospedaje FkHospedajeNavigation { get; set; } = null!;
        public virtual Usuario? FkUsuarioNavigation { get; set; }
        public virtual ICollection<ClienteViaje> ClienteViajes { get; set; }
        public virtual ICollection<Itinerario> Itinerarios { get; set; }
        public virtual ICollection<Vuelo> Vuelos { get; set; }
    }
}
