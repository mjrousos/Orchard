using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.Events;
using Orchard.Layouts.Framework.Display;
using Orchard.Layouts.Framework.Drivers;
using Orchard.Layouts.Framework.Elements;

namespace Orchard.Layouts.Services {
    public interface IElementEventHandler : IEventHandler {
        void Creating(ElementCreatingContext context);
        void Created(ElementCreatedContext context);
        void CreatingDisplay(ElementCreatingDisplayShapeContext context);
        void Displaying(ElementDisplayingContext context);
        void Displayed(ElementDisplayedContext context);
        void BuildEditor(ElementEditorContext context);
        void UpdateEditor(ElementEditorContext context);
        void LayoutSaving(ElementSavingContext context);
        void Removing(ElementRemovingContext context);
        void Exporting(ExportElementContext context);
        void Exported(ExportElementContext context);
        void Importing(ImportElementContext context);
        void Imported(ImportElementContext context);
        void ImportCompleted(ImportElementContext context);
    }
}
