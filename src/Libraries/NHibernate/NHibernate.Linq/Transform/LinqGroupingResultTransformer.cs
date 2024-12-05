using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NHibernate.Transform;

namespace NHibernate.Linq.Transform
{
    /// <summary>
    /// Transforms critieria query results into a collection of grouped objects.
    /// </summary>
    public class LinqGroupingResultTransformer : IResultTransformer
    {
        private readonly System.Type groupingType;
        private readonly IDictionary<Object, IGrouping> groups;
        private readonly String propertyName;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NHibernate.Linq.LinqGroupingResultTransformer"/> class.
        /// </summary>
        /// <param name="type">A <see cref="T:System.Type"/> representing the type of collection to transform.</param>
        /// <param name="propertyName">The name of the property to be used as a key for the purpose of grouping.</param>
        public LinqGroupingResultTransformer(System.Type type, String propertyName)
        {
            System.Type[] args = type.GetGenericArguments();
            groupingType = typeof(Grouping<,>).MakeGenericType(args[0], args[1]);
            groups = new Dictionary<Object, IGrouping>();
            this.propertyName = propertyName;
            int index = propertyName.IndexOf('.');
            if (index > -1)
            {
                this.propertyName = propertyName.Substring(index + 1);
            }
        }

        #region IResultTransformer Members

        /// <summary>
        /// Transforms the query result collection.
        /// </summary>
        /// <param name="collection">An <see cref="T:System.Collections.IList"/> of objects.</param>
        /// <returns>A transformed <see cref="T:System.Collections.IList"/> object.</returns>
        public IList TransformList(IList collection)
        {
            while (collection.Contains(null))
            {
                collection.Remove(null);
            }
            return collection;
        }

        /// <summary>
        /// Transforms each query result.
        /// </summary>
        /// <param name="tuple">An <see cref="T:System.Object"/> array of query result values.</param>
        /// <param name="aliases">A <see cref="T:System.String"/> array of column aliases.</param>
        /// <returns>An <see cref="T:System.Object"/> initialized with the values from the specified tuple.</returns>
        public object TransformTuple(object[] tuple, string[] aliases)
        {
            object value = tuple[0].GetType().GetProperty(propertyName).GetValue(tuple[0], null);
            String key = String.Format("{0}", value);

            if (groups.ContainsKey(key))
            {
                groups[key].Add(tuple[1]);
                return null;
            }
            else
            {
                var group = (IGrouping)Activator.CreateInstance(groupingType, value);
                group.Add(tuple[1]);
                groups[key] = group;
                return group;
            }
        }

        #endregion
    }

    /// <summary>
    /// Provides a method for adding individual objects to a collection of grouped objects.
    /// </summary>
    internal interface IGrouping
    {
        /// <summary>
        /// Adds an object to the current group.
        /// </summary>
        /// <param name="item">The <see cref="T:System.Object"/> to add.</param>
        void Add(object item);
    }

    /// <summary>
    /// Represents a collection of objects that have a common key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TElement">The type of the elements.</typeparam>
    internal class Grouping<TKey, TElement> : IGrouping<TKey, TElement>, IGrouping
    {
        private readonly TKey key;
        private readonly IList<TElement> list = new List<TElement>();

        public Grouping(TKey key)
        {
            this.key = key;
        }

        #region IGrouping Members

        public void Add(object item)
        {
            list.Add((TElement)item);
        }

        #endregion

        #region IGrouping<TKey,TElement> Members

        public TKey Key
        {
            get { return key; }
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return String.Format("Key = {0}", Key);
        }

        #endregion
    }
}
