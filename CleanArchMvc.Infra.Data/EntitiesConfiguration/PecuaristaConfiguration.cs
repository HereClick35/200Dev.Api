using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    internal class PecuaristaConfiguration : IEntityTypeConfiguration<Pecuarista>
    {
        public void Configure(EntityTypeBuilder<Pecuarista> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                                new Pecuarista(1, "Rei do Gado"),
                                new Pecuarista(2, "Tiao Carreiro"),
                                new Pecuarista(3, "Ze Leoncio")
                           );
        }
    }
}
