using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.ContentManagement.FieldStorage;

namespace Orchard.Fields.Fields {
    public class BooleanField : ContentField {
        public Boolean? Value {
            get { return Storage.Get<Boolean?>(); }
            set { Storage.Set(value); }
        }
    }
}
