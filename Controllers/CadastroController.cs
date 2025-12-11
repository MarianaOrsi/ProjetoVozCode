using Microsoft.AspNetCore.Mvc;
using ProjetoVozCode.Contexts;
using ProjetoVozCode.Models;

namespace ProjetoVozCode.Controllers
{
    [Route("[controller]")]

    public class CadastroController : Controller
    {
        vozCodeContext _context = new vozCodeContext();


        /// Função apenas para exibir a página de cadastrar
        public IActionResult Index()
        {
            TempData["Cadastro"] = "";
            TempData["Login"] = "";

            return View();
        }


        /// Função apenas para realizar o ato de criar o cadastro

        [Route("Cadastrar")]
        public IActionResult Cadastro(Usuario usuario, string confirmarsenha)
        {
            if (usuario.Senha.ToLower() == confirmarsenha.ToLower())
            {
                var usuarioExistente = _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == usuario.Email.ToLower());

                if (usuarioExistente != null)
                {
                    TempData["Cadastro"] = "Email já cadastrado.";

                    return RedirectToAction("Index", "Execusao");
                }

                _context.Add(usuario);

                _context.SaveChanges();

                return RedirectToAction("Index", "Login");
            }
            else
            {
                TempData["Cadastro"] = "As senhas não conferem";
            }
            return RedirectToAction("Index");
        }
    }
}