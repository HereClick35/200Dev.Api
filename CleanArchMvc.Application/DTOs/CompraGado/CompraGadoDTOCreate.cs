using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs.CompraGado
{
    public class CompraGadoDTOCreate
    {
        //public int Id { get; set; }

        //[Required(ErrorMessage = "A PecuaristaId é obrigatória")]        
        //[DisplayName("PecuaristaId")]
        public int PecuaristaId { get; set; }

        //[Required(ErrorMessage = "O DataEntrega é obrigatório")]
        //[DisplayName("DataEntrega")]
        public DateTime DataEntrega { get; set; }
    }
}
