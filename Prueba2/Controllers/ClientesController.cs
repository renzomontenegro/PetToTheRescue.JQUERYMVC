using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba2.Models;
using Prueba2.Repository;

namespace Prueba2.Controllers
{
    public class ClientesController : Controller
    {

        public async Task<IActionResult> Eliminar(int idCliente)
        {
            bool exito = await ClientesRepo.Delete(idCliente);
            return Json(exito);
        }


        public async Task<IActionResult> Obtener(int idCliente)
        {
            var customer = await ClientesRepo.GetCliente(idCliente);
            return Json(customer);
        }


        public async Task<IActionResult> Listado()
        {
            var customers = await ClientesRepo.GetClientesAsync();
            return PartialView(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Grabar(int idCliente, string nombre, string usuario,
            string apellido, string contrasenia, string numDocumento, DateTime horaMomento)
        {

            var clientes = new Clientes()
            {
                IdCliente= idCliente,  
                Usuario = usuario,
                Nombre = nombre,
                Apellidos = apellido,
                Contrasenia = contrasenia,
                NumDocumento = numDocumento,
                HoraMomento = horaMomento,
            };
            bool exito = true;
            if (idCliente == -1)
                exito = await ClientesRepo.Insert(clientes);
            else
            {
                clientes.IdCliente = idCliente;
                exito = await ClientesRepo.Update(clientes);
            }
            return Json(exito);
        }
    }
}
