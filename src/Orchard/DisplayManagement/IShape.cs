using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.DisplayManagement.Shapes;

namespace Orchard.DisplayManagement {
    /// <summary>
    /// Interface present on dynamic shapes. 
    /// May be used to access attributes in a strongly typed fashion.
    /// Note: Anything on this interface is a reserved word for the purpose of shape properties
    /// </summary>    
    public interface IShape {
        ShapeMetadata Metadata { get; set; }
    }
}
