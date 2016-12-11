using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        /// <summary>
        /// Author of book.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Title of book.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Year of release.
        /// </summary>
        public int Year { get; }

        /// <summary>
        /// Genre of book.
        /// </summary>
        public string Genre { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="author">Author of book.</param>
        /// <param name="title">Title of book.</param>
        /// <param name="year">Year of release.</param>
        /// <param name="genre">Genre of book.</param>
        /// <exception cref="ArgumentException">
        /// Throws when author, title or genre is null or empty or year is less than zero. 
        /// </exception>
        public Book(string author, string title, int year, string genre)
        {
            if (string.IsNullOrEmpty(author))
                throw new ArgumentException($"{nameof(author)} shouldn't be null or empty.");
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException($"{nameof(title)} shouldn't be null or empty.");
            if (year < 0)
                throw new ArgumentException($"{nameof(year)} shouldn't be less than zero.");
            if (string.IsNullOrEmpty(genre))
                throw new ArgumentException($"{nameof(genre)} shouldn't be null or empty.");

            Author = author;
            Title = title;
            Year = year;
            Genre = genre;
        }

        /// <summary>
        /// Presents string represintation of Book.
        /// </summary>
        /// <returns>String represintation of Book</returns>
        public override string ToString() =>
            $"Author: {Author}, title: {Title}, year: {Year}, genre: {Genre}.";

        /// <summary>
        /// Returns the hash code of Book.
        /// </summary>
        /// <returns>Hash code of Book.</returns>
        public override int GetHashCode() =>
            (Author.ToUpper().GetHashCode() * 31 + 
            Title.ToUpper().GetHashCode() * 31 + 
            Genre.ToUpper().GetHashCode() * 31) ^ Year;

        /// <summary>
        /// Check if <see cref="obj"/> and this book are equal.
        /// </summary>
        /// <param name="obj">Object to check on equality.</param>
        /// <returns>True if equals, false if not.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            //Book book = obj as Book;
            //if (book == null) return false;
            return Equals((Book)obj);
            //return Equals(book);
        }

        /// <summary>
        /// Check if two books are equal.
        /// </summary>
        /// <param name="other">Instance of Book.</param>
        /// <returns>True if equals, false if not.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Author.Equals(other.Author, StringComparison.CurrentCultureIgnoreCase) &&
                Title.Equals(other.Title, StringComparison.CurrentCultureIgnoreCase) &&
                Year == other.Year &&
                Genre.Equals(other.Genre, StringComparison.CurrentCultureIgnoreCase);
        }


        /// <summary>
        /// Comparison method to order or sort Book instances.
        /// </summary>
        /// <param name="other">Instance of Book.</param>
        /// <returns>Less than zero if current instance precedes <see cref="other">.
        /// Zero if current instance occurs in the same position in the sort order as <see cref="other">.
        /// Greater than zero if current instance follows <see cref="other">.
        /// </returns>
        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return Author.ToUpper().CompareTo(other.Author.ToUpper());
        }

        /// <summary>
        /// Checks if <see cref="obj"> is Book and calls CompareTo(Book other).
        /// </summary>
        /// <param name="obj">Object to compare with.</param>
        /// <returns>
        /// 1 if <see cref="obj"> is null,
        /// CompareTo(Book other) if <see cref="obj"> is Book.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Book book = obj as Book;
            if (book == null)
                throw new ArgumentException("Object is not a Book");
            return CompareTo(book);
        }

        
    }
}
