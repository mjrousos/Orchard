using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.AntiSpam.Models;
using Orchard.AntiSpam.Settings;

namespace Orchard.AntiSpam.Services {
    public interface ISpamService : IDependency {
        SpamStatus CheckForSpam(CommentCheckContext text, SpamFilterAction action, IContent content);
        SpamStatus CheckForSpam(SpamFilterPart part);
        /// <summary>
        /// Explicitely report some content as spam in order to improve the service.
        /// </summary>
        /// <param name="context">The comment context to report as spam.</param>
        void ReportSpam(CommentCheckContext context);
        /// Explicitely report some content as ham in order to improve the service.
        /// <param name="part">The content part to report as ham (false positive).</param>
        void ReportSpam(SpamFilterPart part);
        /// <param name="context">The comment context to report as ham (false positive).</param>
        void ReportHam(CommentCheckContext context);
        void ReportHam(SpamFilterPart part);
        IEnumerable<ISpamFilter> GetSpamFilters();
    }
}
