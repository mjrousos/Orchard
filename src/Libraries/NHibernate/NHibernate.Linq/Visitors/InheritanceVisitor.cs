using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq.Expressions;
using NHibernate.Linq.Expressions;

namespace NHibernate.Linq.Visitors
{
	public class InheritanceVisitor : NHibernateExpressionVisitor
	{
		private System.Type castedType;
		protected override Expression VisitQuerySource(QuerySourceExpression expr)
		{
			if (castedType != null)
				return new QuerySourceExpression(expr.Alias, expr.Query, castedType);
			return base.VisitQuerySource(expr);
		}
		protected override Expression VisitMethodCall(MethodCallExpression m)
			//this is a naive implementation and will not work for any OfType calls not called on root entity
			if (m.Method.Name == "OfType")
				this.castedType = m.Method.GetGenericArguments()[0];
			return base.VisitMethodCall(m);
	}
}
