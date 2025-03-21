using System;

namespace ClassLibrary.Tests;

public class SizeAdjustCostEstimatorFacts
{
    [Fact]
    public void Test_Estimation_Single()
    {
        var service = new SizeAdjustCostEstimator();
        var result = service.Estimate(
            [1,  2, 2],
            [10, 5, 3]);

        Assert.Equal(3, result);
    }

    [Fact]
    public void Test_Estimation_Single_Many()
    {
        var service = new SizeAdjustCostEstimator();
        var result = service.Estimate(
            [1, 2, 2, 4, 4, 5],
            [8, 5, 3, 2, 1, 3]);
        // 2 -> 3 (1 * 3), 4 -> 6 (2 * 1)
        Assert.Equal(3 + 2, result);
    }


    [Fact]
    public void Test_Estimation_Multiple()
    {
        var service = new SizeAdjustCostEstimator();
        var result = service.Estimate(
            [1, 2, 2, 2],
            [8, 5, 3, 4]);

        Assert.Equal(10, result);
    }

}
