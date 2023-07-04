using SistemaAPI.Models.Domain;

namespace SistemaAPI.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> CreateAsync(Cliente cliente);
        Task<List<Cliente>> GetAllAsync();

        Task<Cliente> UpdateAsync(Guid id, Cliente cliente);

        //eliminar
        Task<Cliente?>DeleteAsync(Guid id);

    }
}
