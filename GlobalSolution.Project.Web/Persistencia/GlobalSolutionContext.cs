using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Project.Web.Persistencia
{
    public class GlobalSolutionContext : DbContext
    {

        public GlobalSolutionContext(DbContextOptions options) : base(options)
        {
        }

    }
}
