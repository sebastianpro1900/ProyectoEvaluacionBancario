using Microsoft.EntityFrameworkCore;
using SistemaAPI.Models.Domain;

namespace SistemaAPI.Data
{
    public class SistemaDbContext: DbContext
    {
        public SistemaDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Persona> Personas { get; set; }

    }
}
