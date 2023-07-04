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
    public class CuentasController : ControllerBase
    {
        private readonly SistemaDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ICuentaRepository cuentaRepository;

        //crete post
        public CuentasController(SistemaDbContext dbContext, IMapper mapper, ICuentaRepository cuentaRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.cuentaRepository = cuentaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCuentaRequestDto addCuentaRequestDto)
        {
            // map dto to domain model
            var cuentaDomainModel = mapper.Map<Cuenta>(addCuentaRequestDto);
            await cuentaRepository.CreateAsync(cuentaDomainModel);

            // map domain model to dto
            return Ok(mapper.Map<CuentaDto>(cuentaDomainModel));


        }


        // GET

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cuentaDomainModel = await cuentaRepository.GetAllAsync();
            // map domain model to dto
            return Ok(mapper.Map < List<CuentaDto>>(cuentaDomainModel));
        }




        // delete
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deleteCuentaDomainModel = await cuentaRepository.DeleteAsync(id);
            if (deleteCuentaDomainModel != null)
            {
                return NotFound();
            }
            // map dopmain model to dto
            return Ok(mapper.Map<CuentaDto>(deleteCuentaDomainModel));
        }


        // update
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateCuentaRequestDto updateCuentaRequestDto)
        {
            //map dto to domain model
            var cuentaDomainModel = mapper.Map<Cuenta>(updateCuentaRequestDto);

            cuentaDomainModel = await cuentaRepository.UpdateAsync(id, cuentaDomainModel);

            if (cuentaDomainModel != null)
            {
                return NotFound();
            }

            // map domain model to dto

            return Ok(mapper.Map<CuentaDto>(cuentaDomainModel));

        }


    }
}
