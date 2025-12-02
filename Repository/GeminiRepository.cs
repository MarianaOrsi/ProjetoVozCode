using GenerativeAI;
using VozCode.Repositories.Interfaces;

namespace VozCode.Repositories
{
    public class GeminiCodeAnalysisRepository : IGeminiCodeAnalysisRepository
    {
        private readonly GenerativeModel _modelo;

        public GeminiCodeAnalysisRepository(IConfiguration configuration)
        {
            string apiKeyGemini = configuration["GeminiSettings:ApiKey"];

            if (string.IsNullOrWhiteSpace(apiKeyGemini))
                throw new ArgumentException("A chave de API do Gemini não foi encontrada.");

            _modelo = new GenerativeModel("gemini-1.5-flash", apiKeyGemini);
        }

        public async Task<string> AnalisarCodigoParaFeedback(string linguagem, string codigo)
        {
            string prompt = GerarPromptAnaliseCodigo(linguagem, codigo);

            var resposta = await _modelo.GenerateContentAsync(prompt);

            return resposta.Text;
        }

        private string GerarPromptAnaliseCodigo(string linguagem, string codigo)
        {
            return $@"
                Você é um assistente de acessibilidade e mentoria para o projeto VozCode, focado em ajudar
                pessoas com deficiência visual a programarem.

                Seu objetivo é analisar o código fornecido e retornar um feedback claro, acessível e útil,
                focado em melhorias de boas práticas, correção de bugs, e explicação do código.

                Formate sua resposta usando **Markdown** de forma clara e legível. Use títulos e listas
                para facilitar a leitura por leitores de tela.

                **Estrutura do Feedback (Obrigatório):**
                ## 💖 Resumo e Encorajamento
                (Mensagem amigável sobre o código)

                ## 💡 Sugestões e Melhorias
                (Liste pontos específicos de melhoria, boas práticas, ou bugs corrigidos)

                ## 📖 Explicação do Código
                (Explique o que o código faz de forma simples e direta)
                
                **Linguagem de Programação:** {linguagem}
                
                **Código para Análise:**
                ```
                {linguagem}
                {codigo}
                ```
                
                ---
                **Inicie o Seu Feedback Agora:**
                ";
        }
    }
}