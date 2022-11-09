using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Project.Web.Controllers
{
    public class LocalController : Controller
    {
        private GlobalSolutionContext _context;

        //Recebe o context por injeção de dependência
        public LocalController(GlobalSolutionContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Adicionar(AcessibilidadeLocal acessibilidadeLocal)
        {
            _context.AcessibilidadeLocais.Add(acessibilidadeLocal);
            _context.SaveChanges();

            TempData["msg"] = "Acessibilidade cadastrada no Local";
            return RedirectToAction("Detalhar", new {id = acessibilidadeLocal.LocalId} );
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            //recuperar acessibilidade associados ao local
            var acessibilidadeLocais = _context.AcessibilidadeLocais
                .Where(a => a.LocalId == id) //Filtra pelo Id do local
                .Select(a => a.Acessibilidade) //Recupera a acessibilidade como resultado
                .ToList();
            //enviar para a view a lista de cursos associados ao aluno
            ViewBag.listaLocais = acessibilidadeLocais;

            //Pesquisar todas as acessibilidades com status disponível
            var lista = _context.Acessibilidades.Where(c => c.Status).ToList();

            //Filtrar a lista de acessibilidade, retirando as acessibilidades já associados ao local
            var listaFiltrada = lista.Where(c => !acessibilidadeLocais.Any(c1 => c.AcessibilidadeId == c1.AcessibilidadeId));

            //Verificar se há acessibilidades cadastradas
            var qtdeAcessibilidade = lista.Count();
            ViewBag.qtdeAcessibilidade = qtdeAcessibilidade;

            //enviar o SelectList de nano courses para a view (options)
            ViewBag.acessibilidades = new SelectList(listaFiltrada, "AcessibilidadeId", "TipoAcessibilidade");

            //Recuperar o local pelo id
            var aluno = _context.Locais
                .Include(c => c.Logradouro)
                .Include(c => c.Telefone)
                .Where(a => a.LocalId == id)
                .FirstOrDefault();

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var local = _context.Locais.Find(id);

            _context.Locais.Remove(local);
            _context.SaveChanges();

            TempData["msg"] = "Local Removido";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Local local)
        {
            _context.Locais.Update(local);
            _context.SaveChanges();

            TempData["msg"] = "Local Atualizado";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            CarregarLogradouros();

            var local = _context.Locais
                .Include(c => c.Logradouro) //Adiciona o relacionamento na query (retorno)
                .Include(c => c.Telefone) //Adiciona o relacionamento na query (retorno)
                .Where(a => a.LocalId == id) //Filtro pelo ID
                .FirstOrDefault(); //Retorar o primeiro ou null

            return View(local);
        }

        [HttpPost]
        public IActionResult Cadastrar(Local local)
        {
            _context.Locais.Add(local);
            _context.SaveChanges();
            TempData["msg"] = "Local Cadastrado";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarLogradouros();
            return View();
        }

        public IActionResult Index(string nomeBusca = "")
        {
            var lista = _context.Locais
                .Where(a => a.Nome.Contains(nomeBusca))
                .Include(c => c.Logradouro)
                .Include(c => c.Telefone)
                .ToList();
            return View(lista);
        }

        private void CarregarLogradouros()
        {
            var lista = _context.Logradouros.ToList();

            var qtdeLogradouro = lista.Count();
            ViewBag.qtdeLogradouro = qtdeLogradouro;

            //Enviar o SelectList para a View 
            ViewBag.logradouros = new SelectList(lista, "LogradouroId", "Descricao"); //lista, value, texto 
        }

    }
}
