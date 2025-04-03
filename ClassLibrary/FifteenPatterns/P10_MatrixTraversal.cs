using System;
using ClassLibrary.Models;

namespace ClassLibrary.FifteenPatterns;

/// <summary>
/// Matrix Traversal involves traversing elements in a matrix using different techniques.
/// </summary>
public class P10_MatrixTraversal
{
    /// <summary>
    /// This FluidFill uses reqursive algorithm.
    /// </summary>
    public void FluidFill<T>(T[][] matrix, int row, int column, T newValue) where T : IEquatable<T>
    {
        var value = matrix[row][column];
        var matrixLengthLim = matrix.Length - 1;
        var columnLengthLim = matrix[0].Length - 1;
        dfs(matrix, row, column, value, newValue);

        void dfs(T[][] matrix, int row, int column, T value, T newValue) 
        {
            if (!matrix[row][column].Equals(value)) return;

            matrix[row][column] = newValue;
            if (row > 0) {
                dfs(matrix, row - 1, column, value, newValue);
            }
            if (column > 0) {
                dfs(matrix, row, column - 1, value, newValue);
            }
            if (row < matrixLengthLim) {
                dfs(matrix, row + 1, column, value, newValue);
            }
            if (column < columnLengthLim) {
                dfs(matrix, row, column + 1, value, newValue);
            }
        }
    }

}

