using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System.Collections.Specialized;
using Orchard.DynamicForms.Elements;

namespace Orchard.DynamicForms.Services.Models {
    public class FormEventContext {
        public IContent Content { get; set; }
        public Form Form { get; set; }
        public NameValueCollection Values { get; set; }
        public IFormService FormService { get; set; }
        public IValueProvider ValueProvider { get; set; }
        public IUpdateModel Updater { get; set; }
    }
}
