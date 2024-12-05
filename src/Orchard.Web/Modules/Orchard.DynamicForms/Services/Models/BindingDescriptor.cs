using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.DynamicForms.Services.Models {
    public abstract class BindingDescriptor {
        public string Name { get; set; }
        public Delegate Setter { get; set; }
    }
    public class BindingDescriptor<T> : BindingDescriptor {
}
