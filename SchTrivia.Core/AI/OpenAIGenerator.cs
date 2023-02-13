using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3;

namespace SchTrivia.Core.AI
{
    public class OpenAIGenerator : IAIGenerator
    {
        private readonly OpenAIService service;

        /// <summary>
        /// Generates <see cref="OpenAIGenerator"/> inctanse with OpenAI API Key.
        /// </summary>
        /// <param name="apikey">Your OpenAI API key. Visit https://platform.openai.com/account/api-keys to get your API key.</param>
        public OpenAIGenerator(string apikey)
        {
            service = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = apikey
            });
        }

        /// <summary>
        /// Generates question by description.
        /// </summary>
        /// <param name="prompt">Question description, starts with "A question about, "</param>
        /// <returns>Generated <see cref="Question"/>Question.</returns>
        public async Task<IQuestion> Generate(string prompt)
        {
            return await Generate(prompt, 128);
        }
        public async Task<IQuestion> Generate(string prompt, int maxTokens)
        {
            var completionResult = await service.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt + ", with answer.",
                Model = Models.TextDavinciV3,
                MaxTokens = maxTokens
            });
            if (!completionResult.Successful)
                return new Question();
            var parts = completionResult.Choices[0].Text.Split("\n");
            return new Question(parts[2].Substring(3), parts[3].Substring(3));
        }
    }
}
