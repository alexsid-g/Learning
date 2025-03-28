using System;
using ClassLibrary.Models;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Binary Tree Traversal involves visiting all the nodes in a binary tree 
/// in a specific order. It is a. k. a. BFS - breadth first search.
/// </summary>
public class P9_BreadthFirstSearch
{
    /// <summary>
    /// This search is done by queue.
    /// </summary>
    public List<T> Visit<T>(BinaryTree<T> tree) where T : IComparable<T>
    {
        var result = new List<T>();
        if (tree.Root is null) return result;

        var queue = new Queue<BinaryTree<T>.TreeNode?>();
        queue.Enqueue(tree.Root);
        
        while (queue.TryDequeue(out var item))
        {
            if (item is null) continue;

            result.Add(item.Value);
            queue.Enqueue(item.Left);
            queue.Enqueue(item.Right);
        }
        return result;
    }

}

