using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using ClassLibrary.FifteenPatterns;

namespace ClassLibrary.Benchmarks.Benchmarks;

[MemoryDiagnoser]
[SimpleJob(RunStrategy.ColdStart, iterationCount: 3)]
[MinColumn, MaxColumn, MedianColumn]
public class P6_TopValues_Benchmark
{
    private P6_TopValues _service = new P6_TopValues();
    private int[] _array = Array.Empty<int>();

    [GlobalSetup]
    public void Setup()
    {
        _array = Enumerable.Range(0, 100)
            .Select(x => Random.Shared.Next(10))
            .ToArray();
    }

    [Benchmark]
    public bool Method_FrequentByHeap()
    {
        var result = _service.FrequentByHeap(_array, 3);
        return result[0] != -1;
    }

    [Benchmark]
    public bool Method_FrequentBySort()
    {
        var result = _service.FrequentBySort(_array, 3);
        return result[0] != -1;
    }
}
