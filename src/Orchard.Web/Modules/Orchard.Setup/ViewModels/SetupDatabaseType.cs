using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Setup.ViewModels
{
    public enum SetupDatabaseType
    {
        Builtin,
        SqlServer,
        MySql,
        PostgreSql,
    }
}
