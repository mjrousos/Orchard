using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchard.Tests.Modules.Stubs {
    public class ShapeDisplayStub : IShapeDisplay {
        public int Calls { get; set; }
        public string Display(Orchard.DisplayManagement.Shapes.Shape shape) {
            Calls++;
            return "";
        }
        public string Display(object shape) {
        public IEnumerable<string> Display(IEnumerable<object> shapes) {
            foreach (var shape in shapes) {
                yield return Display(shape);
            }
    }
}
