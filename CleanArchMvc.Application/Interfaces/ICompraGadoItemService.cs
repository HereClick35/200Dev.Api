using CleanArchMvc.Application.DTOs.CompraGado;
using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICompraGadoItemService
    {
        Task<IEnumerable<CompraGadoItemDTO>> GetItens(int? CompraId);
        Task<decimal> GetTotalPedido(int? CompraId);
        Task<CompraGadoItem> GetById(int? CompraId, int? id);
        Task<CompraGadoItem> Add(int CompraId, CompraGadoItemDTO dto);
        Task<CompraGadoItem> Update(int CompraId, CompraGadoItemDTO dto);
        Task Remove(int? CompraId, int? id);
    }
}