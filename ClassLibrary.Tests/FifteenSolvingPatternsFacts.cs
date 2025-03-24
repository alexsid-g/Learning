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
    public void P2_TwoPointers_FindPairs_Should_Work()
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
        var result = service.FindPairs(array, predicate);
        Assert.Equal([(1, 5), (2, 4)], result);
    }

     [Fact]
    public void P2_TwoPointers_IsPalyndrome_Should_Work()
    {
        string[] array = ["ab", "1wer-rew1", "abcdeba", "a", "444-444-444"];
        bool[] expected = [false, true, false, false, true];

        // Find numbers which sum eq 6
        var predicate = new Func<int, int, int>((x, y) => {
            var result = x + y;
            return result > 6
                ? 1 : result < 6
                ? -1 : 0;
        });

        var service = new P2_TwoPointers();
        var result = array
            .Select(x => service.IsPalyndrome(x))
            .ToList();
        Assert.Equal(expected, result);
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

    [Fact]
    public void P5_MonotonicStack_Should_Work()
    {
        int[] array = [1, 4, 6, 8, 3, 2, 7];
        
        var service = new P5_MonotonicStack();
        var result1 = service.Find(array);
        Assert.Equal([1, 2, 3, -1, 6, 6, -1], result1);

        var result2 = service.FindEx(array);
        Assert.Equal([1, 2, 3, -1, 6, 6, -1], result2); 
    }

    [Fact]
    public void P6_TopValues_Should_Work()
    {
        int[] array = [1, 4, 1, 1, 3, 2, 1, 5, 7, 2, 1, 3, 3];
        
        var service = new P6_TopValues();
        var result1 = service.FrequentByHeap(array, 3, true);
        Assert.Equal([1, 3, 2], result1); 

        var result2 = service.FrequentBySort(array, 3, true);
        Assert.Equal([1, 3, 2], result2); 
    }

}
