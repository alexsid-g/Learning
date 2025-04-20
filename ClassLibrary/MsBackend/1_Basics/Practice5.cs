using System.Linq;
namespace ClassLibrary.MsBackend.Basics;

public static class Practice5
{
    /*Write a function to calculate the area of a circle. The function should accept one input parameter: 
    the radius of the circle. The program should prompt the user for this value, use the function to compute
    the area, and then display the result.

    Formula: The area of a circle is given by π * r^2 where r is the radius of the circle. For Pi you will
    use the code Math.PI.
    
    Problem Statement
    Write a function to calculate the area of a trapezoid. The function should accept three input parameters: 
    the length of the two parallel sides (a and b) and the height. The program should prompt the user for 
    these values, use the function to compute the area, and then display the result.

        Formula: The area of a trapezoid is given by (a + b) / 2 * height.
    */
    public static void Program()
    {
        Console.WriteLine("Enter radius");
        var radius = double.Parse(Console.ReadLine() ?? "");
        Console.WriteLine("Area is: " + CalculateCircleArea(radius));

        var input = GetInput<double>("Enter a, b, c");
        Console.WriteLine("Area is: " + CalculateTrapecoidArea(input[0], input[1], input[2]));
        input = GetInput<double>("Enter a, b, c");
        Console.WriteLine("Area is: " + CalculateBoxVolume(input[0], input[1], input[2]));
        input = GetInput<double>("Enter a, b, c");
        Console.WriteLine("Avg is: " + CalculateAverageOfTree(input[0], input[1], input[2]));
    }

    /// <summary>
    /// public static - access modifiers
    // double - return type
    // CalculateCircleArea - method name
    // (double radius) - parameters
    // => Math.PI * radius * radius; - body
    /// </summary>
    public static double CalculateCircleArea(double radius)=>
        Math.PI * radius * radius;

    /// <summary>
    /// public static - access modifier
    // double - return type
    // CalculateTrapecoidArea - method name
    // (double a, double b, double h) - parameters
    // => (a + b) * h / 2; - body
    /// </summary>
    public static double CalculateTrapecoidArea(double a, double b, double h)=>
        (a + b) * h / 2;

    public static double CalculateBoxVolume(double a, double b, double c) =>
        (a * b * c);

    public static double CalculateAverageOfTree(double a, double b, double c) =>
        (a + b + c) / 3;

    public static T[] GetInput<T>(string message)
    {
        Console.WriteLine(message);
        var input = (Console.ReadLine() ?? "").Split(',');
        return input.Select(x =>
            (T)Convert.ChangeType(x, typeof(T))
        ).ToArray();
    }

}