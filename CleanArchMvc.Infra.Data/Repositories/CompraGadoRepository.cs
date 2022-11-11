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
    public class CompraGadoRepository : ICompraGadoRepository
    {
        private ApplicationDbContext _context;
        public CompraGadoRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<CompraGado> CreateAsync(CompraGado CompraGado)
        {
            _context.CompraGados.Add(CompraGado);
            await _context.SaveChangesAsync();
            return CompraGado;
        }

        public async Task<CompraGado> GetByIdAsync(int? id)
        {
            //return await _context.CompraGados.FindAsync(id);

            var data = (from cp in _context.CompraGados
                        join pc in _context.Pecuaristas on cp.PecuaristaId equals pc.Id
                        where cp.Id == id
                        select new CompraGado(cp.Id, cp.PecuaristaId, cp.DataEntrega)
                        {
                            Pecuarista = new Pecuarista(pc.Id, pc.Name),
                        }
                       ).FirstOrDefaultAsync();

            return await data; // await _context.CompraGados.ToListAsync();
        }

        public async Task<IEnumerable<CompraGado>> GetComprasAsync()
        {  
            var data = (from cp in _context.CompraGados
                        join pc in _context.Pecuaristas on cp.PecuaristaId equals pc.Id
                        select new CompraGado(cp.Id, cp.PecuaristaId, cp.DataEntrega)
                        {
                            Pecuarista = new Pecuarista(pc.Id, pc.Name)                            
                        }).ToListAsync();
            return await data; 
        }

        public async Task<CompraGado> RemoveAsync(CompraGado CompraGado)
        {
            _context.CompraGadoItens.RemoveRange(_context.CompraGadoItens.Where(c => c.CompraGadoId.Equals(CompraGado.Id)));
            _context.CompraGados.Remove(CompraGado);
            await _context.SaveChangesAsync();
            return CompraGado;
        }

        public async Task<CompraGado> UpdateAsync(CompraGado CompraGado)
        {
            _context.CompraGados.Update(CompraGado);
            await _context.SaveChangesAsync();
            return CompraGado;
        }
    }
}
