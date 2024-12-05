using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;

namespace Orchard.Data.Bags {
    public class SettingsValueProvider : IValueProvider {
        private readonly dynamic _state;
        public SettingsValueProvider(dynamic state) {
            _state = state;
        }
        
        public bool ContainsPrefix(string prefix) {
            return true;
        public ValueProviderResult GetValue(string key) {
            return _state[key];
    }
}
