using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba2.Models
{
    public partial class SolicitarAdopcion
    {
        public int IdMascotas { get; set; }
        public string Experiencia { get; set; }
        public string RazAdopcion { get; set; }
        public string Actividades { get; set; }
        public string TiempoFuera { get; set; }
        public string Viaje { get; set; }
        public string MasCasa { get; set; }
        public string Veterinaria { get; set; }
        public string EstEconomica { get; set; }
        public string Vivienda { get; set; }
        public int? MainMascotaId { get; set; }

        public virtual Mascotas MainMascota { get; set; }
    }
}
