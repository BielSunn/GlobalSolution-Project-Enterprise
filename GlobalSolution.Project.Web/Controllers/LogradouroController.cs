using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlobalSolution.Project.Web.Controllers
{
    public class LogradouroController : Controller
    {
        private GlobalSolutionContext _context;

        public LogradouroController(GlobalSolutionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Logradouro logradouro)
        {
            _context.Logradouros.Add(logradouro);
            _context.SaveChanges();
            TempData["msg"] = "Logradouro cadastrado";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarBairros();
            return View();
        }

        private void CarregarBairros()
        {
            //Enviar a lista de bairros para o Select
            //Pesquisar todas os bairros
            var lista = _context.Bairros.ToList();

            //Enviar o SelectList para a View 
            ViewBag.bairros = new SelectList(lista, "BairroId", "Nome"); //lista, value, texto 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
