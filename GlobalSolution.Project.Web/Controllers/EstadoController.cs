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
        public IActionResult Excluir(int id)
        {
            var estado = _context.Estados.Find(id);

            _context.Estados.Remove(estado);
            _context.SaveChanges();

            TempData["msg"] = "Estado Removido !";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Estado estado)
        {
            _context.Estados.Update(estado);
            _context.SaveChanges();
            TempData["msg"] = "Estado Atualizado !";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var estado = _context.Estados
                .Where(a => a.EstadoId == id)
                .FirstOrDefault();

            return View(estado);
        }

        [HttpPost]
        public IActionResult Cadastrar(Estado estado)
        {
            _context.Estados.Add(estado);
            _context.SaveChanges();
            TempData["msg"] = "Estado Cadastrado !";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var estado = _context.Estados.ToList();
            return View(estado);
        }
    }
}
