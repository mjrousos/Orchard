using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Orchard.DynamicForms.Services.Models {
    public abstract class BindingContext {
        protected readonly IList<BindingDescriptor> _bindings = new List<BindingDescriptor>();
        protected BindingContext(string contextName) {
            ContextName = contextName;
        }
        public string ContextName { get; set; }
        public IEnumerable<BindingDescriptor> Bindings {
            get { return _bindings; }
    }
    public class BindingContext<T> : BindingContext {
        public BindingContext() : base(typeof(T).Name) {
        public BindingContext<T> Binding(string name, Action<ContentItem, T, string> setter) {
            _bindings.Add(new BindingDescriptor<T> {
                Name = name,
                Setter = setter
            });
            return this;
}
