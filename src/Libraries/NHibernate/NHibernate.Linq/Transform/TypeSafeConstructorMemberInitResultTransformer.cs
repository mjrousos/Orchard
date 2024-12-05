using System;
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
        {
            this.expression = expression;
        }

        public object TransformTuple(object[] tuple, string[] aliases)
        {
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
            {
                throw new QueryException(
                    "could not instantiate: " +
                    expression.Type.FullName,
                    e);
            }
        }

        private object InvokeConstructor(NewExpression expression, object[] args, out int argumentCount)
        {
            object valueToSet;
            int nestedArgumentCount;
            argumentCount = 0;
            ArrayList argList = new ArrayList();
            int i = 0;

            foreach (var arg in expression.Arguments)
            {
                switch (arg.NodeType)
                {
                    case ExpressionType.New:
                        valueToSet = InvokeConstructor((NewExpression)arg, args.Skip(i).ToArray(), out nestedArgumentCount);
                        i += nestedArgumentCount;
                        break;
                    case ExpressionType.MemberInit:
                        valueToSet = InvokeMemberInitExpression((MemberInitExpression)arg,
                            args.Skip(i).ToArray(), out nestedArgumentCount);
                        i += nestedArgumentCount;
                        break;
                    default:
                        valueToSet = LinqUtil.ChangeType(args[i], arg.Type);
                        i++;
                        break;
                }
                argList.Add(valueToSet);
            }
            argumentCount = i;
            return expression.Constructor.Invoke(argList.ToArray());
        }

        private object InvokeMemberInitExpression(MemberInitExpression expression, object[] args, out int argumentCount)
        {
            int nestedArgumentCount;
            object instance = InvokeConstructor(expression.NewExpression, args, out argumentCount);
            int i = argumentCount;

            foreach (MemberAssignment binding in expression.Bindings)
            {
                object valueToSet;
                switch (binding.Expression.NodeType)
                {
                    case ExpressionType.New:
                        valueToSet = InvokeConstructor((NewExpression)binding.Expression,
                            args.Skip(i).ToArray(), out nestedArgumentCount);
                        i += nestedArgumentCount;
                        break;
                    case ExpressionType.MemberInit:
                        valueToSet = InvokeMemberInitExpression((MemberInitExpression)binding.Expression,
                            args.Skip(i).ToArray(), out nestedArgumentCount);
                        i += nestedArgumentCount;
                        break;
                    default:
                        valueToSet = args[i];
                        i++;
                        break;
                }
                SetValue(binding.Member, instance, valueToSet);
            }
            return instance;
        }

        private void SetValue(MemberInfo memberInfo, object instance, object valueToSet)
        {
            var field = memberInfo as FieldInfo;
            if (field != null)
            {
                field.SetValue(instance, LinqUtil.ChangeType(valueToSet, field.FieldType));
            }
            else
            {
                var prop = memberInfo as PropertyInfo;
                prop.SetValue(instance, LinqUtil.ChangeType(valueToSet, prop.PropertyType), null);
            }
        }

        public IList TransformList(IList collection)
        {
            return collection;
        }
    }
}
