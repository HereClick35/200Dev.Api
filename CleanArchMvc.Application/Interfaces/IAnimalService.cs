using CleanArchMvc.Application.DTOs.Animal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IAnimalService
    {
        Task<IEnumerable<AnimalDTO>> GetAnimals();
        Task<AnimalDTO> GetById(int? id);
        Task<AnimalDTO> Add(AnimalDTOCreate animalDTO);
        Task<AnimalDTO> Update(AnimalDTO animalDTO);
        Task Remove(int? id);
    }
}