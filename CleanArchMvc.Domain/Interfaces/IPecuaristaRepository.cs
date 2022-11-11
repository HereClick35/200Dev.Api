using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IPecuaristaRepository
    {
        Task<IEnumerable<Pecuarista>> GetPecuaristasAsync();
        Task<Pecuarista> GetByIdAsync(int? id);
        Task<Pecuarista> CreateAsync(Pecuarista pecuarista);
        Task<Pecuarista> UpdateAsync(Pecuarista pecuarista);
        Task<Pecuarista> RemoveAsync(Pecuarista pecuarista);

    }
}
