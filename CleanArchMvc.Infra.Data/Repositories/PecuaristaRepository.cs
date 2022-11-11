using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class PecuaristaRepository : IPecuaristaRepository
    {
        private ApplicationDbContext _context;

        public PecuaristaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pecuarista> CreateAsync(Pecuarista pecuarista)

        {
            _context.Pecuaristas.Add(pecuarista);
            await _context.SaveChangesAsync();
            return pecuarista;
        }

        public async Task<Pecuarista> GetByIdAsync(int? id)

        {
            return await _context.Pecuaristas.FindAsync(id);
        }

        public async Task<IEnumerable<Pecuarista>> GetPecuaristasAsync()
        {
            return await _context.Pecuaristas.ToListAsync();
        }

        public async Task<Pecuarista> RemoveAsync(Pecuarista pecuarista)
        {
            _context.Pecuaristas.Remove(pecuarista);
            await _context.SaveChangesAsync();
            return pecuarista;
        }

        public async Task<Pecuarista> UpdateAsync(Pecuarista pecuarista)
        {
            _context.Pecuaristas.Update(pecuarista);
            await _context.SaveChangesAsync();
            return pecuarista;
        }
    }
}
