using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICompraGadoRepository
    {
        Task<IEnumerable<CompraGado>> GetComprasAsync();
        Task<CompraGado> GetByIdAsync(int? id);
        Task<CompraGado> CreateAsync(CompraGado compragado);
        Task<CompraGado> UpdateAsync(CompraGado compragado);
        Task<CompraGado> RemoveAsync(CompraGado compragado);

    }
}
