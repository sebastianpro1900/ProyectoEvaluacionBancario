using SistemaAPI.Models.Domain;

namespace SistemaAPI.Models.DTO
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string contrasena { get; set; }
        public string estado { get; set; }
        //public Guid PersonaId { get; set; } lo quito porque no quiero mostrar

        public PersonaDto Persona { get; set; }
    }
}
