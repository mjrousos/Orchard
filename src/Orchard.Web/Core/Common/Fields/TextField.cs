using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage;

namespace Orchard.Core.Common.Fields {
    public class TextField : ContentField {
        public string Value {
            get { return Storage.Get<string>(); }
            set { Storage.Set(value); }
        }
    }
}
