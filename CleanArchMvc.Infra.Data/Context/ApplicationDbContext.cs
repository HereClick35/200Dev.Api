using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category>  Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Pecuarista> Pecuaristas { get; set; }
        public DbSet<CompraGado> CompraGados { get; set; }
        public DbSet<CompraGadoItem> CompraGadoItens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
