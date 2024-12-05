using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Layouts.Services;

namespace Orchard.Layouts.Helpers {
    public static class ObjectStoreHelper {
        public static T Get<T>(this IObjectStore store, string key, Func<T> defaultValue = null) {
            var value = store.Get(key);
            return (T) (value ?? (defaultValue != null ? defaultValue() : default(T)));
        }
        public static void Set<T>(this IObjectStore store, string key, T value) {
            store.Set(key, value);
    }
}
