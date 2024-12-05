using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.MediaProcessing.Descriptors.Filter;

namespace Orchard.MediaProcessing.Services {
    public interface IImageFilterProvider : IDependency {
        void Describe(DescribeFilterContext describe);
    }
}
