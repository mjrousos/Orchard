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
using Orchard.Environment.Extensions.Models;

namespace Orchard.DisplayManagement.Descriptors {
    public class ShapeAlteration {
        private readonly IList<Action<ShapeDescriptor>> _configurations;
        public ShapeAlteration(string shapeType, Feature feature, IList<Action<ShapeDescriptor>> configurations) {
            _configurations = configurations;
            ShapeType = shapeType;
            Feature = feature;
        }
        public string ShapeType { get; private set; }
        public Feature Feature { get; private set; }
        public void Alter(ShapeDescriptor descriptor) {
            foreach (var configuration in _configurations) {
                configuration(descriptor);
            }
    }
}
