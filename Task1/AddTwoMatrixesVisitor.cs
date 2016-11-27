﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class AddTwoMatrixesVisitor<T> : ISquareMatrixVisitor<T>
    {
        /// <summary>
        /// Summ of two matrixes.
        /// </summary>
        public SquareMatrix<T> Summ { get; private set; }

        /// <summary>
        /// Initialize <see cref="Summ"/> with summ of input matrixes.
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
        public void Visit(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondmatrix)
        {
            if (firstMatrix == null) throw new ArgumentNullException(nameof(firstMatrix));
            if (secondmatrix == null) throw new ArgumentNullException(nameof(secondmatrix));
            if (firstMatrix.Order != secondmatrix.Order)
                throw new ArgumentException($"{nameof(firstMatrix)} and {nameof(secondmatrix)} has different order.");

            Summ = new SquareMatrix<T>(firstMatrix.Order);

            for (int i = 0; i < firstMatrix.Order; i++)
                for (int j = 0; j < secondmatrix.Order; j++)
                    Summ[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondmatrix[i, j];
        }
    }
}
