using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Preco).HasPrecision(10, 2);
            
            builder.HasData(
                                new Animal(1, "Vacas em lactação", 1000),
                                new Animal(2, "Vacas secas", 1000),
                                new Animal(3, "Bezerras de 0 a 2 meses", 1000),
                                new Animal(4, "Bezerras de 2 a 6 meses", 1000),
                                new Animal(5, "Novilhas de 12 a 18 meses", 1000),
                                new Animal(6, "Novilhas de 18 a 24 meses", 1000),
                                new Animal(7, "Novilhas de 24 a 27 meses", 1000)
                           );
        }
    }
}
