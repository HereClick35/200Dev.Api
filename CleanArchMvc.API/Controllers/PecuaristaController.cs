using CleanArchMvc.Application.DTOs.Pecuarista;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class pecuaristacontroller : ControllerBase
    {
        private readonly IPecuaristaService _service;

        public pecuaristacontroller(IPecuaristaService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PecuaristaDTO>>> Get()
        {
            var _obj = await _service.GetPecuaristas();
            if (_obj == null)
            {
                return NotFound("Pecuarista não encontrado");
            }
            return Ok(_obj);
        }        
        
        [HttpGet("{id:int}", Name = "GetPecuarista")]
        public async Task<ActionResult<PecuaristaDTO>> Get(int id)
        {
            var _obj = await _service.GetById(id);
            if (_obj == null)
            {
                return NotFound("Pecuarista não encontrado");
            }
            return Ok(_obj);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PecuaristaDTOCreate PecuaristaDTO)
        {
            if (PecuaristaDTO == null)
                return BadRequest("Dado Inválido");

            var result = await _service.Add(PecuaristaDTO);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] PecuaristaDTO PecuaristaDTO)
        {

            if (PecuaristaDTO == null)
                return BadRequest();

            if (id != PecuaristaDTO.Id)
                return BadRequest();

            await _service.Update(PecuaristaDTO);

            return Ok(PecuaristaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PecuaristaDTO>> Delete(int id)
        {
            var _obj = await _service.GetById(id);
            if (_obj == null)
            {
                return NotFound("Pecuarista não encontrado");
            }

            await _service.Remove(id);

            return Ok(_obj);

        }
    }
}
