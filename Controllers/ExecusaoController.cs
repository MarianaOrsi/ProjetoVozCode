using Microsoft.AspNetCore.Mvc;
using ProjetoVozCode.Contexts;
using VozCode.Repositories.Interfaces;

namespace ProjetoVozCode.Controllers
{
    [Route("[controller]")]
    public class ExecusaoController : Controller
    {
        private readonly IGeminiCodeAnalysisRepository _geminiService;

        // Construtor para Injeção de Dependência
        public ExecusaoController(IGeminiCodeAnalysisRepository geminiService)
        {
            _geminiService = geminiService;
        }

        vozCodeContext _context = new vozCodeContext();
        public IActionResult Index()
        {
            return View();
        }
    }
}