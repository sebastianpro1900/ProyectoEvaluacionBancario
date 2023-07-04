using Microsoft.EntityFrameworkCore;
using SistemaAPI.Data;
using SistemaAPI.Models.Domain;

namespace SistemaAPI.Repositories
{
    public class SQLMovimientoRepository : IMovimientoRepository
    {
        private readonly SistemaDbContext dbContext;

        public SQLMovimientoRepository(SistemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Movimiento> CreateAsync(Movimiento movimiento)
        {
            await dbContext.Movimientos.AddAsync(movimiento);
            await dbContext.SaveChangesAsync();
            return movimiento;
        }


        // meotod para eliminar
        public async Task<Movimiento?> DeleteAsync(Guid id)
        {
            var existingMovimiento =  await dbContext.Movimientos.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMovimiento != null)
            {
                return null;
            }
            dbContext.Movimientos.Remove(existingMovimiento);
            await dbContext.SaveChangesAsync();
            return existingMovimiento;

        }


        // metodo para listar
        public async Task<List<Movimiento>> GetAllAsync()
        {
            return await dbContext.Movimientos.Include("Cuenta").ToListAsync();
        }



        //update
        public async Task<Movimiento?> UpdateAsync(Guid id, Movimiento movimiento)
        {
            var existingMoviemiento = await dbContext.Movimientos.FirstOrDefaultAsync(x =>x.Id == id);
            if(existingMoviemiento != null)
            {
                return null;
            }
            existingMoviemiento.fecha = movimiento.fecha;
            existingMoviemiento.tipoMovimiento = movimiento.tipoMovimiento;
            existingMoviemiento.valor = movimiento.valor;
            existingMoviemiento.saldo = movimiento.saldo;
            existingMoviemiento.CuentaId = movimiento.CuentaId;
            await dbContext.SaveChangesAsync();
            return existingMoviemiento;



        }
    }
}
