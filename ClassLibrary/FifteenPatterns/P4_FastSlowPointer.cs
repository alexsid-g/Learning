using System;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// The Fast & Slow Pointers (Tortoise and Hare) pattern is used
//  to detect cycles in linked lists and other similar structures.
/// </summary>
public class P4_FastSlowPointer
{
    /// <summary>
    /// Detects cycle (when fast reaches slow)
    /// </summary>
    public bool HasCycle<T>(ListNode<T> first)
    {
        var fast = first;
        var slow = first;
        while (fast is not null)
        {
            slow = slow?.Next;
            fast = fast?.Next?.Next;

            if (slow == fast)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Detects cycle using hash of visited items
    /// </summary>
    public bool HasCycleByHash<T>(ListNode<T> first)
    {
        var hash = new HashSet<ListNode<T>>();
        while (first is not null)
        {
            if (hash.Contains(first)) 
                return true;

            hash.Add(first);
            first = first.Next;
        }
        return false;
    }

    /// <summary>
    /// Own LinkedList node model.
    /// </summary>
    public sealed class ListNode<T>(T value)
    {
        public T Value { get; set; } = value;

        public ListNode<T> Next {get; set;}
    }

    public static ListNode<int> CreateList(int n)
    {
        ListNode<int> ptr = null;
        ListNode<int> result = null; 

        for (var i = 0; i < n; i++)
        {
            if (i == 0)
            {
                result = new ListNode<int>(i);
                ptr = result;
                continue;
            }
            
            ptr.Next = new ListNode<int>(i);
            ptr = ptr.Next;
        }
        return result;
    }
}
