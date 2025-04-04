using System;
using System.Linq;
using System.Numerics;
using ClassLibrary.FifteenPatterns;
using ClassLibrary.Models;

namespace ClassLibrary.Tests;

public class FifteenSolvingPatternsFacts
{
    [Fact]
    public void P1_RangeSum_Should_Work()
    {
        int[] array = [1, 2, 3, 4, 5];

        var service = new P1_RangeSum();
        var result = service.Sum(array, 1, 4);
        Assert.Equal(14, result);
        
        var resultEx = service.PrefixSum(array, 1, 4);
        Assert.Equal(result, resultEx);
    }

    [Fact]
    public void P2_TwoPointers_FindPairs_Should_Work()
    {
        int[] array = [2, 1, 3, 5, 4];

        // Find numbers which sum eq 6
        var predicate = new Func<int, int, int>((x, y) => {
            var result = x + y;
            return result > 6
                ? 1 : result < 6
                ? -1 : 0;
        });

        var service = new P2_TwoPointers();
        var result = service.FindPairs(array, predicate);
        Assert.Equal([(1, 5), (2, 4)], result);
    }

     [Fact]
    public void P2_TwoPointers_IsPalyndrome_Should_Work()
    {
        string[] array = ["ab", "1wer-rew1", "abcdeba", "a", "444-444-444"];
        bool[] expected = [false, true, false, true, true];

        // Find numbers which sum eq 6
        var predicate = new Func<int, int, int>((x, y) => {
            var result = x + y;
            return result > 6
                ? 1 : result < 6
                ? -1 : 0;
        });

        var service = new P2_TwoPointers();
        var result = array
            .Select(x => service.IsPalyndrome(x))
            .ToList();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void P3_SlidingWindow_Should_Work()
    {
        int[] array = [2, 1, 3, 5, 4, 1];

        // Find max sum of subarray(3)
        var max = 0;
        var result = 0;
        var start = new Action<IEnumerable<int>>(x =>
        {
            result = x.Sum();
        });

        var move = new Action<int, int>((xIn, xOut) => {
            result = result + xIn - xOut;
            if (result > max) max = result;
        });

        var service = new P3_SlidingWindow();
        service.Process(array, 3, start, move);

        Assert.Equal(12, max);
    }

    [Fact]
    public void P4_FastSlowPointer_Should_Work()
    {
        var withoutLoop = P4_FastSlowPointer.CreateList(3);

        var withLoop = P4_FastSlowPointer.CreateList(3);
        withLoop.Next.Next.Next = withLoop;


        var service = new P4_FastSlowPointer();
        Assert.False(service.HasCycle(withoutLoop));
        Assert.False(service.HasCycleByHash(withoutLoop));

        Assert.True(service.HasCycle(withLoop));
        Assert.True(service.HasCycleByHash(withLoop));
    }

    [Fact]
    public void P5_MonotonicStack_Should_Work()
    {
        int[] array = [1, 4, 6, 8, 3, 2, 7];
        
        var service = new P5_MonotonicStack();
        var result1 = service.Find(array);
        Assert.Equal([1, 2, 3, -1, 6, 6, -1], result1);

        var result2 = service.FindEx(array);
        Assert.Equal([1, 2, 3, -1, 6, 6, -1], result2); 
    }

    [Fact]
    public void P6_TopValues_Should_Work()
    {
        int[] array = [1, 4, 1, 1, 3, 2, 1, 5, 7, 2, 1, 3, 3];
        
        var service = new P6_TopValues();
        var result1 = service.FrequentByHeap(array, 3, true);
        Assert.Equal([1, 3, 2], result1); 

        var result2 = service.FrequentBySort(array, 3, true);
        Assert.Equal([1, 3, 2], result2); 
    }

    [Fact]
    public void P7_OverlappedIntervals_Should_Work()
    {
        List<(int, int)> array = [(1,3), (3, 5), (3, 4), (5, 8), (6, 7), (7, 8), (8, 12)];
        
        var service = new P7_OverlappedIntervals();
        var result = service.MergeOverlapped(array);
        Assert.Equal([(1, 3), (3, 5), (5, 8), (8, 12)], result); 
    }

    [Fact]
    public void P8_DeepFirstSearch_Should_Work()
    {
        // https://en.wikipedia.org/wiki/File:Sorted_binary_tree_ALL_RGB.svg
        int[] values = [6, 2, 1, 4, 3, 5, 7, 8, 9];
        
        var tree = new BinaryTree<int>();
        foreach (var i in values)
            tree.Add(i);
        
        var service = new P8_DeepFirstSearch();
        var resultPre = service.VisitPreOrder(tree);
        Assert.Equal([6, 2, 1, 4, 3, 5, 7, 8, 9], resultPre); 

        var resultPreItr = service.VisitPreOrderIterative(tree);
        Assert.Equal([6, 2, 1, 4, 3, 5, 7, 8, 9], resultPre); 

        var resultIn = service.VisitInOrder(tree);
        Assert.Equal([1, 2, 3, 4, 5, 6, 7, 8, 9], resultIn); 

        var resultPost = service.VisitPostOrder(tree);
        Assert.Equal([1, 3, 5, 4, 2, 9, 8, 7 ,6], resultPost);
    }

    [Fact]
    public void P9_DeepFirstSearch_Should_Work()
    {
        int[] values = [6, 2, 1, 4, 3, 5, 7, 8, 9];
        
        var tree = new BinaryTree<int>();
        foreach (var i in values)
            tree.Add(i);
        
        var service = new P9_BreadthFirstSearch();
        var resultPre = service.Visit(tree);
        Assert.Equal([6, 2, 7, 1, 4, 8, 3, 5, 9], resultPre);
    }

    [Fact]
    public void P10_DeepFirstSearch_Should_Work()
    {
        int[][] matrix = [
            [1, 1, 0],
            [1, 3, 3],
            [1, 0, 1],
        ];
    
        
        var service = new P10_MatrixTraversal();
        service.FluidFill(matrix, 0, 1, 2);
        Assert.Equal([
            [2, 2, 0],
            [2, 3, 3],
            [2, 0, 1],
        ], matrix);
    }

}
