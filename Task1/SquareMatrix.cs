using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class SquareMatrix<T>
    {       
        /// <summary>
        /// Array for matrix.
        /// </summary>
        protected T[,] matrix;

        /// <summary>
        /// Event happens when element of matrix has been changed.
        /// </summary>
        public event EventHandler<string> ElementChanged;

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
            matrix = new T[Order,Order];
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
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            if (matrix.Length == 0) throw new ArgumentOutOfRangeException(nameof(matrix));

            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException($"{nameof(matrix)} is not square matrix.");

            Order = matrix.GetLength(0);
            FillWith(matrix);
        }

        /// <summary>
        /// Order of matrix.
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i">Row.</param>
        /// <param name="j">Column.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when i or j less than 0 or bigger than <see cref="order"/>.
        /// </exception>
        public virtual T this[int i, int j]
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
                var oldValue = matrix[i,j];
                matrix[i, j] = value;
                OnElementChanged($"Element on position {i} {j} has been changed from {oldValue} to {value}");
            }
        }

        public void Accept(ISquareMatrixVisitor<T> visitor, SquareMatrix<T> matrix)
        {
            visitor.Visit((dynamic)this, matrix);
        }

        /// <summary>
        /// Invoke event <see cref="ElementChanged"/> 
        /// </summary>
        /// <param name="message">Information about changing.</param>
        protected virtual void OnElementChanged(string message)
        {
            ElementChanged?.Invoke(this, message);
        }

        /// <summary>
        /// Initialize <see cref="matrix"/> with input array. 
        /// </summary>
        /// <param name="matrix">2-dimention array.</param>
        private void FillWith(T[,] matrix)
        {
            int n = matrix.GetLength(0);
            this.matrix = new T[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    this.matrix[i, j] = matrix[i, j];
        }
    }
}
