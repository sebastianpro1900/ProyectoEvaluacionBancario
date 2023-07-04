using SistemaAPI.Models.Domain;

namespace SistemaAPI.Models.DTO
{
    public class UpdateClienteRequestDto
    {
        public string contrasena { get; set; }
        public string estado { get; set; }
        public Guid PersonaId { get; set; }




    }
}
