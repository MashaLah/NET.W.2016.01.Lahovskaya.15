using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class SquareMatrixExtensions
    {
        /// <summary>
        /// Finds sum of two matrixes.
        /// </summary>
        /// <param name="firstMatrix">Square matrix.</param>
        /// <param name="secondmatrix">Square matrix.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when firstMatrix is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throws when secondMatrix is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Throws when input matrixes have different order.
        /// </exception>
        public static AbstractSquareMatrix<T> Add<T>(this AbstractSquareMatrix<T> firstMatrix, AbstractSquareMatrix<T> secondMatrix)
        {
            if (ReferenceEquals(firstMatrix, null)) throw new ArgumentNullException(nameof(firstMatrix));
            if (ReferenceEquals(secondMatrix, null)) throw new ArgumentNullException(nameof(secondMatrix));
            if (firstMatrix.Order != secondMatrix.Order)
                throw new ArgumentException($"{nameof(firstMatrix)} and {nameof(secondMatrix)} has different order.");

            return Add((dynamic)firstMatrix, (dynamic)secondMatrix);
        }

        private static SquareMatrix<T> Add<T>(SquareMatrix<T> firstMatrix, AbstractSquareMatrix<T> secondMatrix)
        {
            SquareMatrix<T> result = new SquareMatrix<T>(firstMatrix.Order);

            try
            {
                for (int i = 0; i < firstMatrix.Order; i++)
                    for (int j = 0; j < secondMatrix.Order; j++)
                        result[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
            }
            catch (RuntimeBinderException)
            {
                throw new RuntimeBinderException($"Type {typeof(T)} doesn't support operator +.");
            }

            return result;
        }

        private static SquareMatrix<T> Add<T>(SymmetricMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix) =>
            Add(secondMatrix, firstMatrix);

        private static SquareMatrix<T> Add<T>(DiagonalMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix) =>
            Add(secondMatrix, firstMatrix);


        private static DiagonalMatrix<T> Add<T>(DiagonalMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            DiagonalMatrix<T> result = new DiagonalMatrix<T>(firstMatrix.Order);

            try
            {
                for (int i = 0; i < firstMatrix.Order; i++)
                    for (int j = 0; j < secondMatrix.Order; j++)
                        if (i == j) result[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
            }
            catch (RuntimeBinderException)
            {
                throw new RuntimeBinderException($"Type {typeof(T)} doesn't support operator +.");
            }
            return result;
        }

        private static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix)
        {
            SymmetricMatrix<T> result = new SymmetricMatrix<T>(firstMatrix.Order);

            try
            {
                for (int i = 0; i < firstMatrix.Order; i++)
                    for (int j = 0; j < secondMatrix.Order; j++)
                        result[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
            }
            catch (RuntimeBinderException)
            {
                throw new RuntimeBinderException($"Type {typeof(T)} doesn't support operator +.");
            }

            return result;
        }

        private static SymmetricMatrix<T> Add<T>(DiagonalMatrix<T> firstMatrix, SymmetricMatrix<T> secondMatrix) =>
            Add(secondMatrix, firstMatrix);


        private static SymmetricMatrix<T> Add<T>(SymmetricMatrix<T> firstMatrix, DiagonalMatrix<T> secondMatrix)
        {
            SymmetricMatrix<T> result = new SymmetricMatrix<T>(firstMatrix.Order);

            try
            {
                for (int i = 0; i < firstMatrix.Order; i++)
                    for (int j = 0; j < secondMatrix.Order; j++)
                        result[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondMatrix[i, j];
            }
            catch (RuntimeBinderException)
            {
                throw new RuntimeBinderException($"Type {typeof(T)} doesn't support operator +.");
            }

            return result;
        }

    }
}
