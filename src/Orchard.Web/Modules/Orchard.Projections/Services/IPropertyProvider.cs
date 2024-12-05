using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;
using Orchard.Projections.Descriptors.Property;

namespace Orchard.Projections.Services {
    public interface IPropertyProvider : IEventHandler {
        void Describe(DescribePropertyContext describe);
    }
}
