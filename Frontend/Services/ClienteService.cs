using Frontend.Interfaces;
using Frontend.Models;
using System.Text;
using System.Text.Json;

namespace Frontend.Services
{
    public class ClienteService: ICliente
    {
        private readonly HttpClient _httpClient;

        public ClienteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddCliente(Cliente cliente)
        {
            var clienteJson = new StringContent(JsonSerializer.Serialize(cliente),
                Encoding.UTF8,"application/json");

            var result = await _httpClient.PostAsJsonAsync("api/clientes",clienteJson);

            if(result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task <bool> DeleteCliente(int id)
        {

            var result = await _httpClient.DeleteAsync($"api/clientes/{id}");

            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;

        }

        public async Task<Cliente> GetCliente(int id)
        {
            var listado = await JsonSerializer.DeserializeAsync<IEnumerable<Cliente>>(
                await _httpClient.GetStreamAsync("api/clientes"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});

            var cliente = listado.Where(c => c.ClienteId == id).First();
            return cliente;

        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
           return await JsonSerializer.DeserializeAsync<IEnumerable<Cliente>>(
                await _httpClient.GetStreamAsync("api/clientes"),
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var clienteJson = new StringContent(JsonSerializer.Serialize(cliente),
              Encoding.UTF8, "application/json");

            var result = await _httpClient.PutAsync($"api/clientes/{cliente.ClienteId}", clienteJson);

            if (result.IsSuccessStatusCode)
                return true;
            else
                return false;
        }


    }
}
