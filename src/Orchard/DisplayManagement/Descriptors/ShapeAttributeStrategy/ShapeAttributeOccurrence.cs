using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Reflection;
using Autofac.Core;
using Orchard.Environment.Extensions.Models;

namespace Orchard.DisplayManagement.Descriptors.ShapeAttributeStrategy {
    public class ShapeAttributeOccurrence {
        private readonly Func<Feature> _feature;
        public ShapeAttributeOccurrence(ShapeAttribute shapeAttribute, MethodInfo methodInfo, IComponentRegistration registration, Func<Feature> feature) {
            ShapeAttribute = shapeAttribute;
            MethodInfo = methodInfo;
            Registration = registration;
            _feature = feature;
        }
        public ShapeAttribute ShapeAttribute { get; private set; }
        public MethodInfo MethodInfo { get; private set; }
        public IComponentRegistration Registration { get; private set; }
        public Feature Feature { get { return _feature(); } }
    }
}
