using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs.CompraGado
{
    public class CompraGadoItemDTO
    {
        public int CompraGadoId { get; set; }
        public int AnimalId { get; set; }
        public string Animal { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal Total { get; set; }
    }
}
