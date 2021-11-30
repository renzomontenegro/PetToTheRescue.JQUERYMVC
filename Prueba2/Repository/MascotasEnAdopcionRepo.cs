using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetToTheRescue.JQUERYMVC.ViewModel;
using Prueba2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PetToTheRescue.JQUERYMVC.Repository
{
    public class MascotasEnAdopcionRepo
    {
        public static IEnumerable<MascotasEnAdopcion> GetMascotasEnAdopcions()
        {
            using var data = new PetsToTheRescueContext();
            var masenadop = data.MascotasEnAdopcion.ToList();
            return masenadop;
        }

        public static IEnumerable<MascotasEnAdopcion> GetClientesSP()
        {
            using var data = new PetsToTheRescueContext();
            var masenadop = data.MascotasEnAdopcion.FromSqlRaw("SP_GET_MascotasEnAdopcion");
            return masenadop;
        }
        public static async Task<IEnumerable<MascotasEnAdopcionViewModel>> GetClientesAsync()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:22358/api/Clientes/GetClientes");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var clientes = JsonConvert.DeserializeObject<IEnumerable<MascotasEnAdopcionViewModel>>(apiResponse);
            return clientes;
        }

        public static async Task<bool> Insert(Clientes clientes)
        {
            var json = JsonConvert.SerializeObject(clientes);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PostAsync("http://localhost:22358/api/Clientes/PostClientes", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var clientesRespuesta = JsonConvert.DeserializeObject<int>(apiResponse);
            return (clientesRespuesta == 0 ? false : true);
        }
        public static async Task<MascotasEnAdopcionViewModel> GetCliente(int id)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:22358/api/Customer/GetCustomerById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<MascotasEnAdopcionViewModel>(apiResponse);
            return customer;

        }
        public static async Task<bool> Update(Clientes clientes)
        {
            var json = JsonConvert.SerializeObject(clientes);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .PutAsync("http://localhost:22358/api/Clientes/PutCustomer", data);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var clientesRespuesta = JsonConvert.DeserializeObject<int>(apiResponse);
            return (clientesRespuesta == 0 ? false : true);
        }
        public static async Task<bool> Delete(int id)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient
               .DeleteAsync("http://localhost:22358/api/Customer/DeleteCustomer?id=" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 404)
                return false;

            return true;
        }
    }
}

