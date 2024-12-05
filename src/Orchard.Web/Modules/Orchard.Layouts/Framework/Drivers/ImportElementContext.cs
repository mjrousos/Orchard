using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Layouts.Framework.Elements;
using Orchard.Layouts.Models;

namespace Orchard.Layouts.Framework.Drivers {
    public class ImportElementContext {
        public ImportElementContext(Element element, ILayoutAspect layout, ElementDataDictionary exportableData, IContentImportSession session) {
            Element = element;
            Layout = layout;
            ExportableData = exportableData;
            Session = session;
        }
        public ILayoutAspect Layout { get; private set; }
        public Element Element { get; private set; }
        public ElementDataDictionary ExportableData { get; private set; }
        public IContentImportSession Session { get; private set; }
    }
}
