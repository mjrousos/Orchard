using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.ContentManagement.Utilities {
    public class ComputedField<T> {
        private Func<T> _getter;
        private Action<T> _setter;
        public T Value {
            get { return GetValue(); }
            set { SetValue(value); }
        }
        public void Getter(Func<T> loader) {
            _getter = loader;
        public void Setter(Action<T> setter) {
            _setter = setter;
        private T GetValue() {
            return _getter();
        private void SetValue(T value) {
            _setter(value);
    }
}
