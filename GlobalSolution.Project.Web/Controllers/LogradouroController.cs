using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Excluir(int id)
        {
            var logradouro = _context.Logradouros.Find(id);
            _context.Logradouros.Remove(logradouro);
            _context.SaveChanges();

            TempData["msg"] = "Logradouro Deletado";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Logradouro logradouro)
        {
            _context.Logradouros.Update(logradouro);
            _context.SaveChanges();

            TempData["msg"] = "Logradouro Cadastrado";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarBairros();

            var logradouro = _context.Logradouros
                .Include(c => c.Bairro)
                .Where(c => c.LogradouroId == id)
                .FirstOrDefault();

            return View(logradouro);
        }

        [HttpPost]
        public IActionResult Cadastrar(Logradouro logradouro)
        {
            _context.Logradouros.Add(logradouro);
            _context.SaveChanges();
            TempData["msg"] = "Logradouro Cadastrado";

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

            var qtdeBairro = lista.Count();
            ViewBag.qtdeBairro = qtdeBairro;

            //Enviar o SelectList para a View 
            ViewBag.bairros = new SelectList(lista, "BairroId", "Nome"); //lista, value, texto 
        }

        public IActionResult Index()
        {
            var logradouro = _context.Logradouros
                .Include(c => c.Bairro.Cidade.Estado)
                .Include(c => c.Bairro.Cidade)
                .Include(c => c.Bairro)
                .ToList();

            return View(logradouro);
        }
    }
}
