using CleanArchMvc.Application.DTOs.Animal;
using CleanArchMvc.Application.DTOs.CompraGado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICompraGadoService
    {
        Task<IEnumerable<CompraGadoDTO>> GetCompras();
        Task<CompraGadoDTO> GetById(int? id);
        Task<CompraGadoDTO> Add(CompraGadoDTO dto);
        Task<CompraGadoDTO> Update(CompraGadoDTO dto);
        Task Remove(int? id);
    }
}