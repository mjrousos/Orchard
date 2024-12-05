using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Events;
using Orchard.Projections.Descriptors.SortCriterion;

namespace Orchard.Projections.Services {
    public interface ISortCriterionProvider : IEventHandler {
        void Describe(DescribeSortCriterionContext describe);
    }
}
