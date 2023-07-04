namespace SistemaAPI.Models.DTO
{
    public class MovimientoDto
    {
        public Guid Id { get; set; }
        public DateTime fecha { get; set; }
        public string tipoMovimiento { get; set; }
        public float valor { get; set; }
        public float saldo { get; set; }
        //public Guid CuentaId { get; set; } le oculto porque ya sale toda la data de cuenta

        public CuentaDto Cuenta { get; set; }
    }
}
