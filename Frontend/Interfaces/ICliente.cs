using Frontend.Models;

namespace Frontend.Interfaces
{
    public interface ICliente
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(int id);

        Task<bool> AddCliente(Cliente cliente);

        Task<bool> UpdateCliente(Cliente cliente);

        Task DeleteCliente(int id);

    }
}
