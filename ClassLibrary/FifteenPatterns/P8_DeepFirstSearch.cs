using System;
using ClassLibrary.Models;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Binary Tree Traversal involves visiting all the nodes in a binary tree 
/// in a specific order in a depth. It is a. k. a. DFS - deep first search.
/// </summary>
public class P8_DeepFirstSearch
{
    /// <summary>
    /// Pre-order traversal (root, left, right). Visit when first time meet.
    /// Useful to create expression from binary expression tree
    /// </summary>
    public List<T> VisitPreOrder<T>(BinaryTree<T> tree) where T : IComparable<T>
    {
        var result = new List<T>();
        Visit(tree.Root, result);
        
        return result;
        void Visit(BinaryTree<T>.TreeNode node, List<T> values)
        {
            if (node is null) return;
            values.Add(node.Value);

            Visit(node.Left, values);
            Visit(node.Right, values);
        }
    }

    public List<T> VisitPreOrderIterative<T>(BinaryTree<T> tree) where T : IComparable<T>
    {
        var result = new List<T>();
        if (tree.Root is null) return result;

        var stack = new Stack<BinaryTree<T>.TreeNode>();
        stack.Push(tree.Root);
        while (stack.TryPop(out var item))
        {
            if (item is null) continue;
            result.Add(item.Value);
            stack.Push(item.Left);
            stack.Push(item.Right);
        }
        return result;
    }

    /// <summary>
    /// In-order traversal (left, root, right). Visit when second time meet.
    /// </summary>
    public List<T> VisitInOrder<T>(BinaryTree<T> tree) where T : IComparable<T>
    {
        var result = new List<T>();
        Visit(tree.Root, result);
        
        return result;
        void Visit(BinaryTree<T>.TreeNode node, List<T> values)
        {
            if (node is null) return;

            Visit(node.Left, values);
            values.Add(node.Value);
            Visit(node.Right, values);
        }
    }

    /// <summary>
    /// Post-order traversal (left, right, root). Visit when last time meet.
    /// Useful to get posfix record of binary expression tree
    /// </summary>
    public List<T> VisitPostOrder<T>(BinaryTree<T> tree) where T : IComparable<T>
    {
        var result = new List<T>();
        Visit(tree.Root, result);
        
        return result;
        void Visit(BinaryTree<T>.TreeNode node, List<T> values)
        {
            if (node is null) return;

            Visit(node.Left, values);
            Visit(node.Right, values);
            values.Add(node.Value);
        }
    }
}
