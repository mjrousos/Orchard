using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Caching {
    public interface IAcquireContext {
        Action<IVolatileToken> Monitor { get; }
    }
    public class AcquireContext<TKey> : IAcquireContext {
        public AcquireContext(TKey key, Action<IVolatileToken> monitor) {
            Key = key;
            Monitor = monitor;
        }
        public TKey Key { get; private set; }
        public Action<IVolatileToken> Monitor { get; private set; }
    /// <summary>
    /// Simple implementation of "IAcquireContext" given a lamdba
    /// </summary>
    public class SimpleAcquireContext : IAcquireContext {
        private readonly Action<IVolatileToken> _monitor;
        public SimpleAcquireContext(Action<IVolatileToken> monitor) {
            _monitor = monitor;
        public Action<IVolatileToken> Monitor {
            get { return _monitor; }
}
