using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class DiagonalMatrix<T> : AbstractSquareMatrix<T> 
    {
        /// <summary>
        /// Initialize <see cref="order"/> and create<see cref="matrix"/> with default values.
        /// </summary>
        /// <param name="order">Order of matrix.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if order is less than 0.
        /// </exception>
        public DiagonalMatrix(int order)
        {
            if (order < 0) throw new ArgumentOutOfRangeException(nameof(order));
            Order = order;
            matrix = new T[Order];
        }

        /// <summary>
        /// Initialize <see cref="matrix"/> with input array. 
        /// Set <see cref="Order"/> = length of first dimention. 
        /// </summary>
        /// <param name="matrix">Array.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws if input array is null.
        /// </exception> 
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if length of input array is 0.
        /// </exception>
        public DiagonalMatrix(params T[] matrix)
        {
            if (ReferenceEquals(matrix, null)) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length == 0) throw new ArgumentException(nameof(matrix));

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
        protected override T GetElement(int i, int j)=> 
            i == j ? matrix[i] : default(T);

        /// <summary>
        /// Logic for set in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <param name="value"></param>
        /// <returns>Previous value for row=<paramref name="i"/> and column=<paramref name="j"/></returns>
        protected override T SetElement(int i, int j, T value)
        {
            var oldValue = matrix[i];
            matrix[i] = value;
            return oldValue;
        }

        /// <summary>
        /// Exceptions for set in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <exception cref="ArgumentException">
        /// Throws when i doesn't equal j.
        /// </exception>
        protected override void ValidateSet(int i, int j)
        {
            base.ValidateSet(i, j);
            if (i != j) throw new ArgumentException($"Can change only elements on diagonal of matrix.");
        }

        /// <summary>
        /// Initialize <see cref="matrix"/> with input array. 
        /// </summary>
        /// <param name="matrix">Array.</param>
        private void FillWith(T[] matrix)
        {
            int n = matrix.Length;
            this.matrix = new T[n];
            for (int i = 0; i < n; i++)
                this.matrix[i] = matrix[i];
        }
    }
}
