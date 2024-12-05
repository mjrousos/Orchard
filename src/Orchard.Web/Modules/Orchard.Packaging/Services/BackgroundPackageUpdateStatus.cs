using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions;
using Orchard.Packaging.Models;

namespace Orchard.Packaging.Services {
    public interface IBackgroundPackageUpdateStatus : ISingletonDependency {
        PackagesStatusResult Value { get; set; }
    }
    [OrchardFeature("Gallery.Updates")]
    public class BackgroundPackageUpdateStatus : IBackgroundPackageUpdateStatus {
        public PackagesStatusResult Value { get; set; }
}
