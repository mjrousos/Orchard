using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Layouts.Framework.Elements;
using Orchard.Layouts.Helpers;

namespace Orchard.Layouts.Elements {
    public abstract class ContentElement : Element {
        public override string Category {
            get { return "Content"; }
        }
        public virtual string Content {
            get { return this.Retrieve(x => x.Content); }
            set { this.Store(x => x.Content, value); }
    }
}
