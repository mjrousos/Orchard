using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Layouts.Framework.Elements {
    public class ElementRemovingContext {
        public ElementRemovingContext(Element element, IEnumerable<Element> elements, IEnumerable<Element> removedElements, IContent content) {
            Element = element;
            Elements = elements;
            RemovedElements = removedElements;
            Content = content;
        }
        public IContent Content { get; private set; }
        // All the other elements on the canvas.
        public IEnumerable<Element> Elements { get; set; }
        // All the other removed elements from the canvas (including the current element).
        public IEnumerable<Element> RemovedElements { get; set; }
        public Element Element { get; private set; }
    }
}
