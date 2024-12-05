using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.DisplayManagement {
    public class ShapeAttribute : Attribute {
        public ShapeAttribute() { }
        public ShapeAttribute(string shapeType) { this.ShapeType = shapeType; }
        
        public string ShapeType { get; private set; }
    }
}
