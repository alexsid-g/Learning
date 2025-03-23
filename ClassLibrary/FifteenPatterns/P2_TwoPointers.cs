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
    /// Find pairs in array based on condition by predicate.
    /// </summary>
    public List<(T, T)> FindPairs<T>(IEnumerable<T> array, Func<T, T, int> predicate)
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

    public bool IsPalyndrome(string input)
    {
        if (input.Length == 1) return true;
        else if (input.Length <= 3) return input[0] == input[input.Length-1];
        
        var left = 0;
        var right = input.Length-1;
        while (left < right)
        {
            if (input[left] != input[right]) return false;
            left++;
            right++;
        }
        return true;
    }
}
