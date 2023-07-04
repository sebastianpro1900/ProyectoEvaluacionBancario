namespace SistemaAPI.Models.DTO
{
    public class AddMovimientoRequestDto
    {
        public DateTime fecha { get; set; }
        public string tipoMovimiento { get; set; }
        public float valor { get; set; }
        public float saldo { get; set; }
        public Guid CuentaId { get; set; }
    }
}
