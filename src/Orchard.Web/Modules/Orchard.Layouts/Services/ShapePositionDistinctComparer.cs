using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using Orchard.Layouts.Models;

namespace Orchard.Layouts.Services {
    public class ShapePositionDistinctComparer : IEqualityComparer<ShapePosition> {
        public bool Equals(ShapePosition x, ShapePosition y) {
            return String.Equals(x.Name, y.Name);
        }
        public int GetHashCode(ShapePosition obj) {
            return (obj.Name ?? "").GetHashCode();
    }
}
