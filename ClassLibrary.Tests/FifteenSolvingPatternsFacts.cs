using System;

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

}
