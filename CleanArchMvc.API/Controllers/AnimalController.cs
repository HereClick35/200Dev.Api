using CleanArchMvc.Application.DTOs.Animal;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class animalcontroller : ControllerBase
    {
        private readonly IAnimalService _service;

        public animalcontroller(IAnimalService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> Get()
        {
            var _obj = await _service.GetAnimals();
            if (_obj == null)
            {
                return NotFound("Animal não encontrado");
            }
            return Ok(_obj);
        }

        [HttpGet("{id:int}", Name = "GetAnimal")]
        public async Task<ActionResult<AnimalDTO>> Get(int id)
        {
            var _obj = await _service.GetById(id);
            if (_obj == null)
            {
                return NotFound("Animal não encontrado");
            }
            return Ok(_obj);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AnimalDTOCreate AnimalDTO)
        {
            if (AnimalDTO == null)
                return BadRequest("Dado Inválido");

           var result = await _service.Add(AnimalDTO);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] AnimalDTO AnimalDTO)
        {

            if (AnimalDTO == null)
                return BadRequest();

            if (id != AnimalDTO.Id)
                return BadRequest();

            var result = await _service.Update(AnimalDTO);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<AnimalDTO>> Delete(int id)
        {
            var _obj = await _service.GetById(id);
            if (_obj == null)
            {
                return NotFound("Animal não encontrado");
            }

            await _service.Remove(id);

            return Ok(_obj);

        }
    }
}
