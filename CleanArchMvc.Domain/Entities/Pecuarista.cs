using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMvc.Domain.Entities
{
    public class Pecuarista : EntityBase
    {
        public Pecuarista(string name)
        {
            ValidationDomain(name);
            CreateBy = System.DateTime.Now;
            CreateUserId = 1;
        }
        public Pecuarista(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Valor do Id é invalido;");
            Id = id;
            CreateBy = System.DateTime.UtcNow;
            CreateUserId = 1;
            ValidationDomain(name);
        }
        public void Update(string name)
        {
            ValidationDomain(name);
        }        
        private void ValidationDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required;");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short minimum 3 characters;");

            Name = name;
            //Token = new System.Guid().ToString();
        }

        public string Name { get; private set; }

        
        public ICollection<CompraGado> Compras { get; private set; }
    }
}
