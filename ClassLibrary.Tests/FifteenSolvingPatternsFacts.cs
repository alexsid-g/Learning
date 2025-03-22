using System;
using System.Linq;
using ClassLibrary.FifteenPatterns;

namespace ClassLibrary.Tests;

public class FifteenSolvingPatternsFacts
{
    [Fact]
    public void P1_RangeSum_Should_Work()
    {
        int[] array = [1, 2, 3, 4, 5];

        var service = new P1_RangeSum();
        var result = service.Sum(array, 1, 4);
        Assert.Equal(14, result);
        
        var resultEx = service.PrefixSum(array, 1, 4);
        Assert.Equal(result, resultEx);
    }

    [Fact]
    public void P2_TwoPointers_Should_Work()
    {
        int[] array = [2, 1, 3, 5, 4];

        // Find numbers which sum eq 6
        var predicate = new Func<int, int, int>((x, y) => {
            var result = x + y;
            return result > 6
                ? 1 : result < 6
                ? -1 : 0;
        });

        var service = new P2_TwoPointers();
        var result = service.Find(array, predicate);
        Assert.Equal([(1, 5), (2, 4)], result);
    }

    [Fact]
    public void P3_SlidingWindow_Should_Work()
    {
        int[] array = [2, 1, 3, 5, 4, 1];

        // Find max sum of subarray(3)
        var max = 0;
        var result = 0;
        var start = new Action<IEnumerable<int>>(x =>
        {
            result = x.Sum();
        });

        var move = new Action<int, int>((xIn, xOut) => {
            result = result + xIn - xOut;
            if (result > max) max = result;
        });

        var service = new P3_SlidingWindow();
        service.Process(array, 3, start, move);

        Assert.Equal(12, max);
    }

    [Fact]
    public void P4_FastSlowPointer_Should_Work()
    {
        var withoutLoop = P4_FastSlowPointer.CreateList(3);

        var withLoop = P4_FastSlowPointer.CreateList(3);
        withLoop.Next.Next.Next = withLoop;

        
        var service = new P4_FastSlowPointer();
        Assert.False(service.HasCycle(withoutLoop));
        Assert.False(service.HasCycleByHash(withoutLoop));

        Assert.True(service.HasCycle(withLoop));
        Assert.True(service.HasCycleByHash(withLoop));
    }

}
