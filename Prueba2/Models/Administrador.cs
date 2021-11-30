using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba2.Models
{
    public partial class Administrador
    {
        public Administrador()
        {
            MascotasEnAdopcion = new HashSet<MascotasEnAdopcion>();
            MascotasPerdidas = new HashSet<MascotasPerdidas>();
        }

        public int IdAdministrador { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Contrasenia { get; set; }
        public string NumDocumento { get; set; }
        public DateTime HoraMomento { get; set; }

        public virtual ICollection<MascotasEnAdopcion> MascotasEnAdopcion { get; set; }
        public virtual ICollection<MascotasPerdidas> MascotasPerdidas { get; set; }
    }
}
