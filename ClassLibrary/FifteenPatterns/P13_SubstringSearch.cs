using System;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Uses to find substring in a string.
/// </summary>
public class P13_SubstringSearch
{
    /// <summary>
    /// Searchs substring using trivial approach.
    /// </summary>
    public int Find(string text, string subs)
    {
        if (text.Length < subs.Length) return -1;

        var lastIdx = text.Length - subs.Length;
        for (var i=0; i <= lastIdx; i++)
        {
            if (text[i] == subs[0])
            {
                for (var j=1; j < subs.Length; j++)
                    if (text[i+j] != subs[j]) goto OutCheck;

                return i;
            } OutCheck:;
        }
        return -1;
    }

    /// <summary>
    /// Searchs substring using Knut-Morris-Pratt approach.
    /// </summary>
    public int Find_KMP(string text, string subs)
    {

        return -1;
    }

    /// <summary>
    /// Searchs substring using Bauer-Moor approach.
    /// </summary>
    public int Find_BM(string text, string subs)
    {

        return -1;
    }

    /// <summary>
    /// Searchs substring using Rabin-Karp approach.
    /// </summary>
    public int Find_RK(string text, string subs)
    {
        // Check sum
        var checkSum = 0L;
        for (var i=0; i < subs.Length; i++)
            checkSum += subs[i];

        // Calc sum over text in slide window
        var sum = 0L;
        var head = 0;
        var tail = 0;
        for (; head < subs.Length; head++)
            sum += text[head];
        
        if (sum == checkSum)
        {
            for (var i=0; i < subs.Length; i++)
                if (text[tail+i] != subs[i]) goto OutCheck;

            return tail;
        } OutCheck:;
        
        while (head < text.Length)
        {   
            sum += text[head++] - text[tail++]; 
            if (sum == checkSum)
            {
                for (var i=0; i < subs.Length; i++)
                    if (text[tail+i] != subs[i]) goto OutCheck2;
                
                return tail;
            } OutCheck2:;      
        }
        
        return -1;
    }

}
