using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using Orchard.ContentManagement.FieldStorage;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using Orchard.Core.Common.Utilities;
using Orchard.Data.Conventions;

namespace Orchard.Azure.MediaServices.Models.Assets {
    public enum AssetPublishStatus {
        None,
        Published,
        Removed
    }
}
