using CleanArchMvc.Application.DTOs.Pecuarista;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IPecuaristaService
    {
        Task<IEnumerable<PecuaristaDTO>> GetPecuaristas();
        Task<PecuaristaDTO> GetById(int? id);
        Task<PecuaristaDTO> Add(PecuaristaDTOCreate pecuaristaDTO);
        Task<PecuaristaDTO> Update(PecuaristaDTO pecuaristaDTO);
        Task Remove(int? id);
    }
}