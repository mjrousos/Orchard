using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using NHibernate;

namespace Orchard.Data {
    public interface ISessionLocator : IDependency {
        [Obsolete("Use ITransactionManager.GetSession() instead.")]
        ISession For(Type entityType);
    }
}
