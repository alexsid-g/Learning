using System;

namespace ClassLibrary;

/// <summary>
/// Use this pattern when you need to perform multiple sum queries on a subarray 
// or need to calculate cumulative sums.
/// </summary>
public class P1_RangeSum
{
    /// <summary>
    /// Complexity O(m*n) for big number of queries (m)
    /// </summary>
    public int Sum(int[] array, int start, int end)
    {
        var result = 0;
        for (var i = start; i <= end; i++)
            result += array[i];
        return result;
    }

    /// <summary>
    /// Complexity O(n) for a big number of queries
    /// </summary>
    public int PrefixSum(int[] array, int start, int end)
    {
        var sums = new int[array.Length];
        sums[0] = array[0];

        for (var i=1; i < array.Length; i++)
            sums[i] = sums[i-1] + array[i];

        return start == 0 ? sums[end]
            : sums[end] - sums[start-1];
    }
}
