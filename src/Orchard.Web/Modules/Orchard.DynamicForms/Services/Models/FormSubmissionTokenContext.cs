using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Specialized;
using Orchard.DynamicForms.Elements;

namespace Orchard.DynamicForms.Services.Models {
    public class FormSubmissionTokenContext {
        public Form Form { get; set; }
        public ModelStateDictionary ModelState { get; set; }
        public NameValueCollection PostedValues { get; set; }
        public ContentItem CreatedContent { get; set; }
    }
}
