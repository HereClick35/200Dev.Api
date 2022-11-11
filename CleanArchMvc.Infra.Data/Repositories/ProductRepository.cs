
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext dbContext )
        {
            _context = dbContext;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            //return await _context.Products.FindAsync(id);
            return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        //public async Task<Product> GetProductCategoryIdAsync(int? id)
        //{
        //    return await _context.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id.Equals(id)); 
        //}

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(c => c.Category).ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}