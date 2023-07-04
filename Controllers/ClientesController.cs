using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaAPI.Data;
using SistemaAPI.Models.Domain;
using SistemaAPI.Models.DTO;
using SistemaAPI.Repositories;

namespace SistemaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly SistemaDbContext dbContext;
        private readonly IClienteRepository clienteRepository;


        public ClientesController(SistemaDbContext dbContext, IClienteRepository clienteRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;

        }

        // post create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddClienteRequestDto addClienteRequestDto)
        {
            // mpa dto to domain model
            var clienteDomainModel = mapper.Map<Cliente>(addClienteRequestDto);
            await clienteRepository.CreateAsync(clienteDomainModel);

            // map domain model to dto
            return Ok(mapper.Map<ClienteDto>(clienteDomainModel));
        }


        // get listar
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clienteDomainModel = await clienteRepository.GetAllAsync();

            // map domain model to dto 
            return Ok(mapper.Map<List<ClienteDto>>(clienteDomainModel));
        }


        // put update 
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateClienteRequestDto updateClienteRequestDto)
        {
            // map dto to domain model
            var clienteDomainModel = mapper.Map<Cliente>(updateClienteRequestDto);
            clienteDomainModel = await clienteRepository.UpdateAsync(id, clienteDomainModel);

            if (clienteDomainModel != null)
            {
                return NotFound();
            }
            // map domain model to dto
            return Ok(mapper.Map<ClienteDto>(clienteDomainModel));
        }




        // delete
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteDomainModel = await clienteRepository.DeleteAsync(id);
            if (deleteDomainModel != null)
            {
                return NotFound();
            }
            //map domain model to dto

            return Ok(mapper.Map<ClienteDto>(deleteDomainModel));



        }







    }
}
