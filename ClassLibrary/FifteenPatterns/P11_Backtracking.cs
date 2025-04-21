using System;
using System.ComponentModel;
using System.Drawing;
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
    /// Gets subsets of given size from the array (DFS).
    /// </summary>
    public List<List<T>> GetSubsets_DFS<T>(T[] array, int size)
    {   
        // Find a subset of size from array [123] => [12][13][23]
        // [1234] => [12][13][14][23][24][34] => [123][134][234]
        // Sorted in asc order
        var result = new List<List<T>>();
        if (array.Length < size) return result;

        Backtrack(result, array, 0, new List<T>(), size);
        return result;

        void Backtrack(List<List<T>> result, T[] array, int start, List<T> current, int size)
        {   
            if (current.Count == size)
            {
                result.Add(new List<T>(current));
                return;
            }

            for (var i=start; i < array.Length; i++)
            {
                current.Add(array[i]);
                Backtrack(result, array, i + 1, current, size);
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    /// <summary>
    /// Gets subsets of given size from the array (BFS).
    /// </summary>
    public List<List<T>> GetSubsets_BFS<T>(T[] array, int size) {
        var result = new List<List<int>>();
        var queue = new Queue<List<int>>();
        queue.Enqueue(new());
        
        while (queue.Count > 0) 
        {
            var item = queue.Dequeue();
            if (item.Count == size) {
                result.Add(item);
                continue;
            }
            
            
            var start = item.Count == 0 ? 0 : item.Last() + 1;
            for (var i = start; i < array.Length; i++)
            {
                var subset = new List<int>(item);
                subset.Add(i);
                queue.Enqueue(subset);
            }
        }

        return result
            .Select(x => new List<T>(x.Select(xx => array[xx])))
            .ToList();
    }

    /// <summary>
    /// Gets all subsets from the array.
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
