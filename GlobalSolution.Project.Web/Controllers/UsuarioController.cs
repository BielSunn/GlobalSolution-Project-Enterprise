using GlobalSolution.Project.Web.Models;
using GlobalSolution.Project.Web.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace GlobalSolution.Project.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private GlobalSolutionContext _context;

        //Recebe o context por injeção de dependência
        public UsuarioController(GlobalSolutionContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UsuarioLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UsuarioCadastro()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UsuarioCadastro(Usuario usuario)
        {
            
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            TempData["msg"] = "Usuário cadastrado com sucesso !";

            return RedirectToAction("UsuarioLogin");
        }

    }
}
