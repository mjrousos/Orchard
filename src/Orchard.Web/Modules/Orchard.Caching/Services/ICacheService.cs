using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Caching.Services {
    public interface ICacheService : IDependency {
        object GetObject<T>(string key);
        void Put<T>(string key, T value);
        void Put<T>(string key, T value, TimeSpan validFor);
        void Remove(string key);
        void Clear();
    }
}
