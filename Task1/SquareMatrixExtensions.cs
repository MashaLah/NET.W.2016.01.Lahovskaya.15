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
        /// Extension method for SquareMatrix for calculating summ of two matrixes.
        /// </summary>
        /// <typeparam name="T">Matrix type.</typeparam>
        /// <param name="firstMatrix">Square matrix.</param>
        /// <param name="secondMatrix">Square matrix.</param>
        /// <returns>Summ of two matrixes.</returns>
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            var visitor = new AddTwoMatrixesVisitor<T>();
            firstMatrix.Accept(visitor,secondMatrix);
            return visitor.Summ;
        }
    }
}
