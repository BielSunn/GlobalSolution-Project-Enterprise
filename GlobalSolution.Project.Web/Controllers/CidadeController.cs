using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Excluir(int id)
        {
            var cidade = _context.Cidades.Find(id);

            _context.Cidades.Remove(cidade);
            _context.SaveChanges();

            TempData["msg"] = "Cidade Removida";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Cidade cidade)
        {
            _context.Cidades.Update(cidade);
            _context.SaveChanges();
            TempData["msg"] = "Cidade Atualizada";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarEstados();

            var cidade = _context.Cidades
                .Include(c => c.Estado)
                .Where(c => c.CidadeId == id)
                .FirstOrDefault();

            return View(cidade);
        }

        [HttpPost]
        public IActionResult Cadastrar(Cidade cidade)
        {
            _context.Cidades.Add(cidade);
            _context.SaveChanges();
            TempData["msg"] = "Cidade Cadastrada";

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

            var qtdeEstado = lista.Count();
            ViewBag.qtdeEstado = qtdeEstado;

            //Enviar o SelectList para a View 
            ViewBag.estados = new SelectList(lista, "EstadoId", "Nome"); //lista, value, texto 
        }

        public IActionResult Index()
        {
            var cidades = _context.Cidades
                .Include(c => c.Estado)
                .ToList();

            return View(cidades);
        }
    }
}
