using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using ClassLibrary.FifteenPatterns;

namespace ClassLibrary.Benchmarks.Benchmarks;

[MemoryDiagnoser]
//[SimpleJob(RunStrategy.ColdStart, iterationCount: 10)]
[MinColumn, MaxColumn, MedianColumn]
public class P13_SubstringSearch_Benchmark
{
    private string _search = "afij";
    private string _text = "akhafs lkaafidlk ifaf oijef klafds flksdjf sdafxijdsa jfds asjidfj ass!";
    private P13_SubstringSearch _service = new P13_SubstringSearch();

    [GlobalSetup]
    public void Setup()
    {
        var maxTextSize = 1000000;
        var maxSearchSize = 20;
        var text = new StringBuilder(_text);
        var search = new StringBuilder(_search);
        
        for (var i=0; i < maxTextSize; i++)
        {
            if (i < maxSearchSize)
            {
                search.Append(' ');
                search.Append(_search);
            }

            text.Append(' ');
            text.Append(_text);
            text.Append(' ');
            text.Append(_search);

            if (i == maxTextSize - 2)
                text.Append(search);
        }

        _text = text.ToString();
        _search = search.ToString();
    }

    [Benchmark]
    public bool Method_Find()
    {
        var result = _service.Find(_text, _search);
        return result != -1;
    }

    [Benchmark]
    public bool Method_Find_RK()
    {
        var result = _service.Find_RK(_text, _search);
        return result != -1;
    }

}
