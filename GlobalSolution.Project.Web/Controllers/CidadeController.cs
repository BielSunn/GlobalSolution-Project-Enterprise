using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlobalSolution.Project.Web.Controllers
{
    public class CidadeController : Controller
    {
        private GlobalSolutionContext _context;

        public CidadeController(GlobalSolutionContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Cadastrar(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            _context.SaveChanges();
            TempData["msg"] = "Cidade cadastrada";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarEstados();
            return View();
        }

        private void CarregarEstados()
        {
            //Enviar a lista de estados para o Select
            //Pesquisar todas os estados
            var lista = _context.Estados.ToList();

            //Enviar o SelectList para a View 
            ViewBag.estados = new SelectList(lista, "EstadoId", "Nome"); //lista, value, texto 
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
