using System;
using System.Collections.Generic;

namespace proyectoProgra6.Models
{
    public partial class Itinerario
    {
        public int FkRecorrido { get; set; }
        public int FkViaje { get; set; }
        public int IdItinerario { get; set; }

        public virtual Recorrido FkRecorridoNavigation { get; set; } = null!;
        public virtual Viaje FkViajeNavigation { get; set; } = null!;
    }
}
