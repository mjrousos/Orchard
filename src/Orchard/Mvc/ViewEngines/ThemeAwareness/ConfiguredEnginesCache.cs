using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Concurrent;

namespace Orchard.Mvc.ViewEngines.ThemeAwareness {
    public interface IConfiguredEnginesCache : ISingletonDependency {
        IViewEngine BindBareEngines(Func<IViewEngine> factory);
        IViewEngine BindShallowEngines(string themeName, Func<IViewEngine> factory);
        IViewEngine BindDeepEngines(string themeName, Func<IViewEngine> factory);
    }
    public class ConfiguredEnginesCache : IConfiguredEnginesCache {
        IViewEngine _bare;
        readonly ConcurrentDictionary<string, IViewEngine> _shallow = new ConcurrentDictionary<string, IViewEngine>();
        readonly ConcurrentDictionary<string, IViewEngine> _deep = new ConcurrentDictionary<string, IViewEngine>();
        public ConfiguredEnginesCache() {
            _shallow = new ConcurrentDictionary<string, IViewEngine>();
        }
        public IViewEngine BindBareEngines(Func<IViewEngine> factory) {
            return _bare ?? (_bare = factory());
        public IViewEngine BindShallowEngines(string themeName, Func<IViewEngine> factory) {
            return _shallow.GetOrAdd(themeName, key => factory());
        public IViewEngine BindDeepEngines(string themeName, Func<IViewEngine> factory) {
            return _deep.GetOrAdd(themeName, key => factory());
}
