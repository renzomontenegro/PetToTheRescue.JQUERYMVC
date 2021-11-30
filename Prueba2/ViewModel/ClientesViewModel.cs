using System;
using System.Collections.Generic;

namespace Prueba2.ViewModel
{
    public class ClientesViewModel
    {
        public int idCliente { get; set; }
        public string usuario { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string contrasenia { get; set; }
        public string numDocumento { get; set; }
        public DateTime horaMomento { get; set; }
    }
}
