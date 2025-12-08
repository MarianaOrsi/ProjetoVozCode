using GenerativeAI;
using VozCode.Repositories.Interfaces;

namespace VozCode.Repositories
{
    public class GeminiCodeAnalysisRepository : IGeminiCodeAnalysisRepository
    {
        private readonly GenerativeModel _modelo;

        public GeminiCodeAnalysisRepository()
        {
            string apiKeyGemini = "AIzaSyB1Vet983KSOHtG-5wQKdb2LZxWHoDCY2g"
                ?? throw new ArgumentException("API KEY não encontrada");

            _modelo = new GenerativeModel(
                model: "gemini-2.5-flash",
                apiKey: apiKeyGemini
            );
        }

        public async Task<string> AnalisarCodigoParaFeedback(string linguagem = "csharp", string codigo = "")
        {
            string prompt = GerarPromptAnaliseCodigo(linguagem, codigo);

            // ← ESTE é o correto para seu pacote
            var resposta = await _modelo.GenerateContentAsync(prompt);

            return resposta.Text;
        }

        private string GerarPromptAnaliseCodigo(string linguagem, string codigo)
        {
            return $@"
                Você é um assistente especializado em acessibilidade para o projeto VozCode.
                Seu objetivo é analisar o código fornecido e gerar um feedback claro, objetivo e fácil de ser lido por pessoas com deficiência visual usando leitores de tela.

                ### Diretrizes Gerais
                - Use linguagem simples e direta.
                - Evite frases longas e explicações desnecessárias.
                - Não use símbolos ou caracteres demais que possam atrapalhar a leitura com o leitor de tela.
                - Mantenha o Markdown limpo: apenas títulos e listas simples.
                - Nunca utilize emojis.
                - O foco é ajudar o usuário a entender e melhorar o próprio código.
                - O código será lido por um leitor de tela, então precisa ser simples.
                - Utilize parágrafos curtos, como o ChatGPT faz por padrão.
                - Mantenha um estilo profissional, organizado e calmo.

                ### Estrutura do Feedback (Obrigatória)

                ## Sugestões e Melhorias
                Liste apenas pontos realmente relevantes. Pode ser sobre boas práticas, bugs, legibilidade ou otimizações.

                (Conteúdo aqui)

                ## Explicação do Código
                Explique de forma simples o que o código faz e como funciona. Uma explicação curta é suficiente.

                (Conteúdo aqui)

                ---
                
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