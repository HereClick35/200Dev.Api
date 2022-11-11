using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public class Animal : EntityBase
    {
        public Animal(string descricao, decimal preco)
        {
            ValidationDomain(descricao, preco);
            CreateBy = System.DateTime.UtcNow;
            
        }
        public Animal(int id, string descricao, decimal preco)
        {
            DomainExceptionValidation.When(id < 0, "Valor do Id é invalido;");
            Id = id;
            ModifiedBy = System.DateTime.UtcNow;
            ValidationDomain(descricao, preco);
        }
        private void ValidationDomain(string descricao, decimal preco)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Invalid name. Name is required;");
            DomainExceptionValidation.When(descricao.Length < 3, "Invalid name, too short minimum 3 characters;");

            Descricao = descricao;
            Preco = preco;
            //Token = new System.Guid().ToString();
        }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        //public ICollection<Product> Products { get; private set; }
    }
}
