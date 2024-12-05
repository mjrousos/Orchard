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
using Orchard.Data;

namespace Orchard.Tests.Data {
    public class StubLocator : ISessionLocator {
        private readonly ISession _session;
        public StubLocator(ISession session) {
            _session = session;
        }
        #region ISessionLocator Members
        public ISession For(Type entityType) {
            return _session;
        #endregion
    }
}
