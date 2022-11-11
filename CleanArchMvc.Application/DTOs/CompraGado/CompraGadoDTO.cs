using CleanArchMvc.Application.DTOs.Pecuarista;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs.CompraGado
{
    public class CompraGadoDTO
    {
        [Required(ErrorMessage = "A Id é obrigatória")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A PecuaristaId é obrigatória")]
        public int PecuaristaId { get; set; }
        public decimal ValorCompra { get; set; }
        public PecuaristaDTO Pecuarista { get; set; }

        [Required(ErrorMessage = "A DataEntrega é obrigatória")]
        public string DataEntrega { get; set; }
        public List<CompraGadoItemDTO> Items { get; set; }
    }
}
