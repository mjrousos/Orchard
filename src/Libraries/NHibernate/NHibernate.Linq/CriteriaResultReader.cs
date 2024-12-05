using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections;
using System.Collections.Generic;

namespace NHibernate.Linq
{
	/// <summary>
	/// Wraps an ICriteria object providing results when necessary.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class CriteriaResultReader<T> : IEnumerable<T>, IEnumerable
	{
		private readonly ICriteria _criteria;
		public CriteriaResultReader(ICriteria criteria)
		{
			_criteria = criteria;
		}
		private IList List()
			return _criteria.List();
		public IEnumerator<T> GetEnumerator()
			foreach (var item in List())
				yield return (T)item;
		IEnumerator IEnumerable.GetEnumerator()
			return List().GetEnumerator();
	}
}
