namespace SistemaAPI.Models.Domain
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }
        public Guid PersonaId { get; set; }

        // Propiedades de Navegacion
        public Persona Persona { get; set; }
    }
}
