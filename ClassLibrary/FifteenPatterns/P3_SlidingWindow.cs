using System;

namespace ClassLibrary;

/// <summary>
/// Use this pattern when dealing with problems involving contiguous subarrays or substrings.
/// </summary>
public class P3_SlidingWindow
{
    /// <summary>
    /// Process array with subarray parameter.
    /// </summary>
    /// <param name="start">Gets accumulatable condition</param>
    /// <param name="move">Performe one move</param>
    public void Process<T>(IEnumerable<T> input, int windowSize,
        Action<IEnumerable<T>> start, Action<T, T> move)
    {
        var array = input.ToList();
        if (array.Count < windowSize)
            throw new ArgumentException("Value is too big", nameof(windowSize));

        start.Invoke(array.Take(windowSize));

        var i = 0;
        for (var j = windowSize; j < array.Count; i++, j++)
        {
            var valueIn = array[j];
            var valueOut = array[i];
            move.Invoke(valueIn, valueOut);
        }
    }
}
