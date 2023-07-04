namespace SistemaAPI.Models.Domain
{
    public class Movimiento
    {
        public Guid Id { get; set; }
        public DateTime fecha { get; set; }
        public string tipoMovimiento { get; set; }
        public float valor { get; set; }
        public float saldo { get; set; }
        public Guid CuentaId { get; set; }

        // Propiedades de Navegacion
        public Cuenta Cuenta { get; set; }
    }
}
