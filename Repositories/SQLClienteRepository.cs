using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaAPI.Data;
using SistemaAPI.Models.Domain;

namespace SistemaAPI.Repositories
{
    public class SQLClienteRepository : IClienteRepository
    {
        private readonly SistemaDbContext dbContext;

        public SQLClienteRepository(SistemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            await dbContext.Clientes.AddAsync(cliente);
            await dbContext.SaveChangesAsync();
            return cliente;
        }


        // proceso para eliminar
        public async Task<Cliente?> DeleteAsync(Guid id)
        {
            var existingCliente = await dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCliente != null)
            {
                return null;
            }
            dbContext.Clientes.Remove(existingCliente);
            await dbContext.SaveChangesAsync();
            return existingCliente;


        }


        // get listar
        public async Task<List<Cliente>> GetAllAsync()
        {
            return await dbContext.Clientes.Include("Persona").ToListAsync();
        }





        public async Task<Cliente> UpdateAsync(Guid id, Cliente cliente)
        {
            var existingCliente = await dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCliente == null)
            {
                return null;
            }
            existingCliente.contrasena = cliente.contrasena;
            existingCliente.estado = cliente.estado;
            existingCliente.PersonaId = cliente.PersonaId;

            await dbContext.SaveChangesAsync();

            return existingCliente;
        }
    }
}
