
using Microsoft.AspNetCore.Mvc;
using ProjetoVozCode.Contexts;

namespace ProjetoVozCode.Controllers
{
    [Route("[controller]")]
    public class LinguagemController : Controller
    {
        vozCodeContext _context = new vozCodeContext();
        public IActionResult Index()
        {
            return View(); 
        }

    }
}