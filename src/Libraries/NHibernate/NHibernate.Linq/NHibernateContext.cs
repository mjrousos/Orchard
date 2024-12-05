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
using System.Collections.Generic;
using System.Data.Services;
using System.Linq;
using System.Reflection;
using NHibernate.Metadata;

namespace NHibernate.Linq
{
	/// <summary>
	/// Wraps an <see cref="T:NHibernate.ISession"/> object to provide base functionality
	/// for custom, database-specific context classes.
	/// </summary>
	public abstract class NHibernateContext : IDisposable, ICloneable, IUpdatable, IExpandProvider
	{
		/// <summary>
		/// Provides access to database provider specific methods.
		/// </summary>
		public readonly IDbMethods Methods;
		private ISession session;
		/// Initializes a new instance of the <see cref="NHibernateContext"/> class.
		public NHibernateContext()
		{
		}
		/// Initializes a new instance of the <see cref="T:NHibernate.Linq.NHibernateContext"/> class.
		/// <param name="session">An initialized <see cref="T:NHibernate.ISession"/> object.</param>
		public NHibernateContext(ISession session)
			this.session = session;
		/// Gets a reference to the <see cref="T:NHibernate.ISession"/> associated with this object.
		public virtual ISession Session
			get
			{
				if (session == null)
				{
					// Attempt to get the Session
					session = ProvideSession();
				}
				return session;
			}
		/// Allows for empty construction but provides an interface for an interface to have the derived 
		/// classes provide a session object late in the cycle. 
		/// <returns>The Required <see cref="T:NHibernate.ISession"/> object.</returns>
		protected virtual ISession ProvideSession()
			// Should not be called as supplying the session in the constructor
			throw new NotImplementedException("If NHibernateContext is constructed with the empty constructor, inheritor is required to override ProvideSession to supply Session.");
		#region ICloneable Members
		/// Creates a new object that is a copy of the current instance.
		/// <returns></returns>
		public virtual object Clone()
			if (session == null)
				throw new ArgumentNullException("session");
			return Activator.CreateInstance(GetType(), session);
		#endregion
		#region IDisposable Members
		/// Disposes the wrapped <see cref="T:NHibernate.ISession"/> object.
		public virtual void Dispose()
			if (session != null)
				session.Dispose();
				session = null;
		#region IUpdatable Members
		List<object> _updateCache = null;
		/// Gets the update cache.
		/// <value>The update cache.</value>
		List<object> UpdateCache
				if (_updateCache == null)
					_updateCache = new List<object>();
				return _updateCache;
		/// Adds the reference to collection.
		/// <param name="targetResource">The target resource.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="resourceToBeAdded">The resource to be added.</param>
		void IUpdatable.AddReferenceToCollection(object targetResource, string propertyName, object resourceToBeAdded)
			IClassMetadata metadata = session.SessionFactory.GetClassMetadata(targetResource.GetType().FullName);
			if (metadata == null)
				throw new DataServiceException("Type not recognized as a valid type for this Context");
			// Get the property to use to add the resource to
			object collection = metadata.GetPropertyValue(targetResource, propertyName);
			// Try with IList implementation first (its faster)
			if (collection is IList)
				((IList)collection).Add(resourceToBeAdded);
			else // Try with Reflection's Add()
				MethodInfo addMethod = collection.GetType().GetMethod("Add", BindingFlags.Public | BindingFlags.Instance);
				if (addMethod == null)
					throw new DataServiceException(string.Concat("Could not determine the collection type of the ", propertyName, " property."));
				addMethod.Invoke(collection, new object[] { resourceToBeAdded });
		/// Clears the changes.
		void IUpdatable.ClearChanges()
			UpdateCache.Clear();
			session.Clear();
		/// Creates the resource.
		/// <param name="containerName">Name of the container.</param>
		/// <param name="fullTypeName">Full name of the type.</param>
		/// <returns>Newly created Resource</returns>
		object IUpdatable.CreateResource(string containerName, string fullTypeName)
			// Get the metadata
			IClassMetadata metadata = session.SessionFactory.GetClassMetadata(fullTypeName);
			object newResource = metadata.Instantiate(null);
			// We can't save it to the session as it may not be valid yet
			// This happens if the key is a non-initancable key (e.g. Northwind.Customers)
			// So we save them to a local cache.  Only when SaveAll happens will be push them to the Session
			UpdateCache.Add(newResource);
			// Returns the new resource 
			return newResource;
		/// Deletes the resource.
		void IUpdatable.DeleteResource(object targetResource)
			// Push it to the Session to support deletion
			if (UpdateCache.Contains(targetResource))
				UpdateCache.Remove(targetResource);
				session.Save(targetResource);
			// Mark it as deleted
			if (session.Contains(targetResource)) session.Delete(targetResource);
		/// Gets the resource.
		/// <param name="query">The query.</param>
		object IUpdatable.GetResource(System.Linq.IQueryable query, string fullTypeName)
			// Get the first result
			IEnumerable results = (IEnumerable)query;
			object returnValue = null;
			foreach (object result in results)
				if (returnValue != null) break;
				returnValue = result;
			// Check the Typename if needed
			if (fullTypeName != null)
				if (fullTypeName != returnValue.GetType().FullName)
					throw new DataServiceException("Incorrect Type Returned");
			// Return the resource
			return returnValue;
		/// Gets the value.
		object IUpdatable.GetValue(object targetResource, string propertyName)
			// If 
			if (metadata.IdentifierPropertyName == propertyName)
				return metadata.GetIdentifier(targetResource);
			else
				return metadata.GetPropertyValue(targetResource, propertyName);
		/// Removes the reference from collection.
		/// <param name="resourceToBeRemoved">The resource to be removed.</param>
		void IUpdatable.RemoveReferenceFromCollection(object targetResource, string propertyName, object resourceToBeRemoved)
			// Get the property to use to remove the resource to
				((IList)collection).Remove(resourceToBeRemoved);
				MethodInfo removeMethod = collection.GetType().GetMethod("Remove", BindingFlags.Public | BindingFlags.Instance);
				if (removeMethod == null)
				removeMethod.Invoke(collection, new object[] { resourceToBeRemoved });
		/// Replaces the resource.
		/// <param name="resource">The resource to reset.</param>
		object IUpdatable.ResetResource(object resource)
			IUpdatable update = this;
			// Create a new resource of the same type
			// but only make a local copy as we're only using it to set the default fields
			IClassMetadata metadata = session.SessionFactory.GetClassMetadata(resource.GetType().ToString());
			object tempCopy = metadata.Instantiate(null);
			// Copy the default non-keys
			foreach (string propName in metadata.PropertyNames)
				object value = metadata.GetPropertyValue(tempCopy, propName);
				update.SetValue(resource, propName, value);
			//Return the new resource
			return resource;
		/// Resolves the resource.
		/// <param name="resource">The resource.</param>
		object IUpdatable.ResolveResource(object resource)
			// Resolve Resource always just returns the resource
			// since we not using tokens or cookies to the actual objects
			// the resources are always the actual CLR objects
		/// Saves the changes.
		void IUpdatable.SaveChanges()
			// All saves must be all or nothing.
			using (ITransaction tx = Session.BeginTransaction())
				try
					// If we have anything in the object cache,
					// add it to session.
					if (_updateCache != null)
					{
						_updateCache.ForEach(o => session.SaveOrUpdate(o));
						_updateCache.Clear();
					}
					// Push the changes to the database
					session.Flush();
					// Commit the Transaction
					tx.Commit();
				catch (Exception ex)
					// If anythign goes wrong, it all gets rolled back
					tx.Rollback();
					// Send the error back to the user
					throw new DataServiceException("Failed to save changes.  See inner exception for details", ex);
		/// Sets the reference.
		/// <param name="propertyValue">The property value.</param>
		void IUpdatable.SetReference(object targetResource, string propertyName, object propertyValue)
			((IUpdatable)this).SetValue(targetResource, propertyName, propertyValue);
		/// Sets the value.
		void IUpdatable.SetValue(object targetResource, string propertyName, object propertyValue)
			// See if its the Key property first
				metadata.SetIdentifier(targetResource, propertyValue);
			else // Else set the property
				metadata.SetPropertyValue(targetResource, propertyName, propertyValue);
		#region IExpandProvider Members
		IEnumerable IExpandProvider.ApplyExpansions(IQueryable queryable, ICollection<ExpandSegmentCollection> expandPaths)
			if (queryable == null) throw new DataServiceException("Query cannot be null");
			INHibernateQueryable nHibQuery = queryable as INHibernateQueryable;
			if (nHibQuery == null) throw new DataServiceException("Expansion only supported on INHibernateQueryable queries");
			if (expandPaths.Count == 0) throw new DataServiceException("Expansion Paths cannot be null");
			foreach (ExpandSegmentCollection coll in expandPaths)
				foreach (ExpandSegment seg in coll)
					if (seg.HasFilter)
						throw new DataServiceException("NHibernate does not support Expansions with Filters");
					else
						nHibQuery.QueryOptions.AddExpansion(seg.Name);
			return nHibQuery as IEnumerable;
	}
}
