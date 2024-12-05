using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections;

namespace NHibernate.Linq.Transform
{
	public class LinqJoinResultsTransformer : NHibernate.Transform.IResultTransformer
	{
		private readonly System.Type _entityType;
		public LinqJoinResultsTransformer(System.Type entityType)
		{
			_entityType = entityType;
		}
		public IList TransformList(IList collection)
			return collection;
		public object TransformTuple(object[] tuple, string[] aliases)
			foreach (object obj in tuple)
			{
				if (obj != null && obj.GetType() == _entityType)
				{
					return obj;
				}
			}
			return null;
	}
}
