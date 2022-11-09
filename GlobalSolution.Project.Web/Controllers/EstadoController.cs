using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution.Project.Web.Controllers
{
    public class EstadoController : Controller
    {
        private GlobalSolutionContext _context;

        public EstadoController(GlobalSolutionContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Cadastrar(Estado estado)
        {
            _context.Estados.Add(estado);
            _context.SaveChanges();
            TempData["msg"] = "Estado cadastrado";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
