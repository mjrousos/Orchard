using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.DisplayManagement.Descriptors;

namespace Orchard.ContentManagement.Handlers {
    public class UpdateEditorContext : BuildEditorContext {
        public UpdateEditorContext(IShape model, IContent content, IUpdateModel updater, string groupInfoId, IShapeFactory shapeFactory, ShapeTable shapeTable, string path)
            : base(model, content, groupInfoId, shapeFactory) {
            
            ShapeTable = shapeTable;
            Updater = updater;
            Path = path;
        }
        public IUpdateModel Updater { get; private set; }
        public ShapeTable ShapeTable { get; private set; }
        public string Path { get; private set; }
    }
}
