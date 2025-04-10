using System;
using System.Text;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Dynamic Programming (DP) involves breaking down problems into smaller 
/// subproblems and solving them using a bottom-up or top-down approach.
/// </summary>
public class P12_DynamicProgramming
{
    /// <summary>
    /// Bottom-up approach.
    /// Calculate using cache for intermediate result (single dimention array). 
    /// Speed up algorithm because we save time on calcs (do not go twice).
    /// </summary>
    public double Fibonacci(int n)
    {
        var cache = new Dictionary<int, double>();
        return FibCache(n, cache);

        double FibCache(int n, Dictionary<int, double> cache)
        {
            if (n == 0 || n == 1) return 1;
            if (cache.ContainsKey(n)) return cache[n];

            var result = FibCache(n - 1, cache) + FibCache(n - 2, cache);
            cache.Add(n, result);
            return result;
        }
    }

    /// <summary>
    /// Bottom-up approach.
    /// Calculate using vars instead of cache (because of DAG with connectivity 2).
    /// It means we need only 2 vars instead on cach.
    /// </summary>
    public double FibonacciEx(int n)
    {
        var a = 1;
        var b = 1;
        for (var i=2; i <= n; i++)
        {
            b = a + b;
            a = b;
        }
        return b;
    }

    /// <summary>
    /// Using 2D matrix to store inermadiate results and calc everything
    /// based on previous calculations.
    /// </summary>
    public string Stones(int m, int n)
    {
        //   0 1 2 3 4 
        // 0 L W W L 
        // 1 W L L W 
        // 2 W L W W 
        // 3 L W W L  
        // 4  
        
        char[][] matrix = new char[m][];
        for (var i=0; i < m; i++) matrix[i] = new char[n];

        matrix[0][0] = 'L';
        for (int j=0; j < m; j++)
        {
            for (int i=0; i < n; i++)
            {
                var result = 'L';
                if (i > 0 && matrix[j][i-1] == 'L') result = 'W';
                else if (j > 0 && matrix[j-1][i] == 'L') result = 'W';
                else if (i > 1 && matrix[j][i-2] == 'L')  result = 'W';
                else if (j > 1 && matrix[j-2][i] == 'L')  result = 'W';
                else if (i > 1 && j > 0 && matrix[j-1][i-2] == 'L')  result = 'W';
                else if (i > 0 && j > 1 && matrix[j-2][i-1] == 'L')  result = 'W';

                matrix[j][i] = result;
            }
        }

        return matrix[m-1][n-1] == 'L' ? "Loose" : "Win";
    }

    /// <summary>
    /// Solve knapsack task using full traversal of all decisons.
    /// </summary>
    public int[] Knapsack_Full(int size, int[] weights, int[] prices)
    {
        // Result [1, 0, 1, 0] <=> 1010b
        var maxState = 0;
        var maxPrice = 0;
        var count = 2 << weights.Length;
        for (var state = 1; state < count; state++)
        {
            if (size != GetSize(state)) continue;

            // Uses optimization here (not review not matched by conditions)
            var price = StateValue(state, prices);
            if (price > maxPrice)
            {
                maxState = state;
                maxPrice = price;
            }
        }

        int[] result = new int[weights.Length];
        for (var i=0; i < result.Length; i++)
            result[i] = (maxState & (1 << i)) != 0 ? 1 : 0;

        return result;

        int StateValue(int state, int[] values) {
            var result = 0;
            for (var i=0; i < values.Length; i++)
            {
                if ((state & (1 << i)) != 0)
                    result += values[i];
            }
            return result;
        }

        int GetSize(int state) {
            int result = 0;
            while (state != 0) {
                if ((state & 1) == 1) result++;
                state >>= 1;
            }
            return result;
        }
    }

    /// <summary>
    /// Use recurrent formula.
    /// [ L(4) = 0,
    /// [ L(i) = w(i) + L(i + 1)
    /// </summary>
    public int[] Knapsack_Optimal(int size, int[] weights, int[] prices)
    {
        return Array.Empty<int>();
    }

    /// <summary>
    /// Calc how many pathes are here to visit target [*]
    /// [c][a][*]
    /// [e][d][b]
    /// [x][ ][ ]
    /// 1. Make the recurrent formula
    /// P(*) = p(a) + p(b) + 2 (a->*, b->*)
    /// P(a) = p(c) + p(d) + p(b)
    /// P(c) = p(e) + ...
    /// </summary>
    public int PathCount(int n, int m)
    {
        int[,] array = new int[n, m];
        for (var i=0; i < n; i++)
            for (var j=0; j < m; j++)
                array[i, j] = 0;
        
        // n-1, m-1 since we calc cells from 0
        return pathHelper(n-1, m-1, array);

        int pathHelper(int n, int m, int[,] array)
        {
            if (n < 0 || m < 0) return 0;
            if (n == 0 && m == 0) return 1;
            if (array[n, m] == 0)
                array[n, m] = pathHelper(n-1, m, array) + pathHelper(n, m-1, array);
            
            return array[n, m];
        }
    }

    /// <summary>
    /// Calc how many pathes are here to visit target [*]
    /// We can optimizae it by precalc memo matrix immediatly.
    /// </summary>
    public int PathCountEx(int n, int m)
    {
        int[,] array = new int[n, m];
        for (var i=0; i < n; i++) array[i, 0] = 1;
        for (var j=0; j < m; j++) array[0, j] = 1;

        for (var i=1; i < n; i++)
            for (var j=1; j < m; j++)
            {
                array[i, j] = array[i-1, j] + array[i, j-1];
            }
        return array[n-1, m-1];
    }
}
