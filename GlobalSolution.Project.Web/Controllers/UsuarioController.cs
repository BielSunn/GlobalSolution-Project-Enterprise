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

        public IActionResult UsuarioLogin(string email, string senha)
        {
            var userEmail = _context.Usuarios.Where(x => x.Email.Contains(email)).ToList();
            var userSenha = _context.Usuarios.Where(y => y.Senha.Contains(senha)).ToList();

            if(userEmail.Count < 1 && userSenha.Count < 1)
            {
                TempData["msg"] = "E-mail ou senha inválido";
                return View();
            }

            return View();
        }

        [HttpPost]
        public IActionResult UsuarioCadastro(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            TempData["msg"] = "Usuário cadastrado com sucesso !";

            return RedirectToAction("UsuarioLogin");
        }

        [HttpGet]
        public IActionResult UsuarioCadastro()
        {
            return View();
        }

    }
}
