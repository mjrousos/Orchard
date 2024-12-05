using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Autofac;
using Orchard.Data;
using Orchard.UI.Notify;

namespace Orchard.Tokens.Tests {
    public class StubOrchardServices : IOrchardServices {
        private readonly ILifetimeScope _lifetimeScope;
        public StubOrchardServices() { }
        public StubOrchardServices(ILifetimeScope lifetimeScope) {
            _lifetimeScope = lifetimeScope;
        }
        public IContentManager ContentManager {
            get { throw new NotImplementedException(); }
        public ITransactionManager TransactionManager {
        public IAuthorizer Authorizer {
        public INotifier Notifier {
        public dynamic New {
        private WorkContext _workContext;
        public WorkContext WorkContext {
            get {
                if (_workContext == null) {
                    _workContext = new StubWorkContextAccessor(_lifetimeScope).GetContext();
                }
                return _workContext;
            }
    }
}
