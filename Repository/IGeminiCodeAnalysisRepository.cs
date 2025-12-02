using System.Threading.Tasks;

namespace VozCode.Repositories.Interfaces
{
    public interface IGeminiCodeAnalysisRepository
    {
        /// <summary>
        /// Envia um trecho de código para o Gemini analisar e retornar feedback.
        /// </summary>
        /// <param name="linguagem">A linguagem do código (ex: C#, Python).</param>
        /// <param name="codigo">O trecho de código fornecido pelo usuário.</param>
        /// <returns>O feedback detalhado do Gemini como string formatada em Markdown.</returns>
        Task<string> AnalisarCodigoParaFeedback(string linguagem, string codigo);
    }
}