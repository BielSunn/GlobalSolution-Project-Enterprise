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

        public GlobalSolutionContext(DbContextOptions options) : base(options)
        {
        }

    }
}
