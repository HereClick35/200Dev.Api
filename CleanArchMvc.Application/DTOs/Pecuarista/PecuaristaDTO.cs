using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CleanArchMvc.Application.DTOs.Pecuarista
{
    public class PecuaristaDTO
    {
        [Required(ErrorMessage = "A Id é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get; set; }

    }
}
