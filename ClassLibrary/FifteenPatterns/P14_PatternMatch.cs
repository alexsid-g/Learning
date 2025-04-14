using System;

namespace ClassLibrary.FifteenPatterns;

public class P14_PatternMatch
{
    public bool IsMatch(string s, string p) 
    {
        if (s == "")
        {
            return p.Replace("*", "") == "";
        } 
        return IsMatchHelper(s, 0, p, 0);
        
        bool IsMatchHelper(string s, int si, string p, int pi) 
        {
            for (; si < s.Length && pi < p.Length; si++, pi++)
            {
                if (p[pi] == '*')
                {
                    var nextPi = pi + 1;
                    if (nextPi == p.Length) return true;

                    for (var i = si; i < s.Length; i++)
                            if ((s[i] == p[nextPi] || p[nextPi] == '?') &&
                                IsMatchHelper(s, i, p, pi + 1))
                                return true;
                    
                    return false;
                }

                if (s[si] != p[pi] && p[pi] != '?')
                    return false;
            }
            return si == s.Length && pi == p.Length;
        }
    }
}
