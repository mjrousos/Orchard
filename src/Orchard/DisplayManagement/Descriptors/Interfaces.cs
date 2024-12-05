using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using Orchard.Caching;
using Orchard.Events;

namespace Orchard.DisplayManagement.Descriptors {
    public interface IShapeTableManager : ISingletonDependency {
        ShapeTable GetShapeTable(string themeName);
    }
    public interface IShapeTableProvider : IDependency {
        void Discover(ShapeTableBuilder builder);
    public interface IShapeTableEventHandler : IEventHandler {
        void ShapeTableCreated(ShapeTable shapeTable);
}
