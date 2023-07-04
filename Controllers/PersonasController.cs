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
    public class PersonasController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly SistemaDbContext dbContext;
        private readonly IPersonaRepository personaRepository;

        public PersonasController(SistemaDbContext dbContext, IPersonaRepository personaRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.personaRepository = personaRepository;
        }

        // post create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPersonaRequestDto addPersonaRequestDto)
        {
            // mpa dto to domain model
            var personaDomainModel = mapper.Map<Persona>(addPersonaRequestDto);
            await personaRepository.CreateAsync(personaDomainModel);

            // map domain model to dto
            return Ok(mapper.Map<PersonaDto>(personaDomainModel));
        }








        // get listar
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personaDomainModel = await personaRepository.GetAllAsync();

            // map domain model to dto 
            return Ok(mapper.Map<List<PersonaDto>>(personaDomainModel));
        }


        // eliminar delete
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletePersonaDomainModel = await personaRepository.DeleteAsync(id);
            if (deletePersonaDomainModel != null)
            {
                return NotFound();
            }
            // amp domain model to dto
            return Ok(mapper.Map<PersonaDto>(deletePersonaDomainModel));

        }




        // put para actualizar
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, UpdatePersonaRequestDto updatePersonaRequestDto)
        {
            //map dto to domain model
            var personaDomainModel = mapper.Map<Persona>(updatePersonaRequestDto);
            personaDomainModel = await personaRepository.UpdateAsync(id, personaDomainModel);

            if (personaDomainModel != null)
            {
                return NotFound();
            }
            // map domain model to dto 
            return Ok(mapper.Map<PersonaDto>(personaDomainModel));


        }



    }
}
