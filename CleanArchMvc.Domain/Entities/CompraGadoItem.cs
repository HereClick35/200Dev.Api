using CleanArchMvc.Domain.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace CleanArchMvc.Domain.Entities
{
    public class CompraGadoItem : EntityBase
    {
        
        public CompraGadoItem(int compraGadoId, int animalId, int quantidade)
        {
            ValidationDomain(compraGadoId, animalId, quantidade);
            //Token = (new System.Guid()).ToString();
            CreateBy = System.DateTime.Now;
            CreateUserId = 1;
        }

        public CompraGadoItem(int id, int compraGadoId, int animalId, int quantidade)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value;");
            Id = id;
            //Token = new System.Guid().ToString();
            ValidationDomain(compraGadoId, animalId, quantidade);
        }

        public void Update(int compraGadoId, int animalId, int quantidade)
        {
            ValidationDomain(compraGadoId, animalId, quantidade);
        }
        private void ValidationDomain(int compraGadoId, int animalId, int quantidade)
        {           

            DomainExceptionValidation.When(compraGadoId <= 0, "Invalid compraGadoId value;");
            DomainExceptionValidation.When(animalId < 0, "Invalid animalId value;");
            DomainExceptionValidation.When(quantidade < 0, "Invalid quantidade value;");

            CompraGadoId = compraGadoId;
            AnimalId = animalId;
            Quantidade = quantidade;
        }

        public int CompraGadoId { get; private set; }
        public int AnimalId { get; private set; }
        public int Quantidade { get; private set; }

        public CompraGado CompraGado { get; set; }
        public Animal Animal { get; set; }

        //public ICollection<CompraGado> Compras { get; private set; }
        //public ICollection<Animal> Animais { get; private set; }
    }
}
