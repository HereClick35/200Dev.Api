using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    internal class CompraGadoItemConfiguration : IEntityTypeConfiguration<CompraGadoItem>
    {
        public void Configure(EntityTypeBuilder<CompraGadoItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CompraGadoId).IsRequired();
            builder.Property(x => x.AnimalId).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            //builder.Property(x => x.Token).HasMaxLength(100).IsRequired();
            //builder.HasOne(e => e.Animal).WithMany(e => e.CompraGadoItens).HasForeignKey(e => e.AnimalId);
        }
    }
}
