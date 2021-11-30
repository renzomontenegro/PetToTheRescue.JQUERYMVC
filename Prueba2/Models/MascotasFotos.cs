using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba2.Models
{
    public partial class MascotasFotos
    {
        public int IdMasFoto { get; set; }
        public byte[] Miniatura { get; set; }
        public string MinNombre { get; set; }
        public byte[] LargoFoto { get; set; }
        public string LargNombre { get; set; }
        public DateTime FechaFoto { get; set; }
        public int? MascotasId { get; set; }
        public int? MascotasPerdidasId { get; set; }
        public int? MascotasEnAdopcionId { get; set; }

        public virtual Mascotas Mascotas { get; set; }
        public virtual MascotasEnAdopcion MascotasEnAdopcion { get; set; }
        public virtual MascotasPerdidas MascotasPerdidas { get; set; }
    }
}
