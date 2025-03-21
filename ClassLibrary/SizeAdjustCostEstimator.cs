using System;
using Microsoft.VisualBasic;

namespace ClassLibrary;

public class SizeAdjustCostEstimator
{
    public long Estimate(List<int> size, List<int> cost)
    {
        var duplicatedSizes = size.GroupBy(x => x)
            .Where(g => g.Count() > 1).Select(g => new { 
                Size = g.Key, Items = GetIndicies(size, g.Key)
            });
        
        var result = 0L;
        var existingSizes = new HashSet<int>(size);
        foreach (var x in duplicatedSizes)
        {
            x.Items.Sort((a, b) => cost[a].CompareTo(cost[b]));
            if (x.Items.Count == 2)
            {
                var idx = x.Items[0];
                var freeSize = GetFreeSize(existingSizes, x.Size);
                result += (freeSize - x.Size) * cost[idx];
                existingSizes.Add(freeSize);
            }
            else
            {
                var temp = existingSizes.ToHashSet();
                // TODO: Implement
            }
        }
        return result;
    }

    private List<int> GetIndicies(List<int> list, int value)
    {
        var result = new List<int>();
        for (var i=0; i < list.Count; i++)
            if (list[i] == value) result.Add(i);
        return result;
    }

    private int GetFreeSize(HashSet<int> sizes, int min)
    {
        while (sizes.Contains(min)) min++;
        return min;
    }

}
