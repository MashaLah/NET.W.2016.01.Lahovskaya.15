using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SymmetricMatrix<T> : SquareMatrix<T> where T :IEquatable<T> 
    {
        /// <summary>
        /// Initialize <see cref="order"/> and create<see cref="matrix"/> with default values.
        /// </summary>
        /// <param name="order">Order of matrix.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws if order is less than 0.
        /// </exception>
        public SymmetricMatrix(int order):base(order)
        {}

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
        /// <exception cref="ArgumentException">
        /// Throws when input array is not symmetric matrix.
        /// </exception>
        public SymmetricMatrix(T[,] matrix):base(matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    if (!matrix[i, j].Equals(matrix[j, i]))
                        throw new ArgumentException($"{nameof(matrix)} is not symmetric matrix.");
        }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i">Row.</param>
        /// <param name="j">Column.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when i or j less than 0 or bigger than <see cref="order"/>.
        /// </exception>
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || i > Order) throw new ArgumentOutOfRangeException(nameof(i));
                if (j < 0 || j > Order) throw new ArgumentOutOfRangeException(nameof(j));
                return matrix[i, j];
            }
            set
            {
                if (i < 0 || i > Order) throw new ArgumentOutOfRangeException(nameof(i));
                if (j < 0 || j > Order) throw new ArgumentOutOfRangeException(nameof(j));
                var oldValue = matrix[i, j];
                matrix[i, j] = value;
                matrix[j, i] = value;
                OnElementChanged($"Elements on position {i} {j} and {j} {i} has been changed from {oldValue} to {value}");
            }
        }
    }
}
