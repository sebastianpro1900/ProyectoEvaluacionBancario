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
    public class MovimientosController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly SistemaDbContext dbContext;
        private readonly IMovimientoRepository movimientoRepository;


        public  MovimientosController (SistemaDbContext dbContext, IMovimientoRepository movimientoRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.movimientoRepository = movimientoRepository;
            this.mapper = mapper;

        }

        // post create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddMovimientoRequestDto addMovimientoRequestDto)
        {
            // mpa dto to domain model
            var movimientoDomainModel = mapper.Map<Movimiento>(addMovimientoRequestDto);
            await movimientoRepository.CreateAsync(movimientoDomainModel);

            // map domain model to dto
            return Ok(mapper.Map<MovimientoDto>(movimientoDomainModel));
        }



        // get para listar
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //
            var movimientoDomainModel = await movimientoRepository.GetAllAsync();
            // map domain model to dto
            return Ok(mapper.Map<List<MovimientoDto>>(movimientoDomainModel));
        }


        // delete

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedMovimientoDomainModel = await movimientoRepository.DeleteAsync(id);
            if (deletedMovimientoDomainModel == null)
            {
                return NotFound();
            }
            // map domain model to dto
            return Ok(mapper.Map<MovimientoDto>(deletedMovimientoDomainModel));

        }


        //update
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateMovimientoRequestDto updateMovimientoRequestDto)
        {
            // map dto to domain model
            var movimientoDomainModel = mapper.Map<Movimiento>(updateMovimientoRequestDto);
            movimientoDomainModel = await movimientoRepository.UpdateAsync(id, movimientoDomainModel);
            if (movimientoDomainModel == null)
            {
                return NotFound();
            }
            // map domain model to dto

            return Ok(mapper.Map<MovimientoDto>(movimientoDomainModel));


        }


    }
}
