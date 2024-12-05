using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Layouts.Models {
    [Serializable]
    public class ElementSessionState {
        public string TypeName { get; set; }
        public string ElementData { get; set; }
        public string ElementEditorData { get; set; }
        public int? ContentId { get; set; }
        public string ContentType { get; set; }
    }
}
