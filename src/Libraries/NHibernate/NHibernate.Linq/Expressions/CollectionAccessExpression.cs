using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using NHibernate.Type;

namespace NHibernate.Linq.Expressions
{
	public class CollectionAccessExpression : PropertyAccessExpression
	{
		private readonly EntityExpression _elementExpression;
		public EntityExpression ElementExpression
		{
			get { return _elementExpression; }
		}
		public CollectionAccessExpression(string name, System.Type type, IType nhibernateType,
			EntityExpression expression, EntityExpression elementExpression)
			: base(name, type, nhibernateType, expression, NHibernateExpressionType.CollectionAccess)
			_elementExpression = elementExpression;
	}
}
