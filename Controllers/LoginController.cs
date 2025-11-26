
using Microsoft.AspNetCore.Mvc;
using ProjetoVozCode.Contexts;
using ProjetoVozCode.Models;

namespace ProjetoVozCode.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        vozCodeContext _context = new vozCodeContext();
        
        /// <summary>
        /// Função apenas para realizar o atoooooo de logar
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns> <summary>
        public IActionResult Login(string email = "", string senha = "")
        {
            if (!string.IsNullOrEmpty(email))
            {
                // Procurando o usuario pelo email e senha
                Usuario usuario = _context.Usuarios.Where(x => x.Email.ToString().ToLower() == email.ToLower()).FirstOrDefault();

                if (usuario != null)
                {
                    if (usuario.Senha == senha)
                    {
                        return RedirectToAction("Privacy", "Home");
                    }
                }
            }

            TempData["ErrorMessage"] = "Login inválido";

            return RedirectToAction("Index", "Home");
        }
    }
}