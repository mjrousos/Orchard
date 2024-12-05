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
    public class ElementFactory : IElementFactory {
        private readonly IElementEventHandler _elementEventHandler;
        private readonly IWorkContextAccessor _workContextAccessor;
        public ElementFactory(IElementEventHandler elementEventHandler, IWorkContextAccessor workContextAccessor) {
            _elementEventHandler = elementEventHandler;
            _workContextAccessor = workContextAccessor;
            T = NullLocalizer.Instance;
        }
        public Localizer T { get; set; }
        public Element Activate(Type elementType, Action<Element> initialize = null) {
            var workContext = _workContextAccessor.GetContext();
            var element = (Element)workContext.Resolve(elementType);
            if (initialize != null)
                initialize(element);
            return element;
        public T Activate<T>(Action<T> initialize = null) where T : Element {
            var element = workContext.Resolve<T>();
        public T Activate<T>(ElementDescriptor descriptor, Action<T> initialize = null) where T : Element {
            var initializeWrapper = initialize != null ? e => initialize((T)e) : default(Action<Element>);
            return (T)Activate(descriptor, initializeWrapper);
        public Element Activate(ElementDescriptor descriptor, Action<Element> initialize = null) {
            _elementEventHandler.Creating(new ElementCreatingContext {
                ElementDescriptor = descriptor
            });
            var element = Activate(descriptor.ElementType);
            element.Descriptor = descriptor;
            element.T = T;
            element.Data = new ElementDataDictionary();
            element.ExportableData = new ElementDataDictionary();
            _elementEventHandler.Created(new ElementCreatedContext {
                Element = element,
    }
}
