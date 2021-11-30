using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba2.Models
{
    public partial class MascotasEnAdopcion
    {
        public MascotasEnAdopcion()
        {
            MascotasFotos = new HashSet<MascotasFotos>();
        }

        public int IdMasAdopcion { get; set; }
        public string NombreAnimal { get; set; }
        public string Raza { get; set; }
        public string Tipo { get; set; }
        public string ColorOjos { get; set; }
        public string ColorPelaje { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string CondMedica { get; set; }
        public string DescAnimal { get; set; }
        public string RazDecision { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string EmaRespaldo { get; set; }
        public string TelRespaldo { get; set; }
        public byte[] Foto { get; set; }
        public int? AdministradorId { get; set; }
        public int? ClienteId { get; set; }

        public virtual Administrador Administrador { get; set; }
        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<MascotasFotos> MascotasFotos { get; set; }
    }
}
