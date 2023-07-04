using SistemaAPI.Models.Domain;

namespace SistemaAPI.Repositories
{
    public interface IMovimientoRepository
    {
        Task<Movimiento> CreateAsync(Movimiento movimiento);

        Task<List<Movimiento>> GetAllAsync();

        //delete
        Task<Movimiento?> DeleteAsync(Guid id);

        //update

        Task<Movimiento?> UpdateAsync(Guid id, Movimiento movimiento);

    }
}
