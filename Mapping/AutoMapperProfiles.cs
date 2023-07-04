using AutoMapper;
using SistemaAPI.Models.Domain;
using SistemaAPI.Models.DTO;

namespace SistemaAPI.Mapping
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            // para Persona
            CreateMap<Persona, PersonaDto>().ReverseMap();
            CreateMap<AddPersonaRequestDto, Persona>().ReverseMap();
            //update
            CreateMap<UpdatePersonaRequestDto,Persona>().ReverseMap();



            // Para Cliente
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<AddClienteRequestDto, Cliente>().ReverseMap();
            //updaate
            CreateMap<UpdateClienteRequestDto, Cliente>().ReverseMap();


            // cuenta
            CreateMap<AddCuentaRequestDto, Cuenta>().ReverseMap();
            CreateMap<Cuenta, CuentaDto>().ReverseMap();
            // update
            CreateMap<UpdateCuentaRequestDto, Cuenta>().ReverseMap();



            // para movimiento
            CreateMap<Movimiento, MovimientoDto>().ReverseMap();
            CreateMap<AddMovimientoRequestDto, Movimiento>().ReverseMap();
            //update
            CreateMap<UpdateMovimientoRequestDto, Movimiento>().ReverseMap();

            //CreateMap<UpdatePersonaRequestDto, Persona>().ReverseMap();

            //CreateMap<AddClienteRequestDto, Cliente>().ReverseMap();
            //CreateMap<Cliente, AddClienteRequestDto>().ReverseMap();
        }
    }
}
