using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Layouts.Framework.Elements {
    public class ElementSavingContext : LayoutSavingContext {
        public ElementSavingContext(Element element, LayoutSavingContext stub) {
            Element = element;
            Content = stub.Content;
            Updater = stub.Updater;
            Elements = stub.Elements;
        }
        public Element Element { get; private set; }
    }
}
