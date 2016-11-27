﻿using System;
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

        /// <summary>
        /// Initializes <see cref="comparer"/> with <paramref name="comparer"/>. 
        /// Set <see cref="root"/> is null.
        /// Set <see cref="count"/> =0.
        /// </summary>
        /// <param name="comparer">IComparer object.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <paramref name="comparer"/> is null.
        /// </exception>
        public BinarySearchTree(IComparer<T> comparer)
        {
            if (ReferenceEquals(comparer, null)) throw new ArgumentNullException(nameof(comparer));
            this.comparer = comparer;
            root = null;
            count = 0;
        }

        /// <summary>
        /// Fills tree with <paramref name="array"/>.
        /// </summary>
        /// <param name="comparer">IComparer object.</param>
        /// <param name="array">Array to insert into tree.</param>
        /// <exception cref="ArgumentNullException">
        /// Throws when <paramref name="array"/> is null.
        /// </exception>
        public BinarySearchTree(IComparer<T> comparer, params T[] array):this(comparer)
        {
            if (ReferenceEquals(array, null)) throw new ArgumentNullException(nameof(array));
            for (int i = 0; i < array.Length; i++)
                Insert(array[i]);
        }

        /// <summary>
        /// Checks if <paramref name="value"/> is in tree.
        /// </summary>
        /// <param name="value">Item to find.</param>
        /// <returns>True if is in tree, false if not.</returns>
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

        /// <summary>
        /// Insert <paramref name="value"/> into tree.
        /// </summary>
        /// <param name="value">Item to insert.</param>
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

        /// <summary>
        /// Removes <paramref name="value"/> from tree.
        /// </summary>
        /// <param name="value">Item to remove.</param>
        /// <returns>If removed successfull true, else false.</returns>
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
            /// <summary>
            /// Data in Node.
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// Left child.
            /// </summary>
            public Node<T> Left { get; set; }

            /// <summary>
            /// Right child.
            /// </summary>
            public Node<T> Right { get; set; }

            /// <summary>
            /// Initializes <see cref="Data"/> with <paramref cref="data".
            /// Set <see cref="Left"/> is null.
            /// Set <see cref="Right"/> is null.
            /// </summary>
            /// <param name="data">Data to initialize <see cref="Data"/></param>
            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }
    }
}