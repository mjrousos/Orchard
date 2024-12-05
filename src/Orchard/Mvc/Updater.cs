using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Mvc {
   
    public class Updater : IUpdateModel {
        private readonly IUpdateModel _thunk;
        public Updater(IUpdateModel thunk) : this(thunk, x => x) {
        }
        public Updater(IUpdateModel thunk, Func<string, string> prefix) {
            _thunk = thunk;
            Prefix = prefix;
        public Func<string, string> Prefix { get; set; }
        public bool TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties) where TModel : class {
            return _thunk.TryUpdateModel(model, Prefix(prefix), includeProperties, excludeProperties);
        public void AddModelError(string key, LocalizedString errorMessage) {
            _thunk.AddModelError(Prefix(key), errorMessage);
    }
}
