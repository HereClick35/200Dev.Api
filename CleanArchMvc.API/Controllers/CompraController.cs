using CleanArchMvc.Application.DTOs.CompraGado;
using CleanArchMvc.Application.DTOs.CompraGado;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class compra : ControllerBase
    {
        private readonly ICompraGadoService _service;
        private readonly ICompraGadoItemService _serviceitem;

        public compra(ICompraGadoService service, ICompraGadoItemService serviceitem)
        {
            _service = service;
            _serviceitem = serviceitem;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraGadoDTO>>> Get()
        {
            var _obj = await _service.GetCompras();
            foreach(var _compra in _obj)
            {
                _compra.ValorCompra = await _serviceitem.GetTotalPedido(_compra.Id);
            }
            if (_obj == null) return NotFound("CompraGado não encontrado");
            
            return Ok(_obj);
        }



        [HttpGet("{id:int}", Name = "GetCompraGado")]
        public async Task<ActionResult<CompraGadoDTO>> Get(int id)
        {
            var _obj = await _service.GetById(id);
            if (_obj == null) return NotFound("CompraGado não encontrado");

            var _item = await _serviceitem.GetItens(id);            
            _obj.Items = _item.ToList();

            return Ok(_obj);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompraGadoDTO CompraGadoDTO)
        {
            if (CompraGadoDTO == null) return BadRequest("Dado Inválido");
            var result = await _service.Add(CompraGadoDTO);
            if(result.Id != 0)
            {
                foreach(CompraGadoItemDTO item in CompraGadoDTO.Items)
                {
                    await _serviceitem.Add(result.Id, new CompraGadoItemDTO() { AnimalId = item.AnimalId, Quantidade = item.Quantidade});

                }
            }
            return Ok(result);
        }



        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CompraGadoDTO CompraGadoDTO)
        {
            if (CompraGadoDTO == null)  return BadRequest();
            if (id != CompraGadoDTO.Id) return BadRequest();

            var result = await _service.Update(CompraGadoDTO);
            if (result.Id != 0)
            {
                var _itensDb = await _serviceitem.GetItens(id);
                foreach (var item in CompraGadoDTO.Items.ToList())
                {



                    if (_itensDb.FirstOrDefault(c => c.CompraGadoId.Equals(CompraGadoDTO.Id) 
                                             && c.AnimalId.Equals(item.AnimalId) 
                                             && c.Quantidade != item.Quantidade) != null){
                        // update
                        await _serviceitem.Update(result.Id, new CompraGadoItemDTO() { AnimalId = item.AnimalId, Quantidade = item.Quantidade });
                    }

                    if (_itensDb.FirstOrDefault(c => c.CompraGadoId.Equals(CompraGadoDTO.Id) 
                                             && c.AnimalId.Equals(item.AnimalId)) == null)
                    {
                        //create
                        await _serviceitem.Add(result.Id, new CompraGadoItemDTO() { AnimalId = item.AnimalId, Quantidade = item.Quantidade });
                    }

                }

                foreach (var item in _itensDb.ToList())
                {
                    if (CompraGadoDTO.Items.FirstOrDefault(c => c.CompraGadoId.Equals(id) && c.AnimalId.Equals(item.AnimalId)) == null)
                    {
                        // delete
                        await _serviceitem.Remove(result.Id,item.AnimalId);
                    }
                }
            }
            return Ok(result);
            return Ok(result);
        }




        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CompraGadoDTO>> Delete(int id)
        {
            var _obj = await _service.GetById(id);
            if (_obj == null)
            {
                return NotFound("CompraGado não encontrado");
            }
            await _service.Remove(id);
            return Ok(_obj);
        }
    }
}
