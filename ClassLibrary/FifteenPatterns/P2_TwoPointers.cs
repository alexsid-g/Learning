using System;
using System.Security.Cryptography.X509Certificates;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Use this pattern when dealing with arrays or lists
/// where you need to find pairs that satisfy a specific condition.
/// </summary>
public class P2_TwoPointers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    /// <param name="array"></param>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public List<(T, T)> Find<T>(IEnumerable<T> array, Func<T, T, int> predicate)
    {
        var result = new List<(T, T)>();
        var sortedArray = array.Order().ToList();

        var left = 0;
        var right = sortedArray.Count - 1; 
        while (left < right)
        {
            var predicateResult = predicate.Invoke(
                sortedArray[left], sortedArray[right]);
            if (predicateResult < 0) left++; 
            else if (predicateResult > 0) right--;
            else 
            {
                result.Add((sortedArray[left], sortedArray[right]));
                left++;
                right--;
            }
        }

        return result;
    }
}
