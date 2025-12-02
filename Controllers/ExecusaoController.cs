using Microsoft.AspNetCore.Mvc;
using ProjetoVozCode.Contexts;
using VozCode.Repositories.Interfaces;

namespace ProjetoVozCode.Controllers
{
    [Route("[controller]")]
    public class ExecusaoController : Controller
    {
        vozCodeContext _context = new vozCodeContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}