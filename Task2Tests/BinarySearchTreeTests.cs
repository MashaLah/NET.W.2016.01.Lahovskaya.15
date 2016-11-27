using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        /// <summary>
        /// A test for Find();
        /// </summary>
        /// <param name="x">Item to find.</param>
        /// <param name="expected">True if found, false if not.</param>
        [TestCase(7,true)]
        [TestCase(2, false)]
        public void Insert_ValidData_ValidResult(int x, bool expected)
        {
            int[] array = new int[] { 1, 3, 6, 4, 7, 8, 10, 14, 13 };
            BinarySearchTree<int> intTree = new BinarySearchTree<int>(new Comparer(), array);
            bool actual = intTree.Find(x);
            Assert.AreEqual(expected, actual);
        }
    }

    public class Comparer : IComparer<int>
    {
        public int Compare(int firstNumber, int secondNumber) =>
            firstNumber - secondNumber;
    }
}
