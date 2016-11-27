using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class BinarySearchTree<T>
    {
        private Node<T> root;
        private int count;
        private IComparer<T> comparer;

        public BinarySearchTree(IComparer<T> comparer)
        {
            this.comparer = comparer;
            root = null;
            count = 0;
        }

        public BinarySearchTree(IComparer<T> comparer, params T[] array):this(comparer)
        {
            for (int i = 0; i < array.Length; i++)
                Insert(array[i]);
        }

        public bool Find(T value)
        {
            Node<T> current = root;
            int result;
            while (current != null)
            {
                result = comparer.Compare(current.Data, value);
                if (result == 0) return true;
                if (result > 0) current = current.Left;
                if (result < 0) current = current.Right;
            }
            return false;
        }

        public void Insert(T value)
        {
            Node<T> node = new Node<T>(value);
            Node<T> current = root;
            Node<T> parent = null;
            int result;

            while (current != null)
            {
                result = comparer.Compare(current.Data, value);
                if (result == 0) return;
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
            }
            count++;
            if (parent == null) root = node;
            else
            {
                result = comparer.Compare(parent.Data, value);
                if (result > 0) parent.Left = node;
                else parent.Right = node;
            }
        }

        public bool Remove(T value)
        {
            if (root == null) return false;
            Node<T> current = root;
            Node<T> parent = null;
            int result = comparer.Compare(current.Data, value);
            while (result != 0)
            {
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                if (current == null) return false;
                else result = comparer.Compare(current.Data, value);
            }
            count--;

            if (current.Right == null)
            {
                if (parent == null)
                    root = current.Left;
                else
                {
                    result = comparer.Compare(parent.Data, current.Data);
                    if (result > 0) parent.Left = current.Left;
                    if (result < 0) parent.Right = current.Left;
                }
            }

            if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                    root = current.Right;
                else
                {
                    result = comparer.Compare(parent.Data, current.Data);
                    if (result > 0) parent.Left = current.Right;
                    if (result < 0) parent.Right = current.Right;
                }
            }
            else
            {
                Node<T> leftmost = current.Right.Left;
                Node<T> leftmostParent = current.Right;

                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null) root = leftmost;
                else
                {
                    result = comparer.Compare(parent.Data, current.Data);
                    if (result > 0) parent.Left = leftmost;
                    if (result < 0) parent.Right = leftmost;
                }
            }
            return true;
        }

        private class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }

            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }
    }
}
