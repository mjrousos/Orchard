using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Layouts.Framework.Drivers {
    public class ImportContentSessionWrapper : IContentImportSession {
        private readonly ImportContentSession _session;
        public ImportContentSessionWrapper(ImportContentSession session) {
            _session = session;
        }
        public ContentItem GetItemFromSession(string id) {
            return _session.Get(id);
    }
}
