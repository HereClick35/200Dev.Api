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
    public class CompraGadoItemRepository : ICompraGadoItemRepository
    {
        private ApplicationDbContext _context;

        public CompraGadoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompraGadoItem> CreateAsync(CompraGadoItem compragadoitem)
        {
            _context.CompraGadoItens.Add(compragadoitem);
            await _context.SaveChangesAsync();
            return compragadoitem;
        }

        public  async Task<CompraGadoItem> GetByIdAsync(int? CompraID, int? id)
        {
            //return await _context.CompraGadoItens.FindAsync(id);                        
            return await _context.CompraGadoItens.FirstOrDefaultAsync(c => c.CompraGadoId.Equals(CompraID) && c.AnimalId.Equals(id));


        }

        public async Task<IEnumerable<CompraGadoItem>> GetCompraGadoItensAsync(int? CompraId)
        {
            //return await _context.CompraGadoItens.Where(c => c.CompraGadoId.Equals(CompraId)).ToListAsync();

            var data = (from cgi in _context.CompraGadoItens.AsQueryable().AsNoTracking()
                        join ani in _context.Animals.AsQueryable().AsNoTracking() on cgi.AnimalId equals ani.Id
                        where cgi.CompraGadoId.Equals(CompraId)
                        select new CompraGadoItem(cgi.CompraGadoId, cgi.AnimalId, cgi.Quantidade)
                        {
                            Animal = new Animal(cgi.AnimalId, ani.Descricao, ani.Preco)
                        }
                        ).ToListAsync();
            return await data;
        }

        public async Task<CompraGadoItem> RemoveAsync(CompraGadoItem compragadoitem)
        {
            _context.CompraGadoItens.Remove(compragadoitem);
            await _context.SaveChangesAsync();
            return compragadoitem;
        }

        public async Task<CompraGadoItem> UpdateAsync(CompraGadoItem compragadoitem)
        {
            _context.CompraGadoItens.Update(compragadoitem);
            await _context.SaveChangesAsync();
            return compragadoitem;
        }
    }
}
