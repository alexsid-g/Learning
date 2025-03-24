using System;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// The Top 'K' Elements pattern finds the top k largest or smallest elements
//  in an array or stream of data using heaps or sorting.
/// </summary>
public class P6_TopValues
{
    /// <summary>
    /// Finds most frequent elements using heap. 
    /// </summary>
    public List<T> FrequentByHeap<T>(IEnumerable<T> elements, int n, bool isMax = false)
    {
        var items = elements.GroupBy(x => x);
        var comparer = isMax
            ? Comparer<int>.Create((a, b) => b.CompareTo(a))
            : Comparer<int>.Create((a, b) => a.CompareTo(b));

        var heap = new PriorityQueue<T, int>(comparer);
        heap.EnqueueRange(items.Select(x => (x.Key, x.Count())));

        var result = new List<T>();
        for (var i=0; i < n; i++)
            result.Add(heap.Dequeue());
        return result;
    }

    /// <summary>
    /// Finds most frequent elements using sorting. 
    /// </summary>
    public List<T> FrequentBySort<T>(IEnumerable<T> elements, int n, bool isMax = false) where T: notnull
    {
        var items = new Dictionary<T, int>();
        foreach (var item in elements)
        {
            if (items.TryGetValue(item, out var x))
            {
                items[item] = items[item] + 1;
                continue;
            }
            items.Add(item, 1);
        }

        var keys = items.Values.ToArray();
        var values = items.Keys.ToArray();

        var comparer = isMax
            ? Comparer<int>.Create((a, b) => b.CompareTo(a))
            : Comparer<int>.Create((a, b) => a.CompareTo(b));

        Array.Sort(keys, values, comparer);

        return values.Take(n).ToList();
    }
}
