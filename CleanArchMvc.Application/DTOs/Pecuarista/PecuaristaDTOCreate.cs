using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs.Pecuarista
{
    public class PecuaristaDTOCreate
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "A Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

    }
}
