// See https://aka.ms/new-console-template for more information
using SchTrivia.Core;
using SchTrivia.Core.AI;

Console.WriteLine("Hello, World!");
if (!File.Exists("openai.secret"))
{
    Console.WriteLine("No OpenAI API key found.");
    Console.ReadKey();
}
else
{
    var openai = File.ReadAllText("openai.secret");
    var gen = new OpenAIGenerator(openai);
    var question = (Question)await gen.Generate("A question about capital of any country.");
    if (question.Text == "")
    {
        Console.Error.WriteLine("Generation error.");
    }
    else
    {
        Console.WriteLine(question.Text);
        Console.WriteLine(question.RightAnswer);
        Console.ReadKey();
    }
}