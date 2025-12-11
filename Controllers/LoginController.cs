
using Microsoft.AspNetCore.Mvc;
using ProjetoVozCode.Contexts;
using ProjetoVozCode.Models;

namespace ProjetoVozCode.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        vozCodeContext _context = new vozCodeContext();

        /// Função apenas para realizar o ato de logar
        public IActionResult Login(string email = "", string senha = "")
        {
            if (HttpContext.Request.Method != "GET")
            {
                if (!string.IsNullOrEmpty(email))
                {
                    // Procurando o usuario pelo email e senha
                    Usuario usuario = _context.Usuarios.Where(x => x.Email.ToString().ToLower() == email.ToLower()).FirstOrDefault();

                    if (usuario != null)
                    {
                        if (usuario.Senha == senha)
                        {
                            return RedirectToAction("Index", "Execusao");
                        }
                    }
                }

                TempData["Login"] = "Login inválido";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}