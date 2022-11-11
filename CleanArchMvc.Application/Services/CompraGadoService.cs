using AutoMapper;
using CleanArchMvc.Application.DTOs.Animal;
using CleanArchMvc.Application.DTOs.CompraGado;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CompraGadoService : ICompraGadoService
    {
        private readonly ICompraGadoRepository _repository;
        private readonly IMapper _mapper;

        public CompraGadoService(ICompraGadoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CompraGadoDTO> Add(CompraGadoDTO _dto)
        {
            var _objeto = _mapper.Map<CompraGado>(_dto);
            var x = new CompraGado(0, _dto.PecuaristaId, DateTime.Parse(_dto.DataEntrega));
            x.DataEntrega = DateTime.Parse(_dto.DataEntrega);
            var result = await _repository.CreateAsync(x);
            
            return _mapper.Map<CompraGadoDTO>(result);
        }

        public async Task<CompraGadoDTO> GetById(int? id)
        {
            var _objeto = await _repository.GetByIdAsync(id);
            

            return _mapper.Map<CompraGadoDTO>(_objeto);
        }

        public async Task<IEnumerable<CompraGadoDTO>> GetCompras() 
        {
            var _objeto = await _repository.GetComprasAsync();
            return _mapper.Map<IEnumerable<CompraGadoDTO>>(_objeto);
        }

        public async Task Remove(int? id)
        {
            var _objeto = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(_objeto);
        }

        public async Task<CompraGadoDTO> Update(CompraGadoDTO _dto)
        {
            var _objeto = _mapper.Map<CompraGado>(_dto);
            var x = new CompraGado(_dto.Id, _dto.PecuaristaId, DateTime.Parse(_dto.DataEntrega));
            x.DataEntrega = DateTime.Parse(_dto.DataEntrega);
            var result = await _repository.UpdateAsync(x);

            return _mapper.Map<CompraGadoDTO>(result);
        }
    }
}
