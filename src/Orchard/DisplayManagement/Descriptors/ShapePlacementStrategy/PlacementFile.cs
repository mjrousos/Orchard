using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.DisplayManagement.Descriptors.ShapePlacementStrategy {
    public class PlacementFile : PlacementNode {
    }
    public class PlacementNode {
        public IEnumerable<PlacementNode> Nodes { get; set; }
    public class PlacementMatch : PlacementNode {
        public IDictionary<string, string> Terms { get; set; }
    public class PlacementShapeLocation : PlacementNode {
        public string ShapeType { get; set; }
        public string Location { get; set; }
}
