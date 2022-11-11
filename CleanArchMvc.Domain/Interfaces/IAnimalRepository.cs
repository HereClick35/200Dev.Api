using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAnimaisAsync();
        Task<Animal> GetByIdAsync(int? id);
        Task<Animal> CreateAsync(Animal Animal);
        Task<Animal> UpdateAsync(Animal Animal);
        Task<Animal> RemoveAsync(Animal Animal);

    }
}
