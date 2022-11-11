using AutoMapper;
using CleanArchMvc.Application.DTOs.Animal;
using CleanArchMvc.Application.DTOs.Pecuarista;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class PecuaristaService : IPecuaristaService
    {
        private readonly IPecuaristaRepository _repository;
        private readonly IMapper _mapper;

        public PecuaristaService(IPecuaristaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PecuaristaDTO> Add(PecuaristaDTOCreate _dto)
        {
            var _objeto = _mapper.Map<Pecuarista>(_dto);
            var result = await _repository.CreateAsync(_objeto);
            return _mapper.Map<PecuaristaDTO>(result);
        }


        public async Task<PecuaristaDTO> GetById(int? id)
        {
            var _objeto = await _repository.GetByIdAsync(id);
            return _mapper.Map<PecuaristaDTO>(_objeto);
        }

        public async Task<IEnumerable<PecuaristaDTO>> GetPecuaristas()
        {
            var _objeto = await _repository.GetPecuaristasAsync();
            return _mapper.Map<IEnumerable<PecuaristaDTO>>(_objeto);
        }

        public async Task Remove(int? id)
        {
            var _objeto = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(_objeto);
        }

        public async Task<PecuaristaDTO> Update(PecuaristaDTO _dto)
        {
            var _objeto = _mapper.Map<Pecuarista>(_dto);
            var result = await _repository.UpdateAsync(_objeto);
            return _mapper.Map<PecuaristaDTO>(result);
        }
    }
}
