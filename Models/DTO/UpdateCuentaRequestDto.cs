namespace SistemaAPI.Models.DTO
{
    public class UpdateCuentaRequestDto
    {
        public int numeroCuenta { get; set; }
        public string tipoCuenta { get; set; }
        public float saldoInicial { get; set; }
        public string estado { get; set; }

        public Guid ClienteId { get; set; }
    }
}
