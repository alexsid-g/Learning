using System;
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

}
