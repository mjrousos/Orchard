using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Environment.Extensions.Models;

namespace Orchard.Data.Migration {
    public interface IDataMigration : IDependency {
        Feature Feature { get; }
    }
}
