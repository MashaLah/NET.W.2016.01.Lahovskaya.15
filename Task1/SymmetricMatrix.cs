using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    { 
        /// <summary>
        /// Initialize <see cref="Order"/> and create<see cref="matrix"/> with default values.
        /// </summary>
        /// <param name="order"></param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if order is less than 0.
        /// </exception>
        public SymmetricMatrix(int order)
        {
            if (order < 0) throw new ArgumentOutOfRangeException(nameof(order));
            Order = order;

            int matrixLength = FindIndex(Order);
            matrix = new T[matrixLength];
        }

        /// <summary>
        /// Initialize <see cref="matrix"/> with input array. 
        /// Set <see cref="order"/>. 
        /// </summary>
        /// <param name="matrix">jagget array.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws if input array is null.
        /// </exception> 
        /// <exception cref="ArgumentException">
        /// Throws if length of input array is 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when input array is not symmetric matrix.
        /// </exception>
        public SymmetricMatrix(T[][] matrix)
        {
            if (ReferenceEquals(matrix, null)) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length == 0) throw new ArgumentException(nameof(matrix));

            for (int i = matrix.Length; i > 0; i--)
            {
                if (matrix[matrix.Length  - i].Length != matrix.Length + 1 - i)
                    throw new ArgumentException($"{nameof(matrix)} is not symmetric matrix.");
            }

            Order = matrix.Length;
            FillWith(matrix);
        }

        /// <summary>
        /// Logic for get in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <param name="value"></param>
        /// <returns>Value for row=<paramref name="i"/> and column=<paramref name="j"/></returns>
        protected override T GetElement(int i, int j)
        {
            int index = FindIndex(Math.Max(i, j));
            return matrix[index + Math.Min(i, j)];
        }

        /// <summary>
        /// Logic for set in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <param name="value"></param>
        /// <returns>Previous value for row=<paramref name="i"/> and column=<paramref name="j"/></returns>
        protected override T SetElement(int i, int j, T value)
        {
            int index = FindIndex(Math.Max(i, j));
            var oldValue = matrix[index + Math.Min(i,j)];
            matrix[index + Math.Min(i, j)] = value;
            return oldValue;
        }

        /// <summary>
        /// Initialize <see cref="matrix"/> with input array. 
        /// </summary>
        /// <param name="matrix">jagget array.</param>
        private void FillWith(T[][] matrix)
        {
            int matrixLength = FindIndex(Order);

            this.matrix = new T[matrixLength];
            int index = 0;
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[i].Length; j++)
                    this.matrix[index++] = matrix[i][j];
        }

        /// <summary>
        /// Finds index for [] array that matches [][] array,
        /// in which length of first array is 1, length of second array is 2 etc.
        /// </summary>
        /// <param name="number">Number of rows in [][] array.</param>
        /// <returns>Index for [] array.</returns>
        private int FindIndex(int number)
        {
            int index = 0;

            for (int i = number; i > 0; i--)
                index += i;

            return index;
        }
    }
}
