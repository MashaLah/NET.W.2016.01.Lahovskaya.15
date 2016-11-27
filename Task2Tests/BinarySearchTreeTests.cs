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
        static int[] array = new int[] { 1, 3, 6, 4, 7, 8, 10, 14, 13 };
        BinarySearchTree<int> intTree = new BinarySearchTree<int>(new Comparer(), array);

        /// <summary>
        /// A test for Find();
        /// </summary>
        /// <param name="x">Item to find.</param>
        /// <param name="expected">True if found, false if not.</param>
        [TestCase(7,true)]
        [TestCase(2, false)]
        public void Find_ValidData_ValidResult(int x, bool expected)
        {
            bool actual = intTree.Find(x);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A Test for Insert().
        /// </summary>
        [Test]
        public void Insert_ValidData_ValidResult()
        {
            intTree.Insert(55);
            Assert.IsTrue(intTree.Find(55));
        }

        /// <summary>
        /// A Test for Remove().
        /// </summary>
        [Test]
        public void Remove_ValidData_ValidResult()
        {
            intTree.Remove(1);
            Assert.IsFalse(intTree.Find(1));
        }
    }

    public class Comparer : IComparer<int>
    {
        public int Compare(int firstNumber, int secondNumber) =>
            firstNumber - secondNumber;
    }
}
