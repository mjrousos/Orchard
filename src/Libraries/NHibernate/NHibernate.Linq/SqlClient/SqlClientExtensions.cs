using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

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
		/// Returns an integer that represents the month part of a specified date.
		public static int Month(this IDbMethods methods, DateTime value)
		public static int Month(this IDbMethods methods, DateTime? value)
		/// Returns an integer that represents the year part of a specified date.
		public static int Year(this IDbMethods methods, DateTime value)
		public static int Year(this IDbMethods methods, DateTime? value)
		#endregion DateTime Functions
		#region Math Functions
		#endregion Math Functions
		#region String Functions
		/// Returns the ASCII code value of the leftmost character of a character expression.
		public static int Ascii(this IDbMethods methods, string value)
		public static int Ascii(this IDbMethods methods, char value)
		public static int Ascii(this IDbMethods methods, char? value)
		/// Converts an int ASCII code to a character.
		public static char Char(this IDbMethods methods, int value)
			return char.MinValue;
		public static char Char(this IDbMethods methods, int? value)
		/// Returns the starting position of the specified expression in a character string.
		/// <param name="search"></param>
		public static int CharIndex(this IDbMethods methods, string value, char search)
		/// <param name="start"></param>
		public static int CharIndex(this IDbMethods methods, string value, char search, int start)
		public static int CharIndex(this IDbMethods methods, string value, string search)
		public static int CharIndex(this IDbMethods methods, string value, string search, int start)
		/// Returns the left part of a character string with the specified number of characters.
		/// <param name="length"></param>
		public static string Left(this IDbMethods methods, string value, int length)
			return null;
		/// Returns the number of characters of the specified string expression, excluding trailing blanks.
		public static int Len(this IDbMethods methods, string value)
		/// Returns a character expression after converting uppercase character data to lowercase.
		public static string Lower(this IDbMethods methods, string value)
		/// Returns a character expression after it removes leading blanks.
		public static string LTrim(this IDbMethods methods, string value)
		/// Replaces all occurrences of a specified string value with another string value.
		/// <param name="replace"></param>
		public static string Replace(this IDbMethods methods, string value, string search, string replace)
		/// Repeats a string value a specified number of times.
		/// <param name="count"></param>
		public static string Replicate(this IDbMethods methods, string value, int count)
		/// Returns the reverse of a character expression.
		public static string Reverse(this IDbMethods methods, string value)
		/// Returns the right part of a character string with the specified number of characters.
		public static string Right(this IDbMethods methods, string value, int length)
		/// Returns a character string after truncating all trailing blanks.
		public static string RTrim(this IDbMethods methods, string value)
		/// Returns part of a character, binary, text, or image expression.
		public static string Substring(this IDbMethods methods, string value, int start, int length)
		/// Returns a character expression with lowercase character data converted to uppercase.
		public static string Upper(this IDbMethods methods, string value)
		#endregion String Functions
	}
}
