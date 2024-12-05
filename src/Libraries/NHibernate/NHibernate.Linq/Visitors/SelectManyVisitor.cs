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
using NHibernate.SqlCommand;

namespace NHibernate.Linq.Visitors
{
	/// <summary>
	/// Adds the appropriate subcriteria to the query based on a SelectMany expression tree.
	/// </summary>
	public class SelectManyVisitor : NHibernateExpressionVisitor
	{
		private readonly ICriteria _rootCriteria;
		private readonly string _alias;
		public SelectManyVisitor(ICriteria criteria, string alias)
		{
			_rootCriteria = criteria;
			_alias = alias;
		}
		protected override Expression VisitCollectionAccess(CollectionAccessExpression expr)
			MemberNameVisitor visitor = new MemberNameVisitor(_rootCriteria, false);
			visitor.Visit(expr.Expression);
			visitor.CurrentCriteria.CreateCriteria(expr.Name, _alias, JoinType.LeftOuterJoin);
			return expr;
		protected override Expression VisitMethodCall(MethodCallExpression expr)
			Visit(expr.Arguments[0]);
	}
}
