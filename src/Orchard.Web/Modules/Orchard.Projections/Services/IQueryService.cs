using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Linq;
using Orchard.Projections.Models;

namespace Orchard.Projections.Services {
    public interface IQueryService : IDependency {
        QueryPart GetQuery(int id);
        QueryPart CreateQuery(string name);
        void DeleteQuery(int id);
    }
}
