using SistemaAPI.Models.Domain;

namespace SistemaAPI.Repositories
{
    public interface ICuentaRepository
    {
        Task<Cuenta> CreateAsync(Cuenta cuenta);

        Task<List<Cuenta>> GetAllAsync();

        //delete
        Task<Cuenta?> DeleteAsync(Guid id);

        //update
        Task<Cuenta?> UpdateAsync(Guid id, Cuenta cuenta);


    }
}
