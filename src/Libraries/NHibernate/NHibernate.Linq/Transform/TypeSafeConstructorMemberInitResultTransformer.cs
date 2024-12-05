using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate.Linq.Util;

namespace NHibernate.Transform
{
	[Serializable]
	public class TypeSafeConstructorMemberInitResultTransformer : IResultTransformer
	{
		private readonly Expression expression;
		public TypeSafeConstructorMemberInitResultTransformer(NewExpression expression)
		{
			this.expression = expression;
		}
		public TypeSafeConstructorMemberInitResultTransformer(MemberInitExpression expression)
		public object TransformTuple(object[] tuple, string[] aliases)
			try
			{
				int argumentCount;
				switch (expression.NodeType)
				{
					case ExpressionType.New:
						return InvokeConstructor((NewExpression)expression, tuple, out argumentCount);
					case ExpressionType.MemberInit:
						return InvokeMemberInitExpression((MemberInitExpression)expression, tuple, out argumentCount);
					default:
						throw new NotSupportedException();
				}
			}
			catch (Exception e)
				throw new QueryException(
					"could not instantiate: " +
					expression.Type.FullName,
					e);
		private object InvokeConstructor(NewExpression expression, object[] args, out int argumentCount)
			object valueToSet;
			int nestedArgumentCount;
			argumentCount = 0;
			ArrayList argList = new ArrayList();
			int i = 0;
			foreach (var arg in expression.Arguments)
				switch (arg.NodeType)
						valueToSet = InvokeConstructor((NewExpression)arg, args.Skip(i).ToArray(), out nestedArgumentCount);
						i += nestedArgumentCount;
						break;
						valueToSet = InvokeMemberInitExpression((MemberInitExpression)arg,
							args.Skip(i).ToArray(), out nestedArgumentCount);
						valueToSet = LinqUtil.ChangeType(args[i], arg.Type);
						i++;
				argList.Add(valueToSet);
			argumentCount = i;
			return expression.Constructor.Invoke(argList.ToArray());
		private object InvokeMemberInitExpression(MemberInitExpression expression, object[] args, out int argumentCount)
			int nestedArgumentCount, constructorArgumentCount;
			object instance = InvokeConstructor(expression.NewExpression, args, out constructorArgumentCount);
			int i = constructorArgumentCount;
			foreach (MemberAssignment binding in expression.Bindings)
				switch (binding.Expression.NodeType)
						valueToSet = InvokeConstructor((NewExpression)binding.Expression,
						valueToSet = InvokeMemberInitExpression((MemberInitExpression)binding.Expression,
						valueToSet = args[i];
				SetValue(binding.Member, instance, valueToSet);
			return instance;
		/// <summary>
		/// Sets the value of the field or property represented by the specified
		/// <see cref="T:System.Reflection.MemberInfo"/> for the supplied object instance.
		/// </summary>
		/// <param name="memberInfo">A <see cref="T:System.Reflection.MemberInfo"/> object.</param>
		/// <param name="instance">An instance of an object.</param>
		/// <param name="valueToSet">The value to set on the specified object.</param>
		private void SetValue(MemberInfo memberInfo, object instance, object valueToSet)
			var field = memberInfo as FieldInfo;
			if (field != null)
				field.SetValue(instance, LinqUtil.ChangeType(valueToSet, field.FieldType));
			else
				var prop = memberInfo as PropertyInfo;
				prop.SetValue(instance, LinqUtil.ChangeType(valueToSet, prop.PropertyType), null);
		public IList TransformList(IList collection)
			return collection;
	}
}
