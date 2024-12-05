using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Indexing.Settings {
    public class TypeIndexing {
        public string Indexes { get; set; }
        
        public string[] List {
            get { return String.IsNullOrEmpty(Indexes) ? new string[0] : Indexes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries); }
            set { Indexes = String.Join(",", value); }
        }
    }
}
