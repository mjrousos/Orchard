using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Web;
using Orchard.Localization.Records;

namespace Orchard.Localization.Services {
    public interface ICultureManager : IDependency {
        IEnumerable<string> ListCultures();
        void AddCulture(string cultureName);
        void DeleteCulture(string cultureName);
        string GetCurrentCulture(HttpContextBase requestContext);
        CultureRecord GetCultureById(int id);
        CultureRecord GetCultureByName(string cultureName);
        string GetSiteCulture();
        bool IsValidCulture(string cultureName);
    }
}
