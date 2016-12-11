using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public abstract class AbstractSquareMatrix<T> : IEnumerable<T> 
    {
        /// <summary>
        /// Array for matrix.
        /// </summary>
        protected T[] matrix;

        /// <summary>
        /// Event happens when element of matrix has been changed.
        /// </summary>
        public event EventHandler<ElementChangedEventArgs<T>> ElementChanged;

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="i">Row.</param>
        /// <param name="j">Column.</param>
        public T this[int i, int j]
        {
            get
            {
                ValidateGet(i, j);
                return GetElement(i, j);
            }
            set
            {
                ValidateSet(i, j);
                var oldValue = SetElement(i, j, value);
                OnElementChanged(new ElementChangedEventArgs<T>( i, j, oldValue, value));
            }
        }

        /// <summary>
        /// Exceptions for get in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when i or j less than 0 or bigger than <see cref="order"/>.
        /// </exception>
        protected virtual void ValidateGet(int i, int j)
        {
            if (i < 0 || i > Order) throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Order) throw new ArgumentOutOfRangeException(nameof(j));
        }

        /// <summary>
        /// Exceptions for set in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Throws when i or j less than 0 or bigger than <see cref="order"/>.
        /// </exception>
        protected virtual void ValidateSet(int i, int j)
        {
            if (i < 0 || i > Order) throw new ArgumentOutOfRangeException(nameof(i));
            if (j < 0 || j > Order) throw new ArgumentOutOfRangeException(nameof(j));
        }

        /// <summary>
        /// Logic for get in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <returns>Value for row=<paramref name="i"/> and column=<paramref name="j"/></returns>
        protected abstract T GetElement(int i, int j);

        /// <summary>
        /// Logic for set in indexer.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <returns>Previous value for row=<paramref name="i"/> and column=<paramref name="j"/></returns>
        protected abstract T SetElement(int i, int j, T value);

        /// <summary>
        /// Order of matrix.
        /// </summary>
        public int Order { get; protected set; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Order; i++)
                for (int j = 0; j < Order; j++)
                    yield return this[i, j];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Invoke event <see cref="ElementChanged"/> 
        /// </summary>
        /// <param name="message">Information about changing.</param>
        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }
    }

    public class ElementChangedEventArgs<T> : EventArgs
    {
        public int I { get; }
        public int J { get; }
        public T OldValue { get; }
        public T Value { get; }

        public ElementChangedEventArgs(int i, int j, T oldValue, T value)
        {
            I = i;
            J = j;
            OldValue = oldValue;
            Value = value;
        }
    }
}
