using AutoMapper;
using CleanArchMvc.Application.DTOs.Animal;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;
        private readonly IMapper _mapper;

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper)
        {
            _repository = animalRepository;
            _mapper = mapper;
        }

        public async Task<AnimalDTO> Add(AnimalDTOCreate _dto)
        {
            var _objeto = _mapper.Map<Animal>(_dto);
            var result = await _repository.CreateAsync(_objeto);
            return _mapper.Map<AnimalDTO>(result);
        }

        public async Task<IEnumerable<AnimalDTO>> GetAnimals()
        {
            var _objeto = await _repository.GetAnimaisAsync();
            return _mapper.Map<IEnumerable<AnimalDTO>>(_objeto);
        }

        public async Task<AnimalDTO> GetById(int? id)
        {
            var _objeto = await _repository.GetByIdAsync(id);
            return _mapper.Map<AnimalDTO>(_objeto);
        }

        public async Task Remove(int? id)
        {
            var _objeto = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(_objeto);
        }

        public async Task<AnimalDTO> Update(AnimalDTO _dto)
        {            
            var _objeto = _mapper.Map<Animal>(_dto);
            var result = await _repository.UpdateAsync(_objeto);
            return _mapper.Map<AnimalDTO>(result);
        }

    }
}
