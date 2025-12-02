using GenerativeAI;
using GenerativeAI.Core;
using GenerativeAI.Types;
using VozCode.Repositories.Interfaces;

namespace VozCode.Repositories
{
    public class GeminiCodeAnalysisRepository : IGeminiCodeAnalysisRepository
    {
        public GenerativeModel modelo { get; private set; }

        // O Construtor recebe IConfiguration para obter a chave de API
        public GeminiCodeAnalysisRepository(IConfiguration configuration)
        {
            // ⚠️ Mantenha o caminho da sua chave consistente com o appsettings.json
            string apiKeyGemini = configuration["GeminiSettings:ApiKey"];

            // Configuração do Modelo
            modelo = new GenerativeModel(apiKeyGemini, new ModelParams()
            {
                GenerationConfig = new GenerationConfig()
                {
                    Temperature = 0.2f, // Pouca variação para feedback técnico
                    CandidateCount = 1
                },
                Model = "gemini-2.5-flash" // Modelo rápido e capaz para análise de código
            });
        }

        public async Task<string> AnalisarCodigoParaFeedback(string linguagem, string codigo)
        {
            // Gera o prompt específico
            string promptFeedback = GerarPromptAnaliseCodigo(linguagem, codigo);

            // Chama a API do Gemini
            var respostaModelo = await modelo.GenerateContentAsync(promptFeedback);

            // Retorna o feedback do modelo
            return respostaModelo.Text;
        }

        // --- Prompt Específico para Análise e Feedback ---
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