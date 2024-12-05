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
    public class Weak<T> {
        private readonly WeakReference _target;
        public Weak(T target) {
            _target = new WeakReference(target);
        }
        public Weak(T target, bool trackResurrection) {
            _target = new WeakReference(target, trackResurrection);
        public T Target {
            get { return (T)_target.Target; }
            set { _target.Target = value; }
    }
}
