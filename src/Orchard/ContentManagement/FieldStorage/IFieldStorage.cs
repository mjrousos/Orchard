using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.ContentManagement.FieldStorage {
    public interface IFieldStorage {
        T Get<T>(string name);
        void Set<T>(string name, T value);
    }
    public static class FieldStorageExtension{
        public static T Get<T>(this IFieldStorage storage) {
            return storage.Get<T>(null);
        }
        public static void Set<T>(this IFieldStorage storage, T value) {
            storage.Set(null, value);
}
