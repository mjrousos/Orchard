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

namespace Orchard.DisplayManagement.Implementation {
    public interface IShapeFactoryEvents : IDependency {
        void Creating(ShapeCreatingContext context);
        void Created(ShapeCreatedContext context);
    }
    public class ShapeCreatingContext {
        public IShapeFactory ShapeFactory { get; set; }
        public dynamic New { get; set; }
        public string ShapeType { get; set; }
        public Func<dynamic> Create { get; set; }
        public IList<Action<ShapeCreatedContext>> OnCreated { get; set; }
    public class ShapeCreatedContext {
        public dynamic Shape { get; set; }
    public abstract class ShapeFactoryEvents : IShapeFactoryEvents {
        public virtual void Creating(ShapeCreatingContext context) { }
        public virtual void Created(ShapeCreatedContext context) { }
}
