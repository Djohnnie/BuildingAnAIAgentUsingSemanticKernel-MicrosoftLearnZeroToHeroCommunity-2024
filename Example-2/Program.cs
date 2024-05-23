using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;


var endpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
var key = Environment.GetEnvironmentVariable("OPENAI_KEY");

var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
         "gpt-4",   // Azure OpenAI Deployment Name
         endpoint,  // Azure OpenAI Endpoint
         key);      // Azure OpenAI Key
var kernel = builder.Build();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("User > ");
    Console.ForegroundColor = ConsoleColor.White;
    var request = Console.ReadLine();

    var result = chatCompletionService.GetStreamingChatMessageContentsAsync(request!, kernel: kernel);

    string fullMessage = "";
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write("Assistant > ");

    await foreach (var content in result)
    {
        Console.Write(content.Content);
        fullMessage += content.Content;
    }

    Console.WriteLine();
}