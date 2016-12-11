using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;
using Task1;
using System.Collections;

namespace Task2Tests
{
    [TestFixture]
    public class BinarySearchTreeTests
    {
        static int[] arrayInt = new int[] { 1, 3, 6, 4, 7, 8, 10, 14, 13 };
        BinarySearchTree<int> intTree = new BinarySearchTree<int>(new ComparerInt(), arrayInt);

        static string[] arrayString = new string[] { "o", "tw", "thr", "four", "fivef" };
        BinarySearchTree<string> stringTree = new BinarySearchTree<string>(new ComparerString(), arrayString);

        static Book[] arrayBook = new Book[] { new Book("Martin", "Song", 2000, "Fantasy"),
        new Book("Pratchet", "Morth", 1999, "Fantasy"),
        new Book("Bulgakov", "Notes", 1931, "Novel"),
        new Book("Golding", "Lord", 1957, "Novel"),
        new Book("Oster", "Rules", 1990, "Children Literature")};

        BinarySearchTree<Book> bookTree = new BinarySearchTree<Book>(new ComparerBook(), arrayBook);

        static Point[] arrayPoint = new Point[] { new Point(1,2), new Point (1,2), new Point (3,4),
        new Point(5,6), new Point(7,8)};

        BinarySearchTree<Point> pointTree = new BinarySearchTree<Point>(new ComparerPoint(), arrayPoint);

        /// <summary>
        /// A test for Find();
        /// </summary>
        /// <param name="x">Item to find.</param>
        /// <param name="expected">True if found, false if not.</param>
        [TestCase(7,true)]
        [TestCase(2, false)]
        public void Find_Int_ValidResult(int x, bool expected)
        {
            bool actual = intTree.Find(x);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Find();
        /// </summary>
        /// <param name="x">Item to find.</param>
        /// <param name="expected">True if found, false if not.</param>
        [TestCase("three", true)]
        [TestCase("twenty", false)]
        public void Find_String_ValidResult(string x, bool expected)
        {
            bool actual = stringTree.Find(x);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Find();
        /// </summary>
        /// <param name="x">Item to find.</param>
        /// <param name="expected">True if found, false if not.</param>
        [Test,TestCaseSource(nameof(ValidTestCasesBookFind))]
        public void Find_Book_ValidResult(Book x, bool expected)
        {
            bool actual = bookTree.Find(x);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Find();
        /// </summary>
        /// <param name="x">Item to find.</param>
        /// <param name="expected">True if found, false if not.</param>
        [Test, TestCaseSource(nameof(ValidTestCasesPointFind))]
        public void Find_Point_ValidResult(Point x, bool expected)
        {
            bool actual = pointTree.Find(x);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A Test for Insert().
        /// </summary>
        [Test]
        public void Insert_Int_ValidResult()
        {
            intTree.Insert(55);
            Assert.IsTrue(intTree.Find(55));
        }

        /// <summary>
        /// A Test for Insert().
        /// </summary>
        [Test]
        public void Insert_String_ValidResult()
        {
            stringTree.Insert("eleven");
            Assert.IsTrue(stringTree.Find("eleven"));
        }

        /// <summary>
        /// A Test for Insert().
        /// </summary>
        [Test, TestCaseSource(nameof(ValidTestCasesBookInsert))]
        public void Insert_Book_ValidResult(Book x, Book y)
        {
            bookTree.Insert(x);
            Assert.IsTrue(bookTree.Find(y));
        }

        /// <summary>
        /// A Test for Insert().
        /// </summary>
        [Test, TestCaseSource(nameof(ValidTestCasesPointInsert))]
        public void Insert_Point_ValidResult(Point x, Point y)
        {
            pointTree.Insert(x);
            Assert.IsTrue(pointTree.Find(y));
        }

        /// <summary>
        /// A Test for Remove().
        /// </summary>
        [Test]
        public void Remove_Int_ValidResult()
        {
            intTree.Remove(1);
            Assert.IsFalse(intTree.Find(1));
        }

        /// <summary>
        /// A Test for Remove().
        /// </summary>
        [Test]
        public void Remove_String_ValidResult()
        {
            stringTree.Remove("two");
            Assert.IsFalse(stringTree.Find("two"));
        }

        /// <summary>
        /// A Test for Remove().
        /// </summary>
        [Test, TestCaseSource(nameof(ValidTestCasesBookRemove))]
        public void Remove_Book_ValidResult(Book x, Book y)
        {
            bookTree.Remove(x);
            Assert.IsFalse(bookTree.Find(y));
        }

        /// <summary>
        /// A Test for Remove().
        /// </summary>
        [Test, TestCaseSource(nameof(ValidTestCasesPointRemove))]
        public void Remove_Point_ValidResult(Point x, Point y)
        {
            pointTree.Remove(x);
            Assert.IsFalse(pointTree.Find(y));
        }

        static IEnumerable ValidTestCasesBookFind
        {
            get
            {
                yield return new TestCaseData(new Book("Martin", "Song", 2000, "Fantasy"), true);
                yield return new TestCaseData(new Book("Dostoevsky", "Crime", 1885, "Novel"), false);
            }
        }

        static IEnumerable ValidTestCasesBookInsert
        {
            get
            {
                yield return new TestCaseData(new Book("Dostoevsky", "Crime", 1885, "Novel"), 
                    new Book("Dostoevsky", "Crime", 1885, "Novel"));
            }
        }

        static IEnumerable ValidTestCasesBookRemove
        {
            get
            {
                yield return new TestCaseData(new Book("Pratchet", "Morth", 1999, "Fantasy"),
                    new Book("Pratchet", "Morth", 1999, "Fantasy"));
            }
        }

        static IEnumerable ValidTestCasesPointFind
        {
            get
            {
                yield return new TestCaseData(new Point(3, 4), true);
                yield return new TestCaseData(new Point(10, 10), false);
            }
        }

        static IEnumerable ValidTestCasesPointInsert
        {
            get
            {
                yield return new TestCaseData(new Point(100, 100), new Point(100, 100));
            }
        }

        static IEnumerable ValidTestCasesPointRemove
        {
            get
            {
                yield return new TestCaseData(new Point(3, 4), new Point(3, 4));
            }
        }
    }

    public class ComparerInt : IComparer<int>
    {
        public int Compare(int firstNumber, int secondNumber) =>
            firstNumber - secondNumber;
    }

    public class ComparerString : IComparer<string>
    {
        public int Compare(string first, string second) =>
            first.Length - second.Length;      
    }

    public class ComparerBook : IComparer<Book>
    {
        public int Compare(Book first, Book second) =>
            first.Year - second.Year;
    }

    public class ComparerPoint : IComparer<Point>
    {
        public int Compare(Point first, Point second) =>
            first.X - second.X;
    }
}
