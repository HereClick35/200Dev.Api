using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public class CompraGado : EntityBase
    {
        public CompraGado(int id, int pecuaristaId, DateTime dataEntrega)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value;");
            Id = id;
            CreateBy = System.DateTime.UtcNow;
            DataEntrega = dataEntrega;
            //Token = new System.Guid().ToString();
            ValidationDomain(pecuaristaId, dataEntrega);
        }       
        public void Update(int pecuaristaId, DateTime dataEntrega)
        {
            ValidationDomain(pecuaristaId, dataEntrega);
        }
        private void ValidationDomain(int pecuaristaId, DateTime dataEntrega)
        {
            DomainExceptionValidation.When(pecuaristaId <= 0, "Invalid pecuarista;");
            //DomainExceptionValidation.When(dataEntrega <= DateTime.Now, "Invalid pecuarista;");

            PecuaristaId = pecuaristaId;
        }        
        public int PecuaristaId { get; private set; }

        public DateTime DataEntrega { get; set; }
        public Pecuarista Pecuarista { get; set; }
        public ICollection<Pecuarista> Pecuaristas { get; private set; }
        public ICollection<CompraGadoItem> Itens { get;  set; }

    }
}
