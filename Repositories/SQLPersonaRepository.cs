using Microsoft.EntityFrameworkCore;
using SistemaAPI.Data;
using SistemaAPI.Models.Domain;

namespace SistemaAPI.Repositories
{
    public class SQLPersonaRepository : IPersonaRepository
    {
        private readonly SistemaDbContext dbContext;

        public SQLPersonaRepository(SistemaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Persona> CreateAsync(Persona persona)
        {
            await dbContext.Personas.AddAsync(persona);
            await dbContext.SaveChangesAsync();
            return persona;
        }



        // metood para borrar
        public async Task<Persona> DeleteAsync(Guid id)
        {
            var existingPersona = await dbContext.Personas.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPersona != null)
            {
                return null;
            }
            dbContext.Personas.Remove(existingPersona);
            await dbContext.SaveChangesAsync();
            return existingPersona;

        }



        // emtodo para listar
        public async Task<List<Persona>> GetAllAsync()
        {
            return await dbContext.Personas.ToListAsync();
        }


        // update
        public async Task<Persona?> UpdateAsync(Guid id, Persona persona)
        {
            var existingPersona =  await dbContext.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (existingPersona != null)
            {
                return null;
            }

            existingPersona.nombre = persona.nombre;
            existingPersona.genero = persona.genero;
            existingPersona.edad = persona.edad;
            existingPersona.direccion = persona.direccion;
            existingPersona.telefono = persona.telefono;

            await dbContext.SaveChangesAsync();
            return existingPersona; 


        }
    }
}
