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
            return View();
        }


        /// Função apenas para realizar o ato de criar o cadastro

        [Route("Cadastrar")]
        public IActionResult Cadastro(Usuario usuario, string confirmarsenha)
        {
            if (usuario.Senha.ToLower() == confirmarsenha.ToLower())
            {
                if (!string.IsNullOrWhiteSpace(usuario.Email))
                {
                    var usuarioExistente = _context.Usuarios.FirstOrDefault(x => x.Email.ToLower() == usuario.Email.ToLower());

                    if (usuarioExistente != null)
                    {
                        TempData["ErrorMessage"] = "Email já cadastrado.";
                        return RedirectToAction("Privacy", "Home");
                    }

                    _context.Add(usuario);

                    _context.SaveChanges();
                }
                else
                {
                    TempData["ErrorMessage"] = "Login inválido";
                }
                return RedirectToAction("Login", "Cadastro");
            }

            TempData["ErrorMessage"] = "As senhas não conferem";

            return RedirectToAction("Index");
        }

    }
}