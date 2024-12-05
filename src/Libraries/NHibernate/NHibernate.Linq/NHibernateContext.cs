using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NHibernate.Metadata;

namespace NHibernate.Linq
{
    /// <summary>
    /// Wraps an <see cref="T:NHibernate.ISession"/> object to provide base functionality
    /// for custom, database-specific context classes.
    /// </summary>
    public abstract class NHibernateContext : IDisposable, ICloneable
    {
        /// <summary>
        /// Provides access to database provider specific methods.
        /// </summary>
        public readonly IDbMethods Methods;
        private ISession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateContext"/> class.
        /// </summary>
        public NHibernateContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:NHibernate.Linq.NHibernateContext"/> class.
        /// </summary>
        /// <param name="session">An initialized <see cref="T:NHibernate.ISession"/> object.</param>
        public NHibernateContext(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Gets a reference to the <see cref="T:NHibernate.ISession"/> associated with this object.
        /// </summary>
        public virtual ISession Session
        {
            get
            {
                if (session == null)
                {
                    session = ProvideSession();
                }
                return session;
            }
        }

        /// <summary>
        /// Allows for empty construction but provides an interface for derived classes to provide a session object.
        /// </summary>
        /// <returns>The Required <see cref="T:NHibernate.ISession"/> object.</returns>
        protected virtual ISession ProvideSession()
        {
            throw new NotImplementedException("If NHibernateContext is constructed with the empty constructor, inheritor is required to override ProvideSession to supply Session.");
        }

        #region ICloneable Members
        public virtual object Clone()
        {
            if (session == null)
                throw new ArgumentNullException("session");
            return Activator.CreateInstance(GetType(), session);
        }
        #endregion

        #region IDisposable Members
        public virtual void Dispose()
        {
            if (session != null)
            {
                session.Dispose();
                session = null;
            }
        }
        #endregion

        private List<object> _updateCache = null;
        private List<object> UpdateCache
        {
            get
            {
                if (_updateCache == null)
                    _updateCache = new List<object>();
                return _updateCache;
            }
        }

        public virtual void AddToCollection(object targetResource, string propertyName, object resourceToBeAdded)
        {
            IClassMetadata metadata = session.SessionFactory.GetClassMetadata(targetResource.GetType().FullName);
            if (metadata == null)
                throw new InvalidOperationException("Type not recognized as a valid type for this Context");

            object collection = metadata.GetPropertyValue(targetResource, propertyName);
            if (collection is IList)
            {
                ((IList)collection).Add(resourceToBeAdded);
            }
            else
            {
                MethodInfo addMethod = collection.GetType().GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);
                if (addMethod == null)
                    throw new InvalidOperationException($"Could not determine the collection type of the {propertyName} property.");
                addMethod.Invoke(collection, new object[] { resourceToBeAdded });
            }
        }

        public virtual void ClearChanges()
        {
            UpdateCache.Clear();
            session.Clear();
        }

        public virtual object CreateResource(string containerName, string fullTypeName)
        {
            IClassMetadata metadata = session.SessionFactory.GetClassMetadata(fullTypeName);
            object newResource = metadata.Instantiate(null);
            UpdateCache.Add(newResource);
            return newResource;
        }

        public virtual void DeleteResource(object targetResource)
        {
            if (UpdateCache.Contains(targetResource))
            {
                UpdateCache.Remove(targetResource);
                session.Save(targetResource);
            }
            if (session.Contains(targetResource))
                session.Delete(targetResource);
        }

        public virtual object GetResource(IQueryable query, string fullTypeName)
        {
            IEnumerable results = (IEnumerable)query;
            object returnValue = null;
            foreach (object result in results)
            {
                if (returnValue != null) break;
                returnValue = result;
            }
            if (fullTypeName != null)
            {
                if (fullTypeName != returnValue?.GetType().FullName)
                    throw new InvalidOperationException("Incorrect Type Returned");
            }
            return returnValue;
        }

        public virtual object GetValue(object targetResource, string propertyName)
        {
            IClassMetadata metadata = session.SessionFactory.GetClassMetadata(targetResource.GetType().FullName);
            if (metadata.IdentifierPropertyName == propertyName)
                return metadata.GetIdentifier(targetResource);
            else
                return metadata.GetPropertyValue(targetResource, propertyName);
        }

        public virtual void RemoveFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
        {
            IClassMetadata metadata = session.SessionFactory.GetClassMetadata(targetResource.GetType().FullName);
            object collection = metadata.GetPropertyValue(targetResource, propertyName);
            if (collection is IList)
            {
                ((IList)collection).Remove(resourceToBeRemoved);
            }
            else
            {
                MethodInfo removeMethod = collection.GetType().GetMethod("Remove", BindingFlags.Public | BindingFlags.Instance);
                if (removeMethod == null)
                    throw new InvalidOperationException($"Could not determine the collection type of the {propertyName} property.");
                removeMethod.Invoke(collection, new object[] { resourceToBeRemoved });
            }
        }

        public virtual void SaveChanges()
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                try
                {
                    if (_updateCache != null)
                    {
                        _updateCache.ForEach(o => session.SaveOrUpdate(o));
                        _updateCache.Clear();
                    }
                    session.Flush();
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new InvalidOperationException("Failed to save changes.", ex);
                }
            }
        }

        public virtual void SetValue(object targetResource, string propertyName, object propertyValue)
        {
            IClassMetadata metadata = session.SessionFactory.GetClassMetadata(targetResource.GetType().FullName);
            if (metadata.IdentifierPropertyName == propertyName)
                metadata.SetIdentifier(targetResource, propertyValue);
            else
                metadata.SetPropertyValue(targetResource, propertyName, propertyValue);
        }

        public virtual void ApplyExpansions(IQueryable queryable, ICollection<string> expandPaths)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));
            if (!(queryable is INHibernateQueryable nHibQuery))
                throw new InvalidOperationException("Expansion only supported on INHibernateQueryable queries");
            if (expandPaths?.Count == 0)
                throw new ArgumentException("Expansion Paths cannot be empty", nameof(expandPaths));

            foreach (string path in expandPaths)
            {
                nHibQuery.QueryOptions.AddExpansion(path);
            }
        }
    }
}
