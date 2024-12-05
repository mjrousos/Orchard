using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace Orchard.ContentManagement {
    public interface IGlobalCriteriaProvider : IDependency {
        void AddCriteria(ICriteria criteria);
    }
}
