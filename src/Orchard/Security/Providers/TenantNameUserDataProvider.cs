using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Configuration;

namespace Orchard.Security.Providers {
    public class TenantNameUserDataProvider : BaseUserDataProvider {
        private readonly ShellSettings _settings;
        public TenantNameUserDataProvider(
            ShellSettings settings) : base(false) {
            _settings = settings;
        }
        public override string Key {
            get { return "TenantName"; }
        protected override string Value(IUser user) {
            return _settings.Name;
    }
}
