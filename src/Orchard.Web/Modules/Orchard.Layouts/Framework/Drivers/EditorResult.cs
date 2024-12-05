using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections;
using System.Collections.Generic;

namespace Orchard.Layouts.Framework.Drivers {
    public class EditorResult {
        public EditorResult() {
            Editors = new List<dynamic>();
        }
        public IList<dynamic> Editors { get; set; }
        public EditorResult Add(dynamic editor) {
            ((IList)Editors).Add(editor);
            return this;
    }
}
