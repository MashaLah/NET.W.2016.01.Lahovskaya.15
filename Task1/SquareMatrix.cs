using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T> 
    {
        /// <summary>
        /// Initialize <see cref="order"/> and create<see cref="matrix"/> with default values.
        /// </summary>
        /// <param name="order">Order of matrix.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if order is less than 0.
        /// </exception>
        public SquareMatrix(int order)
        {
            if (order < 0) throw new ArgumentOutOfRangeException(nameof(order));
            Order = order;
            matrix = new T[Order*Order];
        }

        /// <summary>
        /// Initialize <see cref="matrix"/> with input array. 
        /// Set <see cref="order"/> = length of first dimention. 
        /// </summary>
        /// <param name="matrix">2-dimention array.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws if input array is null.
        /// </exception> 
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if length of input array is 0.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Input array is not square matrix.
        /// </exception>
        public SquareMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null)) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length == 0) throw new ArgumentException(nameof(matrix));

            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException($"{nameof(matrix)} is not square matrix.");

            Order = matrix.GetLength(0);
            FillWith(matrix);
        }

        /// <summary>
        /// Logic for get in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <returns>Value for row=<paramref name="i"/> and column=<paramref name="j"/></returns>
        protected override T GetElement(int i, int j)=>
            matrix[Order * i + j];

        /// <summary>
        /// Logic for set in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <param name="value"></param>
        /// <returns>Previous value for row=<paramref name="i"/> and column=<paramref name="j"/></returns>
        protected override T SetElement(int i, int j, T value)
        {
            var oldValue = matrix[Order * i + j];
            matrix[Order * i + j] = value;
            return oldValue;
        }

        /// <summary>
        /// Initialize <see cref="matrix"/> with input array. 
        /// </summary>
        /// <param name="matrix">2-dimention array.</param>
        private void FillWith(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            this.matrix = new T[n * n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    this.matrix[Order * i + j] = matrix[i, j];
        }
    }
}
