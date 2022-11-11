using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICompraGadoItemRepository
    {
        Task<IEnumerable<CompraGadoItem>> GetCompraGadoItensAsync(int? CompraId);
        Task<CompraGadoItem> GetByIdAsync(int? CompraId, int? id);

        Task<CompraGadoItem> CreateAsync(CompraGadoItem compragadoitem);
        Task<CompraGadoItem> UpdateAsync(CompraGadoItem compragadoitem);
        Task<CompraGadoItem> RemoveAsync(CompraGadoItem compragadoitem);

    }
}