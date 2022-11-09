using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution.Project.Web.Controllers
{
    public class AcessibilidadeController : Controller
    {
        private GlobalSolutionContext _context;

        public AcessibilidadeController(GlobalSolutionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Editar(Acessibilidade acessibilidade)
        {
            _context.Acessibilidades.Update(acessibilidade);
            _context.SaveChanges();

            TempData["msg"] = "Acessibilidade atualizada !";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var acessibilidade = _context.Acessibilidades
                .Where(a => a.AcessibilidadeId == id) //Filtro pelo ID
                .FirstOrDefault(); //Retorar o primeiro ou null

            return View(acessibilidade);
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var acessibilidade = _context.Acessibilidades.Find(id);

            _context.Acessibilidades.Remove(acessibilidade);
            _context.SaveChanges();

            TempData["msg"] = "Acessibilidade removida !";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Cadastrar(Acessibilidade acessibilidade)
        {
            _context.Acessibilidades.Add(acessibilidade);
            _context.SaveChanges();
            TempData["msg"] = "Acessibilidade cadastrada !";
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            ViewBag.lista = _context.Acessibilidades.ToList();
            return View();
        }
    }
}
