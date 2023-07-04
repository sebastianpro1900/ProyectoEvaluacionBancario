using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaAPI.Data;
using SistemaAPI.Models.Domain;

namespace SistemaAPI.Repositories
{
    public class SQLCuentaRepository : ICuentaRepository
    {
        private readonly SistemaDbContext dbContext;

        public SQLCuentaRepository(SistemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Cuenta> CreateAsync(Cuenta cuenta)
        {
            await dbContext.Cuentas.AddAsync(cuenta);
            await dbContext.SaveChangesAsync();
            return cuenta;
        }


        // delete
        public async Task<Cuenta?> DeleteAsync(Guid id)
        {
            var existingCuenta = await dbContext.Cuentas.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCuenta != null)
            {
                return null;
            }
            dbContext.Cuentas.Remove(existingCuenta);
            await dbContext.SaveChangesAsync();
            return existingCuenta;
        }



        // meotodo para devolver la lista de cuentas
        public async Task<List<Cuenta>> GetAllAsync()
        {
            return await dbContext.Cuentas.Include("Cliente").ToListAsync();
        }




        // meotodo para actualizar
        public async Task<Cuenta?> UpdateAsync(Guid id, Cuenta cuenta)
        {
            var existingCuenta = await dbContext.Cuentas.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCuenta != null)
            {
                return null;
            }

            existingCuenta.numeroCuenta = cuenta.numeroCuenta;
            existingCuenta.tipoCuenta = cuenta.tipoCuenta;
            existingCuenta.saldoInicial = cuenta.saldoInicial;
            existingCuenta.estado = cuenta.estado;
            existingCuenta.ClienteId = cuenta.ClienteId;

            await dbContext.SaveChangesAsync();
            return existingCuenta;

        }
    }
}
