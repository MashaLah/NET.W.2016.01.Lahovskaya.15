using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class AddTwoMatrixesVisitor<T> : ISquareMatrixVisitor<T>
    {
        public SquareMatrix<T> Sum { get; private set; }

        public void Visit(SquareMatrix<T> firstMatrix, SquareMatrix<T> secondmatrix)
        {
            if (firstMatrix == null) throw new ArgumentNullException(nameof(firstMatrix));
            if (secondmatrix == null) throw new ArgumentNullException(nameof(secondmatrix));
            if (firstMatrix.Order != secondmatrix.Order)
                throw new ArgumentException($"{nameof(firstMatrix)} and {nameof(secondmatrix)} has different order.");

            Sum = new SquareMatrix<T>(firstMatrix.Order);

            for (int i = 0; i < firstMatrix.Order; i++)
                for (int j = 0; j < secondmatrix.Order; j++)
                    Sum[i, j] = (dynamic)firstMatrix[i, j] + (dynamic)secondmatrix[i, j];
        }
    }
}
