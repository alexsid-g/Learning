using System;
using System.Linq;

namespace ClassLibrary.MsBackend.Basics;

/// <summary>
/// Create method named 'DisplaySimpleMessage' and call it.
/// </summary>
public class Lab5
{
    public static void Programm()
    {
        DisplaySimpleMessage();

        GreetUser("Alex");

        Console.WriteLine("Enter positive/negative number:");
        var number = int.Parse(Console.ReadLine() ?? "");
        Console.WriteLine(IsPositive(number) ? "Positive" : "Negative");

        Console.WriteLine("Enter numbers to sum (a, b, c):");
        var input = (Console.ReadLine() ?? "").Split(',');
        var numbers = input.Select(x => int.Parse(x)).ToArray();
        Console.WriteLine("Sum: " + CalculateSum(numbers));
    }

    /// <summary>
    /// Create a method that performs a task and call it in a program. 
    // This method should print a welcome message to the console.
    /// </summary>
    public static void DisplaySimpleMessage() =>
        Console.WriteLine("Welcome, it is simple message");

    /// <summary>
    /// Greet user
    /// </summary>
    public static void GreetUser(string userName) =>
        Console.WriteLine("Hello " + userName);

    /// <summary>
    /// Check if number is positive or not
    /// </summary>
    public static bool IsPositive(int number) =>
        number >= 0;

    /// <summary>
    /// Calculate a sum of numbers
    /// </summary>
    public static long CalculateSum(int[] numbers)
    {
        var sum = 0L;
        for (int i = 0; i < numbers.Length; i++)
            sum += numbers[i];
        return sum;
    }

}
