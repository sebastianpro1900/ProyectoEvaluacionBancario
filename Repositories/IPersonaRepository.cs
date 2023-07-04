using SistemaAPI.Models.Domain;

namespace SistemaAPI.Repositories
{
    public interface IPersonaRepository
    {
        Task<Persona> CreateAsync(Persona persona);
        Task<List<Persona>> GetAllAsync();
        Task<Persona?> DeleteAsync(Guid id);

        //update
        Task<Persona?> UpdateAsync(Guid id, Persona persona);

    }
}
