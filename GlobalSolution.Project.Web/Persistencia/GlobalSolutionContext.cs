using GlobalSolution.Project.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Project.Web.Persistencia
{
    public class GlobalSolutionContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Bairro> Bairros { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Acessibilidade> Acessibilidades { get; set; }
        public DbSet<AcessibilidadeLocal> AcessibilidadeLocais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurar a chave composta da tabela associativa
            modelBuilder.Entity<AcessibilidadeLocal>().HasKey(a => new { a.AcessibilidadeId, a.LocalId });

            //Configurar o relacionamento da associativa com a Acessibilidade
            modelBuilder.Entity<AcessibilidadeLocal>()
                .HasOne(a => a.Acessibilidade)
                .WithMany(a => a.AcessibilidadeLocal)
                .HasForeignKey(a => a.AcessibilidadeId);

            //Configurar o relacionamento da associativa com o Local
            modelBuilder.Entity<AcessibilidadeLocal>()
                .HasOne(a => a.Local)
                .WithMany(a => a.AcessibilidadeLocal)
                .HasForeignKey(a => a.LocalId);

            base.OnModelCreating(modelBuilder);
        }


        public GlobalSolutionContext(DbContextOptions options) : base(options)
        {
        }

    }
}
