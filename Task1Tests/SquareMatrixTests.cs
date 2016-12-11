using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;

namespace Task1Tests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        [Test]
        public void Add_SquareSquare_Square()
        {
            int[,] ar1 = { { 1, 2, 3 }, { 5, 3, 4 }, { 6, 7, 8 } };
            int[,] ar2 = { { 1, 2, 3 }, { 5, 3, 4 }, { 6, 7, 8 } };
            SquareMatrix<int> sm1 = new SquareMatrix<int>(ar1);
            SquareMatrix<int> sm2 = new SquareMatrix<int>(ar2);
            var addMatrix = sm1.Add(sm2);
            int[,] arRes = { { 2, 4, 6 }, { 10, 6, 8 }, { 12, 14, 16 } };
            CollectionAssert.AreEqual(arRes, addMatrix);
        }
        
        [Test]
        public void Add_SquareSymmetric_Square()
        {
            int[,] ar1 = { { 1, 2, 3 }, { 5, 3, 4 }, { 6, 7, 8 } };
            int[][] arr2 = { new int[] { 1 }, new int[] { 2, 3 }, new int[] { 4, 5, 6 } };
            SymmetricMatrix<int> matSym1 = new SymmetricMatrix<int>(arr2);
            SquareMatrix<int> sm2 = new SquareMatrix<int>(ar1);
            var addMatrix = sm2.Add(matSym1);
            int[,] arRes = { { 2, 4, 7 }, { 7, 6, 9 }, { 10, 12, 14 } };
            CollectionAssert.AreEqual(arRes, addMatrix);
        }

        [Test]
        public void Add_SymmetricSquare_Square()
        {
            int[,] ar1 = { { 1, 2, 3 }, { 5, 3, 4 }, { 6, 7, 8 } };
            int[][] arr2 = { new int[] { 1 }, new int[] { 2, 3 }, new int[] { 4, 5, 6 } };
            SymmetricMatrix<int> matSym1 = new SymmetricMatrix<int>(arr2);
            SquareMatrix<int> sm2 = new SquareMatrix<int>(ar1);
            var addMatrix = matSym1.Add(sm2);
            int[,] arRes = { { 2, 4, 7 }, { 7, 6, 9 }, { 10, 12, 14 } };
            CollectionAssert.AreEqual(arRes, addMatrix);
        }

        [Test]
        public void Add_DiagonalSquare_Square()
        {
            int[,] ar1 = { { 1, 2, 3 }, { 5, 3, 4 }, { 6, 7, 8 } };
            DiagonalMatrix<int> matD2 = new DiagonalMatrix<int>(1, 2, 5);
            SquareMatrix<int> sm2 = new SquareMatrix<int>(ar1);
            var addMatrix = matD2.Add(sm2);
            int[,] arRes = { { 2, 2, 3 }, { 5, 5, 4 }, { 6, 7, 13 } };
            CollectionAssert.AreEqual(arRes, addMatrix);
        }

        [Test]
        public void Add_SquareDiagonal_Square()
        {
            int[,] ar1 = { { 1, 2, 3 }, { 5, 3, 4 }, { 6, 7, 8 } };
            DiagonalMatrix<int> matD2 = new DiagonalMatrix<int>(1, 2, 5);
            SquareMatrix<int> sm2 = new SquareMatrix<int>(ar1);
            var addMatrix = sm2.Add(matD2);
            int[,] arRes = { { 2, 2, 3 }, { 5, 5, 4 }, { 6, 7, 13 } };
            CollectionAssert.AreEqual(arRes, addMatrix);
        }

        [Test]
        public void Add_DiagonalDiagonal_Diagonal()
        {
            DiagonalMatrix<int> matD1 = new DiagonalMatrix<int>(1,2,5);
            DiagonalMatrix<int> matD2 = new DiagonalMatrix<int>(1,2,5);
            var addMatrix = matD1.Add(matD2);
            int[,] arRes = { { 2, 0, 0 }, { 0, 4, 0 }, { 0, 0, 10 } };
            CollectionAssert.AreEqual(arRes, addMatrix);
        }

        [Test]
        public void Add_SymmetricSymmetric_Symmetric()
        {
            int[][] arr1 = { new int[] { 1 }, new int[] { 2, 3 }, new int[] { 4, 5, 6 } };
            int[][] arr2 = { new int[] { 1 }, new int[] { 2, 3 }, new int[] { 4, 5, 6 } };
            SymmetricMatrix<int> matSym1 = new SymmetricMatrix<int>(arr1);
            SymmetricMatrix<int> matSym2 = new SymmetricMatrix<int>(arr2);
            var matSymRes = matSym1.Add(matSym2);
            int[][] arRes = { new int[] { 2 }, new int[] { 4, 6 }, new int[] { 8, 10, 12 } };
            SymmetricMatrix<int> matRes = new SymmetricMatrix<int>(arRes);
            CollectionAssert.AreEqual(matRes, matSymRes);
        }

        [Test]
        public void Add_SymmetricDiagonal_Symmetric()
        {
            int[][] arr1 = { new int[] { 1 }, new int[] { 2, 3 }, new int[] { 4, 5, 6 } };
            SymmetricMatrix<int> matSym1 = new SymmetricMatrix<int>(arr1);
            DiagonalMatrix<int> matD2 = new DiagonalMatrix<int>(1, 2, 5);
            var matSymRes = matSym1.Add(matD2);
            int[][] arRes = { new int[] { 2 }, new int[] { 2, 5 }, new int[] { 4, 5, 11 } };
            SymmetricMatrix<int> matRes = new SymmetricMatrix<int>(arRes);
            CollectionAssert.AreEqual(matRes, matSymRes);
        }

        [Test]
        public void Add_DiagonalSymmetric_Symmetric()
        {
            int[][] arr1 = { new int[] { 1 }, new int[] { 2, 3 }, new int[] { 4, 5, 6 } };
            SymmetricMatrix<int> matSym1 = new SymmetricMatrix<int>(arr1);
            DiagonalMatrix<int> matD2 = new DiagonalMatrix<int>(1, 2, 5);
            var matSymRes = matD2.Add(matSym1);
            int[][] arRes = { new int[] { 2 }, new int[] { 2, 5 }, new int[] { 4, 5, 11 } };
            SymmetricMatrix<int> matRes = new SymmetricMatrix<int>(arRes);
            CollectionAssert.AreEqual(matRes, matSymRes);
        }
    }
}
