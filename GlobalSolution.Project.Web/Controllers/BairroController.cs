using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlobalSolution.Project.Web.Controllers
{
    public class BairroController : Controller
    {
        private GlobalSolutionContext _context;

        public BairroController(GlobalSolutionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Bairro bairro)
        {
            _context.Bairros.Add(bairro);
            _context.SaveChanges();
            TempData["msg"] = "Bairro cadastrado";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarCidades();
            return View();
        }

        private void CarregarCidades()
        {
            //Enviar a lista de cidades para o Select
            //Pesquisar todas os cidades
            var lista = _context.Cidades.ToList();

            //Enviar o SelectList para a View 
            ViewBag.cidades = new SelectList(lista, "CidadeId", "Nome"); //lista, value, texto 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
