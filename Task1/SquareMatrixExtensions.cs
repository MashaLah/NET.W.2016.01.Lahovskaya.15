using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class SquareMatrixExtensions
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> firstMatrix, SquareMatrix<T> secondMatrix)
        {
            var visitor = new AddTwoMatrixesVisitor<T>();
            firstMatrix.Accept(visitor,secondMatrix);
            return visitor.Sum;
        }
    }
}
