using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NHibernate.Linq.Visitors
{
	public static class Evaluator
	{
		/// <summary>
		/// Performs evaluation & replacement of independent sub-trees
		/// </summary>
		/// <param name="expression">The root of the expression tree.</param>
		/// <param name="fnCanBeEvaluated">A function that decides whether a given expression node can be part of the local function.</param>
		/// <returns>A new tree with sub-trees evaluated and replaced.</returns>
		public static Expression PartialEval(Expression expression, Func<Expression, bool> fnCanBeEvaluated)
		{
			return new SubtreeEvaluator(new Nominator(fnCanBeEvaluated).Nominate(expression)).Eval(expression);
		}
		public static Expression PartialEval(Expression expression)
			return PartialEval(expression, Evaluator.CanBeEvaluatedLocally);
		private static bool CanBeEvaluatedLocally(Expression expression)
			if (expression.NodeType == ExpressionType.Constant)
			{
				return !(((ConstantExpression)expression).Value is IQueryable);
			}
			return expression.NodeType != ExpressionType.Parameter;
		/// Evaluates & replaces sub-trees when first candidate is reached (top-down)
		class SubtreeEvaluator : ExpressionVisitor
			HashSet<Expression> candidates;
			internal SubtreeEvaluator(HashSet<Expression> candidates)
				this.candidates = candidates;
			internal Expression Eval(Expression exp)
				return this.Visit(exp);
			public override Expression Visit(Expression exp)
				if (exp == null)
				{
					return null;
				}
				if (this.candidates.Contains(exp))
					return this.Evaluate(exp);
				return base.Visit(exp);
			private Expression Evaluate(Expression e)
				if (e.NodeType == ExpressionType.Constant)
					return e;
				if (e.NodeType == ExpressionType.Lambda)
				LambdaExpression lambda = Expression.Lambda(e);
				Delegate fn = lambda.Compile();
				return Expression.Constant(fn.DynamicInvoke(null), e.Type);
		/// Performs bottom-up analysis to determine which nodes can possibly
		/// be part of an evaluated sub-tree.
		class Nominator : ExpressionVisitor
			Func<Expression, bool> fnCanBeEvaluated;
			bool cannotBeEvaluated;
			internal Nominator(Func<Expression, bool> fnCanBeEvaluated)
				this.fnCanBeEvaluated = fnCanBeEvaluated;
			internal HashSet<Expression> Nominate(Expression expression)
				this.candidates = new HashSet<Expression>();
				this.Visit(expression);
				return this.candidates;
			public override Expression Visit(Expression expression)
				if (expression != null)
					bool saveCannotBeEvaluated = this.cannotBeEvaluated;
					this.cannotBeEvaluated = false;
					base.Visit(expression);
					if (!this.cannotBeEvaluated)
					{
						if (this.fnCanBeEvaluated(expression))
						{
							this.candidates.Add(expression);
						}
						else
							this.cannotBeEvaluated = true;
					}
					this.cannotBeEvaluated |= saveCannotBeEvaluated;
				return expression;
	}
}
