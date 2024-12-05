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
using Orchard.ContentManagement.MetaData.Models;

namespace Orchard.ContentManagement.MetaData {
    public class ContentFieldInfo {
        public string FieldTypeName { get; set; }
        public Func<ContentPartFieldDefinition, IFieldStorage, ContentField> Factory { get; set; }
    }
}
