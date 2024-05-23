using Microsoft.SemanticKernel;


var endpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
var key = Environment.GetEnvironmentVariable("OPENAI_KEY");

var builder = Kernel.CreateBuilder();
builder.AddAzureOpenAIChatCompletion(
         "gpt-4",   // Azure OpenAI Deployment Name
         endpoint,  // Azure OpenAI Endpoint
         key);      // Azure OpenAI Key
var kernel = builder.Build();


// Running your first prompt with Semantic Kernel
string request = "I want to know how much power my solar panels are providing.";
string prompt = $"What is the intent of this request? {request}";
Console.WriteLine(await kernel.InvokePromptAsync(prompt));
Console.WriteLine("---------------------");


// Improving the prompt with prompt engineering
prompt = @$"What is the intent of this request? {request}
You can choose between GetSolarEnergyToday, GetSolarPower, GetSolarBatteryPercentage, StartChargingCar.";
Console.WriteLine(await kernel.InvokePromptAsync(prompt));
Console.WriteLine("---------------------");


// Add structure to the output with formatting
prompt = @$"Instructions: What is the intent of this request?
Choices: GetSolarEnergyToday, GetSolarPower, GetSolarBatteryPercentage, StartChargingCar.
User Input: {request}
Intent: ";
Console.WriteLine(await kernel.InvokePromptAsync(prompt));
Console.WriteLine("---------------------");

prompt = $$"""
         ## Instructions
         Provide the intent of the request using the following format:
         
         ```json
         {
             "intent": {intent}
         }
         ```
         
         ## Choices
         You can choose between the following intents:
         
         ```json
         ["GetSolarEnergyToday", "GetSolarPower", "GetSolarBatteryPercentage", "StartChargingCar"]
         ```
         
         ## User Input
         The user input is:
         
         ```json
         {
             "request": "{{request}}"
         }
         ```
         
         ## Intent
         """;
Console.WriteLine(await kernel.InvokePromptAsync(prompt));
Console.WriteLine("---------------------");


// Provide examples with few-shot prompting
prompt = @$"Instructions: What is the intent of this request?
Choices: GetSolarEnergyToday, GetSolarPower, GetSolarBatteryPercentage, StartChargingCar.

User Input: How much energy did my solar panels provide today?
Intent: GetSolarEnergyToday

User Input: Can you start charging my car?
Intent: StartChargingCar

User Input: {request}
Intent: ";
Console.WriteLine(await kernel.InvokePromptAsync(prompt));
Console.WriteLine("---------------------");


// Tell the AI what to do to avoid doing something wrong
prompt = $"""
         Instructions: What is the intent of this request?
         If you don't know the intent, don't guess; instead respond with "Unknown".
         Choices: GetSolarEnergyToday, GetSolarPower, GetSolarBatteryPercentage, StartChargingCar.
         
         User Input: How much energy did my solar panels provide today?
         Intent: GetSolarEnergyToday
         
         User Input: Can you start charging my car?
         Intent: StartChargingCar

         User Input: {request}
         Intent: 
         """;
Console.WriteLine(await kernel.InvokePromptAsync(prompt));
Console.WriteLine("---------------------");


Console.ReadKey();