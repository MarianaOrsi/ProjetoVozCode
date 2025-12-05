using Microsoft.AspNetCore.Mvc;
using ProjetoVozCode.Contexts;
using VozCode.Repositories;
using VozCode.Repositories.Interfaces;

namespace ProjetoVozCode.Controllers
{
    [Route("[controller]")]
    public class ExecusaoController : Controller
    {
        private readonly IGeminiCodeAnalysisRepository _repository;

        public ExecusaoController(IGeminiCodeAnalysisRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Analisar")]
        public async Task<IActionResult> AnalisarCodigo(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                var retorno = await _repository.AnalisarCodigoParaFeedback("csharp", codigo);
                
                TempData["Analise"] = retorno;
                TempData["Codigo"] = codigo;
            }

            return RedirectToAction("Index");
        }
    }
}
