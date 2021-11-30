using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Prueba2.Models;
using Prueba2.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2.Repository
{
    public class ClientesRepo
    {
        public static IEnumerable<Clientes> GetClientes()
        {
            using var data = new PetsToTheRescueContext();
            var customers = data.Clientes.ToList();
            return customers;
        }

        public static  IEnumerable<Clientes> GetClientesSP()
        {
            using var data = new PetsToTheRescueContext();
            var clientes = data.Clientes.FromSqlRaw("SP_GET_Clientes");
            return clientes;
        }
        public static async Task<IEnumerable<ClientesViewModel>> GetClientesAsync()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:22358/api/Clientes/GetClientes");
            string apiResponse = await response.Content.ReadAsStringAsync();
            var clientes = JsonConvert.DeserializeObject<IEnumerable<ClientesViewModel>>(apiResponse);
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
        public static async Task<ClientesViewModel> GetCliente(int id)
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync("http://localhost:22358/api/Customer/GetCustomerById/" + id);
            string apiResponse = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<ClientesViewModel>(apiResponse);
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
