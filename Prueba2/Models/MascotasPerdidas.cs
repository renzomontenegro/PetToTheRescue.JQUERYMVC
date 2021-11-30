using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba2.Models
{
    public partial class MascotasPerdidas
    {
        public MascotasPerdidas()
        {
            MascotasFotos = new HashSet<MascotasFotos>();
        }

        public int IdMasPerdida { get; set; }
        public string NombreAnimal { get; set; }
        public string Raza { get; set; }
        public string Color { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string Comentario { get; set; }
        public string NumContacto { get; set; }
        public byte[] Foto { get; set; }
        public int? ClienteId { get; set; }
        public int? AdministradorId { get; set; }

        public virtual Administrador Administrador { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<MascotasFotos> MascotasFotos { get; set; }
    }
}
