using System;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Use this pattern for problems that require finding the next greater or smaller element.
/// </summary>
public class P5_MonotonicStack
{
    /// <summary>
    /// Find all largest elements using iteration approach.
    /// </summary>
    public List<int> Find(int[] array)
    {
        var result = new int[array.Length];
        Array.Fill(result, -1);
        
        for (var i=0; i < array.Length; i++)
            for (var j=i+1; j < array.Length; j++)
                if (array[i] < array[j])
                {
                    result[i] = j;
                    break;
                }

        return [.. result];
    }

    /// <summary>
    /// Find all largest elements using stack approach.
    /// </summary>
    public List<int> FindEx(int[] array)
    {
        var result = new int[array.Length];
        Array.Fill(result, -1);

        var stack = new Stack<int>();
        for (var i=0; i < array.Length; i++)
        {
            while (stack.Count > 0 && array[i] > array[stack.Peek()])
            {
                int idx = stack.Pop();
                result[idx] = i;
            }
            stack.Push(i);
        }
        return [.. result];
    }
}
