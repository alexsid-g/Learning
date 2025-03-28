using System;

namespace ClassLibrary.Models;

public class BinaryTree<T> where T : IComparable<T>
{
    public TreeNode? _root = null;
    public TreeNode? Root => _root;

    public BinaryTree()
    {
    }

    public BinaryTree(IEnumerable<T> values)
    {
        foreach (var item in values)
            Add(item);
    }

    public void Add(T value)
    {
        if (_root is null)
            _root = new TreeNode(value);
        else 
            _root.Add(value);
    }

    /// <summary>
    /// Tree node class.
    /// </summary>
    public class TreeNode(T value)
    {
        public T Value { get; set; } = value;
        public TreeNode? Left { get; set; } = null;
        public TreeNode? Right { get; set; } = null;

        public void Add(T value)
        {
            if (value.CompareTo(Value) < 0)
            {
                if (Left is null) Left = new TreeNode(value);
                else Left.Add(value);
            }
            else 
            {
                if (Right is null) Right = new TreeNode(value);
                else Right.Add(value);
            }
        }
    }
}
