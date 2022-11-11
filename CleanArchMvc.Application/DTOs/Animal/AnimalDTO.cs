using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Application.DTOs.Animal
{
    public class AnimalDTO
    {
        [Required(ErrorMessage = "A Id é obrigatória")]
        public int Id { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preco")]
        public decimal Preco { get; set; }
    }
}
