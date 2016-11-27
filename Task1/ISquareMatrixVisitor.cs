using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public interface ISquareMatrixVisitor<T>
    {
        void Visit(SquareMatrix<T> firstmatrix, SquareMatrix<T> secondMatrix);
    }
}
