using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;

namespace Orchard.Core.Navigation.Models {
    public class ShapeMenuItemPart : ContentPart {
        /// <summary>
        /// Maximum number of items to retrieve from db
        /// </summary>
        public string ShapeType {
            get { return this.Retrieve(x => x.ShapeType); }
            set { this.Store(x => x.ShapeType, value); }
        }
    }
}
