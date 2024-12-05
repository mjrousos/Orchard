using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections;
using NHibernate;
using NHibernate.SqlCommand;
using NHibernate.Type;

namespace Orchard.Data {
    /// <summary>
    /// Abstract implementation of a per-session NHibernate session interceptor.
    /// </summary>
    public abstract class AbstractSessionInterceptor : ISessionInterceptor {
        /// <summary>
        /// Called just before an object is initialized
        /// </summary>
        /// <param name="entity"/><param name="id"/><param name="propertyNames"/><param name="state"/><param name="types"/>
        /// <remarks>
        /// The interceptor may change the <c>state</c>, which will be propagated to the persistent
        ///             object. Note that when this method is called, <c>entity</c> will be an empty
        ///             uninitialized instance of the class.
        /// </remarks>
        /// <returns>
        /// <see langword="true"/> if the user modified the <c>state</c> in any way
        /// </returns>
        public virtual bool OnLoad(object entity, object id, object[] state, string[] propertyNames, IType[] types) {
            return false;
        }
        /// Called when an object is detected to be dirty, during a flush.
        /// <param name="currentState"/><param name="entity"/><param name="id"/><param name="previousState"/><param name="propertyNames"/><param name="types"/>
        /// The interceptor may modify the detected <c>currentState</c>, which will be propagated to
        ///             both the database and the persistent object. Note that all flushes end in an actual
        ///             synchronization with the database, in which as the new <c>currentState</c> will be propagated
        ///             to the object, but not necessarily (immediately) to the database. It is strongly recommended
        ///             that the interceptor <b>not</b> modify the <c>previousState</c>.
        /// <see langword="true"/> if the user modified the <c>currentState</c> in any way
        public virtual bool OnFlushDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types) {
        /// Called before an object is saved
        /// The interceptor may modify the <c>state</c>, which will be used for the SQL <c>INSERT</c>
        ///             and propagated to the persistent object
        public virtual bool OnSave(object entity, object id, object[] state, string[] propertyNames, IType[] types) {
        /// Called before an object is deleted
        /// It is not recommended that the interceptor modify the <c>state</c>.
        public virtual void OnDelete(object entity, object id, object[] state, string[] propertyNames, IType[] types) {
        /// Called before a collection is (re)created.
        public virtual void OnCollectionRecreate(object collection, object key) {
        /// Called before a collection is deleted.
        public virtual void OnCollectionRemove(object collection, object key) {
        /// Called before a collection is updated.
        public virtual void OnCollectionUpdate(object collection, object key) {
        /// Called before a flush
        /// <param name="entities">The entities</param>
        public virtual void PreFlush(ICollection entities) {
        /// Called after a flush that actually ends in execution of the SQL statements required to
        ///             synchronize in-memory state with the database.
        /// <param name="entities">The entitites</param>
        public virtual void PostFlush(ICollection entities) {
        /// Called when a transient entity is passed to <c>SaveOrUpdate</c>.
        /// The return value determines if the object is saved
        /// <list>
        /// <item>
        /// <see langword="true"/> - the entity is passed to <c>Save()</c>, resulting in an <c>INSERT</c>
        /// </item>
        /// <see langword="false"/> - the entity is passed to <c>Update()</c>, resulting in an <c>UPDATE</c>
        /// <see langword="null"/> - Hibernate uses the <c>unsaved-value</c> mapping to determine if the object is unsaved
        /// </list>
        /// <param name="entity">A transient entity</param>
        /// Boolean or <see langword="null"/> to choose default behaviour
        public virtual bool? IsTransient(object entity) {
            return null;
        /// Called from <c>Flush()</c>. The return value determines whether the entity is updated
        /// an array of property indicies - the entity is dirty
        /// an empty array - the entity is not dirty
        /// <see langword="null"/> - use Hibernate's default dirty-checking algorithm
        /// <param name="entity">A persistent entity</param><param name="currentState"/><param name="id"/><param name="previousState"/><param name="propertyNames"/><param name="types"/>
        /// An array of dirty property indicies or <see langword="null"/> to choose default behavior
        public virtual int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames, IType[] types) {
        /// Instantiate the entity class. Return <see langword="null"/> to indicate that Hibernate should use the default
        ///             constructor of the class
        /// <param name="entityName">the name of the entity </param><param name="entityMode">The type of entity instance to be returned. </param><param name="id">the identifier of the new instance </param>
        /// An instance of the class, or <see langword="null"/> to choose default behaviour
        /// The identifier property of the returned instance
        ///             should be initialized with the given identifier.
        public virtual object Instantiate(string entityName, object id) {
        /// Get the entity name for a persistent or transient instance
        /// <param name="entity">an entity instance </param>
        /// the name of the entity 
        public virtual string GetEntityName(object entity) {
        /// Get a fully loaded entity instance that is cached externally
        /// <param name="entityName">the name of the entity </param><param name="id">the instance identifier </param>
        /// a fully initialized entity 
        public virtual object GetEntity(string entityName, object id)
        {
        /// Called when a NHibernate transaction is begun via the NHibernate <see cref="T:NHibernate.ITransaction"/>
        ///             API. Will not be called if transactions are being controlled via some other mechanism.
        public virtual void AfterTransactionBegin(ITransaction tx) {
        /// Called before a transaction is committed (but not before rollback).
        public virtual void BeforeTransactionCompletion(ITransaction tx) {
        /// Called after a transaction is committed or rolled back.
        public virtual void AfterTransactionCompletion(ITransaction tx) {
        /// Called when sql string is being prepared. 
        /// <param name="sql">sql to be prepared </param>
        /// original or modified sql 
        public virtual SqlString OnPrepareStatement(SqlString sql) {
            return sql;
        /// Called when a session-scoped (and <b>only</b> session scoped) interceptor is attached
        ///             to a session
        /// session-scoped-interceptor is an instance of the interceptor used only for one session.
        ///             The use of singleton-interceptor may cause problems in multi-thread scenario. 
        /// <seealso cref="M:NHibernate.ISessionFactory.OpenSession(NHibernate.IInterceptor)"/><seealso cref="M:NHibernate.ISessionFactory.OpenSession(System.Data.IDbConnection,NHibernate.IInterceptor)"/>
        public virtual void SetSession(ISession session) {
    }
}
