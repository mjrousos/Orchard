using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using Orchard.ContentManagement.Handlers;

namespace Orchard.Layouts.Framework.Drivers {
    public class ImportContentContextWrapper : IContentImportSession {
        private readonly ImportContentContext _context;
        public ImportContentContextWrapper(ImportContentContext context) {
            _context = context;
        }
        public ContentItem GetItemFromSession(string id) {
            return _context.GetItemFromSession(id);
    }
}
