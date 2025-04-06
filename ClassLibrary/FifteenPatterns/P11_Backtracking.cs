using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Backtracking explores all possible solutions and backtracks when a solution path fails.
/// Use this pattern when you need to find all (or some) solutions to a problem that satisfies given constraints. 
/// For example: combinatorial problems, such as generating permutations, combinations, or subsets.
/// </summary>
public class P11_Backtracking
{
    public List<int[]> GetPermutations(int[] initial)
    {
        var result = new List<int[]>();
        PermutationsHelper(result, initial, 0); 
        return result;

        void PermutationsHelper(List<int[]> accumulator, int[] initial, int start)
        {   
            if (initial.Length - 1 == start)
            {
                var permutation = new int[initial.Length];
                Array.Copy(initial, permutation, initial.Length);
                accumulator.Add(permutation);
                return;
            }

            for (var i = start; i < initial.Length; i++)
            {
                var temp = initial[start];
                initial[start] = initial[i];
                initial[i] = temp;

                PermutationsHelper(accumulator, initial, start + 1);
                
                initial[i] = initial[start];
                initial[start] = temp;
            }
        }
    }

    /// <summary>
    /// Gets all subsets of given size from the array.
    /// </summary>
    public List<List<T>> GetSubsets<T>(T[] array, int size)
    {   
        // Find a subset of size from array [123] => [12][13][23]
        // [1234] => [12][13][14][23][24][34] => [123][134][234]
        // Sorted in asc order
        var result = new List<List<T>>();
        if (array.Length < size) return result;

        var limit = array.Length - size + 1;
        return Backtrack(result, array, 0);

        List<List<T>> Backtrack(List<List<T>> result, T[] array, int start)
        {   
            if (start >= limit) return result;
            for (var i = start; i < limit; i++)
            {
                List<T> subset = [array[start]];
                for (var j = 1; j < size; j++)
                    subset.Add(array[i + j]);

                result.Add(subset);
            }
            return Backtrack(result, array, start + 1);
        }
    }

    /// <summary>
    /// Gets all subsets of given size from the array.
    /// </summary>
    public List<List<T>> GetSubsetsFull<T>(T[] array)
    {
        var result = new List<List<T>>();
        result.Add([]);

        foreach (var item in array)
        {
            var n = result.Count;
            for (var i=0; i < n; i++)
            {
                var newSubset = new List<T>(result[i]);
                newSubset.Add(item);
                result.Add(newSubset);
            }
        }
        return result;
    }
}
