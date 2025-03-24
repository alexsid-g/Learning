using System;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Use this when you need to merge overlapped intervals.
/// </summary>
public class P7_OverlappedIntervals
{
    /// <summary>
    /// Merge overlapped results.
    /// </summary>
    public List<(int, int)> MergeOverlapped(List<(int, int)> array)
    {
        var comparer = Comparer<(int, int)>.Create(
            (x, y) => x.Item1.CompareTo(y.Item1));
        array.Sort(comparer);

        var result = new List<(int, int)>();
        foreach (var item in array)
        {
            if (result.Count == 0) result.Add(item);
            else
            {
                var last = result.Last();
                if (item.Item1 < last.Item2 && item.Item1 >= last.Item1)
                {
                    if (last.Item2 < item.Item2) last.Item2 = item.Item2;
                }
                else
                    result.Add(item);
            }
        }
        return result;
    }

}
