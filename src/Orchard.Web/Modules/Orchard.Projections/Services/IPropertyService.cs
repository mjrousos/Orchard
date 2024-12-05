using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Projections.Services {
    public interface IPropertyService : IDependency {
        void MoveUp(int propertyId);
        void MoveDown(int propertyId);
    }
}
