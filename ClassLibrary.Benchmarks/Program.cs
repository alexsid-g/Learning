
using System.Reflection;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var benchmarkTypes = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.GetMethods().Any(p => p.GetCustomAttribute<BenchmarkAttribute>() != null))
    .ToArray();

Console.WriteLine(Assembly.GetExecutingAssembly().FullName);
{
    Console.WriteLine(); Console.WriteLine();
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("Start Benchmarking, select test to run:");
    benchmarkTypes.Select((x, idx) =>
    {
        Console.WriteLine($"{idx} - {x}");
        return idx;
    }).Count();

    Console.Write("Your input is :> ");

    var input = Console.ReadLine();
    if (int.TryParse(input, out var x) && x >=0 && x < benchmarkTypes.Length)
    {
        BenchmarkRunner.Run(benchmarkTypes[x]);
    }
    else
    {
        Console.WriteLine("Bad test number, exit...");
    }
}
