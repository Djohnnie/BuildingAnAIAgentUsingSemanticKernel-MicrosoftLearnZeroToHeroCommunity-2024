using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace SemanticKernel.Planner;

public class MathFunctions
{
    [KernelFunction, Description("Take the square root of a number")]
    public static double Sqrt([Description("The number to take a square root of")] double number)
    {
        Console.WriteLine($"{nameof(Sqrt)} function has been called with {nameof(number)}={number}");
        return Math.Sqrt(number);
    }

    [KernelFunction, Description("Add two numbers")]
    public static double Add(
        [Description("The first number to add")] double number1,
        [Description("The second number to add")] double number2)
    {
        Console.WriteLine($"{nameof(Add)} function has been called with {nameof(number1)}={number1} and {nameof(number2)}={number2}");
        return number1 + number2;
    }

    [KernelFunction, Description("Subtract two numbers")]
    public static double Subtract(
        [Description("The first number to subtract from")] double number1,
        [Description("The second number to subtract away")] double number2)
    {
        Console.WriteLine($"{nameof(Subtract)} function has been called with {nameof(number1)}={number1} and {nameof(number2)}={number2}");
        return number1 - number2;
    }

    [KernelFunction, Description("Multiply two numbers. When increasing by a percentage, don't forget to add 1 to the percentage.")]
    public static double Multiply(
        [Description("The first number to multiply")] double number1,
        [Description("The second number to multiply")] double number2)
    {
        Console.WriteLine($"{nameof(Multiply)} function has been called with {nameof(number1)}={number1} and {nameof(number2)}={number2}");
        return number1 * number2;
    }

    [KernelFunction, Description("Divide two numbers")]
    public static double Divide(
        [Description("The first number to divide from")] double number1,
        [Description("The second number to divide by")] double number2)
    {
        Console.WriteLine($"{nameof(Divide)} function has been called with {nameof(number1)}={number1} and {nameof(number2)}={number2}");
        return number1 / number2;
    }

    [KernelFunction, Description("Raise a number to a power")]
    public static double Power(
        [Description("The number to raise")] double number1,
        [Description("The power to raise the number to")] double number2)
    {
        Console.WriteLine($"{nameof(Power)} function has been called with {nameof(number1)}={number1} and {nameof(number2)}={number2}");
        return Math.Pow(number1, number2);
    }

    [KernelFunction, Description("Take the log of a number")]
    public static double Log(
        [Description("The number to take the log of")] double number1,
        [Description("The base of the log")] double number2)
    {
        Console.WriteLine($"{nameof(Log)} function has been called with {nameof(number1)}={number1} and {nameof(number2)}={number2}");
        return Math.Log(number1, number2);
    }

    [KernelFunction, Description("Round a number to the target number of decimal places")]
    public static double Round(
        [Description("The number to round")] double number1,
        [Description("The number of decimal places to round to")] double number2)
    {
        Console.WriteLine($"{nameof(Round)} function has been called with {nameof(number1)}={number1} and {nameof(number2)}={number2}");
        return Math.Round(number1, (int)number2);
    }

    [KernelFunction, Description("Take the absolute value of a number")]
    public static double Abs([Description("The number to take the absolute value of")] double number)
    {
        Console.WriteLine($"{nameof(Abs)} function has been called with {nameof(number)}={number}");
        return Math.Abs(number);
    }

    [KernelFunction, Description("Take the floor of a number")]
    public static double Floor([Description("The number to take the floor of")] double number)
    {
        Console.WriteLine($"{nameof(Floor)} function has been called with {nameof(number)}={number}");
        return Math.Floor(number);
    }

    [KernelFunction, Description("Take the ceiling of a number")]
    public static double Ceiling([Description("The number to take the ceiling of")] double number)
    {
        Console.WriteLine($"{nameof(Ceiling)} function has been called with {nameof(number)}={number}");
        return Math.Ceiling(number);
    }

    [KernelFunction, Description("Take the sine of a number")]
    public static double Sin(
        [Description("The number to take the sine of")] double number)
    {
        Console.WriteLine($"{nameof(Sin)} function has been called with {nameof(number)}={number}");
        return Math.Sin(number);
    }

    [KernelFunction, Description("Take the cosine of a number")]
    public static double Cos([Description("The number to take the cosine of")] double number)
    {
        Console.WriteLine($"{nameof(Cos)} function has been called with {nameof(number)}={number}");
        return Math.Cos(number);
    }

    [KernelFunction, Description("Take the tangent of a number")]
    public static double Tan([Description("The number to take the tangent of")] double number)
    {
        Console.WriteLine($"{nameof(Tan)} function has been called with {nameof(number)}={number}");
        return Math.Tan(number);
    }

    [KernelFunction, Description("Take the arcsine of a number")]
    public static double Asin([Description("The number to take the arcsine of")] double number)
    {
        Console.WriteLine($"{nameof(Asin)} function has been called with {nameof(number)}={number}");
        return Math.Asin(number);
    }

    [KernelFunction, Description("Take the arccosine of a number")]
    public static double Acos([Description("The number to take the arccosine of")] double number)
    {
        Console.WriteLine($"{nameof(Acos)} function has been called with {nameof(number)}={number}");
        return Math.Acos(number);
    }

    [KernelFunction, Description("Take the arctangent of a number")]
    public static double Atan([Description("The number to take the arctangent of")] double number)
    {
        Console.WriteLine($"{nameof(Atan)} function has been called with {nameof(number)}={number}");
        return Math.Atan(number);
    }
}