using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Planning.Handlebars;
using System.ComponentModel;
namespace SemanticKernel.Planner;

internal class MathPlanner
{
    [KernelFunction]
    [Description("Solves a math problem.")]
    [return: Description("The solution to the math problem.")]
    public async Task<string> SolveAsync(
        Kernel kernel,
        [Description("The math problem to solve; describe it in 2-3 sentences to ensure full context is provided")] string problem)
    {
        try
        {
            var kernelWithMath = kernel.Clone();

            // Remove the math solver plugin so that we don't get into an infinite loop
            kernelWithMath.Plugins.Remove(kernelWithMath.Plugins["MathPlanner"]);

            // Add the math plugin so the LLM can solve the problem
            kernelWithMath.Plugins.AddFromType<MathFunctions>();

#pragma warning disable SKEXP0060 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            var planner = new HandlebarsPlanner(new HandlebarsPlannerOptions() { AllowLoops = true });

            // Create a plan
            var plan = await planner.CreatePlanAsync(kernelWithMath, problem);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{plan}");

            // Execute the plan
            Console.ForegroundColor = ConsoleColor.Yellow;
            var result = (await plan.InvokeAsync(kernelWithMath)).Trim();
#pragma warning restore SKEXP0060 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            
            Console.ForegroundColor = ConsoleColor.White;
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}