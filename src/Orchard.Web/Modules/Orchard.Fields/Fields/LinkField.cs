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
    public class LinkField : ContentField {
        public string Value {
            get { return Storage.Get<string>(); }
            set { Storage.Set(value ?? String.Empty); }
        }
        public string Text {
            get { return Storage.Get<string>("Text"); }
            set { Storage.Set("Text", value ?? String.Empty); }
        public string Target {
            get { return Storage.Get<string>("Target"); }
            set { Storage.Set("Target", value ?? String.Empty); }
    }
}
