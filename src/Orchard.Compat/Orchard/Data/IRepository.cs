using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Orchard.Data
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Copy(T source, T target);
        T Get(int id);
        T Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> Table { get; }
    }

    public interface IContentDefinitionStore
    {
        string LoadContentDefinition();
        void SaveContentDefinition(string contentDefinition);
    }

    public interface ITransactionManager
    {
        void Demand();
        void RequireNew();
        void RequireNew(Action action);
        void Cancel();
    }

    public interface ISession
    {
        void Create(object entity);
        void Update(object entity);
        void Delete(object entity);
        T Get<T>(int id) where T : class;
        void Flush();
        void Clear();
    }

    public interface ISessionLocator
    {
        ISession For(Type entityType);
    }
}
