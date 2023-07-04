namespace SistemaAPI.Models.Domain
{
    public class Cuenta
    {
        public Guid Id { get; set; }
        public int numeroCuenta { get; set; }
        public string tipoCuenta { get; set; }
        public float saldoInicial { get; set; }
        public string estado { get; set; }

        public Guid ClienteId { get; set; }


        // Propuiedades de navegacion
        public Cliente Cliente { get; set; }
    }
}
