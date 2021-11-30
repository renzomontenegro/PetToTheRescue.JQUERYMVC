using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba2.Models
{
    public partial class Mascotas
    {
        public Mascotas()
        {
            MascotasFotos = new HashSet<MascotasFotos>();
            SolicitarAdopcion = new HashSet<SolicitarAdopcion>();
        }

        public int IdMascota { get; set; }
        public string NombreAnimal { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public byte[] Foto { get; set; }
        public int? ClienteId { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<MascotasFotos> MascotasFotos { get; set; }
        public virtual ICollection<SolicitarAdopcion> SolicitarAdopcion { get; set; }
    }
}
