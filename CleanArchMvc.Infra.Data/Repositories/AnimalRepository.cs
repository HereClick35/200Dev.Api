using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private ApplicationDbContext _context;
        public AnimalRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Animal> CreateAsync(Animal animal)
        {
            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();
            return animal;
        }

        public async Task<Animal> GetByIdAsync(int? id)
        {
            return await _context.Animals.FindAsync(id);
        }

        public async Task<IEnumerable<Animal>> GetAnimaisAsync()
        {
            //return await _context.Animals.AsQueryable().AsNoTracking().ToListAsync();
            return await _context.Animals.ToListAsync();
        }

        public async Task<Animal> RemoveAsync(Animal Animal)
        {
            _context.Animals.Remove(Animal);
            await _context.SaveChangesAsync();
            return Animal;
        }

        public async Task<Animal> UpdateAsync(Animal Animal)
        {   
            _context.Animals.Update(Animal);
            await _context.SaveChangesAsync();
            return Animal;
        }
    }
}
