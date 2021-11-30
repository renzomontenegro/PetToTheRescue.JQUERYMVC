using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba2.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Mascotas = new HashSet<Mascotas>();
            MascotasEnAdopcion = new HashSet<MascotasEnAdopcion>();
            MascotasPerdidas = new HashSet<MascotasPerdidas>();
        }

        public int IdCliente { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Contrasenia { get; set; }
        public string NumDocumento { get; set; }
        public DateTime HoraMomento { get; set; }

        public virtual ICollection<Mascotas> Mascotas { get; set; }
        public virtual ICollection<MascotasEnAdopcion> MascotasEnAdopcion { get; set; }
        public virtual ICollection<MascotasPerdidas> MascotasPerdidas { get; set; }
    }
}
