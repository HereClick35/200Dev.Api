using AutoMapper;
using CleanArchMvc.Application.DTOs.CompraGado;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CompraGadoItemService : ICompraGadoItemService
    {
        private readonly ICompraGadoItemRepository _repository;
        private readonly IMapper _mapper;

        public CompraGadoItemService(ICompraGadoItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompraGadoItem> Add(int CompraId, CompraGadoItemDTO dto)
        {
            //var _objeto = _mapper.Map<CompraGado>(_dto);
            var x = new CompraGadoItem(CompraId, dto.AnimalId, dto.Quantidade);
            var result = await _repository.CreateAsync(x);
            return result; // _mapper.Map<CompraGadoItemDTO>(result);
        }

        public async Task<CompraGadoItem> GetById(int? CompraId, int? id)
        {
            var _objeto = await _repository.GetByIdAsync(CompraId, id);
            return _objeto; //  _mapper.Map<CompraGadoItemDTO>(_objeto);
        }

        public async Task<IEnumerable<CompraGadoItemDTO>> GetItens(int? CompraId)
        {
            var _objeto = await _repository.GetCompraGadoItensAsync(CompraId);
            List<CompraGadoItemDTO> item = new List<CompraGadoItemDTO>();
            foreach (var iten in _objeto)
            {
                item.Add(new CompraGadoItemDTO()
                {
                    CompraGadoId    = iten.CompraGadoId,
                    AnimalId        = iten.AnimalId,
                    Animal          = iten.Animal.Descricao,                    
                    Quantidade      = iten.Quantidade,
                    Preco           = iten.Animal.Preco,
                    Total           = iten.Quantidade * iten.Animal.Preco
                });
            }

            return _mapper.Map<IEnumerable<CompraGadoItemDTO>>(item);
        }

        public async Task<decimal> GetTotalPedido(int? CompraId)
        {
            var _objeto = await _repository.GetCompraGadoItensAsync(CompraId);
            //List<CompraGadoItemDTO> item = new List<CompraGadoItemDTO>();
            decimal valorPedido = 0;
            foreach (var iten in _objeto)
            {
                valorPedido += iten.Quantidade * iten.Animal.Preco;
            }
            return valorPedido;
        }


        public async Task Remove(int? CompraId, int? Animalid)
        {
            var _objeto = _repository.GetByIdAsync(CompraId, Animalid).Result;
            await _repository.RemoveAsync(_objeto);
        }

        public async Task<CompraGadoItem> Update(int CompraId, CompraGadoItemDTO dto)
        {
            var _objeto = _mapper.Map<CompraGadoItemDTO>(dto);
            var x = new CompraGadoItem(CompraId, dto.AnimalId, dto.Quantidade);

            var result = await _repository.UpdateAsync(x);
            return result; //  _mapper.Map<CompraGadoItemDTO>(result);
        }
    }
}
