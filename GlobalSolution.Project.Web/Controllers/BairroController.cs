using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Excluir(int id)
        {
            var bairro = _context.Bairros.Find(id);
            _context.Bairros.Remove(bairro);
            _context.SaveChanges();

            TempData["msg"] = "Bairro Deletado";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Editar(Bairro bairro)
        {
            _context.Bairros.Update(bairro);
            _context.SaveChanges();
            TempData["msg"] = "Bairro Atualizado";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarCidades();

            var bairro = _context.Bairros
                .Include(c => c.Cidade)
                .Where(c => c.BairroId == id)
                .FirstOrDefault();

            return View(bairro);
        }

        [HttpPost]
        public IActionResult Cadastrar(Bairro bairro)
        {
            _context.Bairros.Add(bairro);
            _context.SaveChanges();
            TempData["msg"] = "Bairro Cadastrado";

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

            var qtdeCidade = lista.Count();
            ViewBag.qtdeCidade = qtdeCidade;

            //Enviar o SelectList para a View 
            ViewBag.cidades = new SelectList(lista, "CidadeId", "Nome"); //lista, value, texto 
        }

        public IActionResult Index()
        {
            var bairro = _context.Bairros
                .Include(c => c.Cidade)
                .Include(c => c.Cidade.Estado)
                .ToList();

            return View(bairro);
        }
    }
}
