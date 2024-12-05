using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Web.Mvc;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Framework.Drivers {
    public class ElementEditorContext {
        public ElementEditorContext() {
            EditorResult = new EditorResult();
        }
        public Element Element { get; set; }
        public dynamic ShapeFactory { get; set; }
        public IValueProvider ValueProvider { get; set; }
        public IUpdateModel Updater { get; set; }
        public IContent Content { get; set; }
        public string Prefix { get; set; }
        public EditorResult EditorResult { get; set; }
        public string Session { get; set; }
        public ElementDataDictionary ElementData { get; set; }
    }
}
