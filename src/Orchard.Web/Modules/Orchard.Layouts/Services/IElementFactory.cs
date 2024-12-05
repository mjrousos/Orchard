using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Services {
    public interface IElementFactory : IDependency {
        Element Activate(Type elementType, Action<Element> initialize = null);
        T Activate<T>(Action<T> initialize = null) where T:Element;
        Element Activate(ElementDescriptor descriptor, Action<Element> initialize = null);
        T Activate<T>(ElementDescriptor descriptor, Action<T> initialize = null) where T:Element;
    }
}
