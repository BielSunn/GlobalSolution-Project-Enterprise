using GlobalSolution.Project.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Project.Web.Persistencia
{
    public class GlobalSolutionContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }

        public GlobalSolutionContext(DbContextOptions options) : base(options)
        {
        }

    }
}
