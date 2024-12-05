using System;

namespace NHibernate.Linq.SqlClient
{
    /// <summary>
    /// Provides static methods that represent functionality provided by MS SQL Server.
    /// </summary>
    public static class SqlClientExtensions
    {
        #region DateTime Functions
        /// <summary>
        /// Returns an integer representing the day datepart of the specified date.
        /// </summary>
        /// <param name="methods"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Day(this IDbMethods methods, DateTime value)
        {
            return 0;
        }

        public static int Day(this IDbMethods methods, DateTime? value)
        {
            return 0;
        }

        public static int Month(this IDbMethods methods, DateTime value)
        {
            return 0;
        }

        public static int Month(this IDbMethods methods, DateTime? value)
        {
            return 0;
        }

        public static int Year(this IDbMethods methods, DateTime value)
        {
            return 0;
        }

        public static int Year(this IDbMethods methods, DateTime? value)
        {
            return 0;
        }
        #endregion DateTime Functions

        #region Math Functions
        #endregion Math Functions

        #region String Functions
        /// Returns the ASCII code value of the leftmost character of a character expression.
        public static int Ascii(this IDbMethods methods, string value)
        {
            return 0;
        }

        public static int Ascii(this IDbMethods methods, char value)
        {
            return 0;
        }

        public static int Ascii(this IDbMethods methods, char? value)
        {
            return 0;
        }

        /// Converts an int ASCII code to a character.
        public static char Char(this IDbMethods methods, int value)
        {
            return char.MinValue;
        }

        public static char Char(this IDbMethods methods, int? value)
        {
            return char.MinValue;
        }

        /// Returns the starting position of the specified expression in a character string.
        /// <param name="search"></param>
        public static int CharIndex(this IDbMethods methods, string value, char search)
        {
            return 0;
        }

        /// <param name="start"></param>
        public static int CharIndex(this IDbMethods methods, string value, char search, int start)
        {
            return 0;
        }

        public static int CharIndex(this IDbMethods methods, string value, string search)
        {
            return 0;
        }

        public static int CharIndex(this IDbMethods methods, string value, string search, int start)
        {
            return 0;
        }

        /// Returns the left part of a character string with the specified number of characters.
        /// <param name="length"></param>
        public static string Left(this IDbMethods methods, string value, int length)
        {
            return null;
        }

        /// Returns the number of characters of the specified string expression, excluding trailing blanks.
        public static int Len(this IDbMethods methods, string value)
        {
            return 0;
        }

        /// Returns a character expression after converting uppercase character data to lowercase.
        public static string Lower(this IDbMethods methods, string value)
        {
            return null;
        }

        /// Returns a character expression after it removes leading blanks.
        public static string LTrim(this IDbMethods methods, string value)
        {
            return null;
        }

        /// Replaces all occurrences of a specified string value with another string value.
        /// <param name="replace"></param>
        public static string Replace(this IDbMethods methods, string value, string search, string replace)
        {
            return null;
        }

        /// Repeats a string value a specified number of times.
        /// <param name="count"></param>
        public static string Replicate(this IDbMethods methods, string value, int count)
        {
            return null;
        }

        /// Returns the reverse of a character expression.
        public static string Reverse(this IDbMethods methods, string value)
        {
            return null;
        }

        /// Returns the right part of a character string with the specified number of characters.
        public static string Right(this IDbMethods methods, string value, int length)
        {
            return null;
        }

        /// Returns a character string after truncating all trailing blanks.
        public static string RTrim(this IDbMethods methods, string value)
        {
            return null;
        }

        /// Returns part of a character, binary, text, or image expression.
        public static string Substring(this IDbMethods methods, string value, int start, int length)
        {
            return null;
        }

        /// Returns a character expression with lowercase character data converted to uppercase.
        public static string Upper(this IDbMethods methods, string value)
        {
            return null;
        }
        #endregion String Functions
    }
}
