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
    internal class CompraGadoConfiguration : IEntityTypeConfiguration<CompraGado>
    {
        public void Configure(EntityTypeBuilder<CompraGado> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PecuaristaId).IsRequired();
            builder.Property(x => x.DataEntrega).IsRequired();
            builder.HasOne(e => e.Pecuarista).WithMany(e => e.Compras).HasForeignKey(e => e.PecuaristaId);
        }
    }
}