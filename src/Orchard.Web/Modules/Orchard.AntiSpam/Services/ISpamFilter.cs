using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.AntiSpam.Models;

namespace Orchard.AntiSpam.Services {
    /// <summary>
    /// Implementations of <see cref="ISpamFilter"/> are used to filter some user submitted
    /// content using anti-spam services
    /// </summary>
    public interface ISpamFilter : IDependency {
        /// <summary>
        /// Checks if some content is spam.
        /// </summary>
        /// <param name="context">The comment to check.</param>
        /// <returns><value>SpamStatus.Spam</value> if the comment has been categorized as spam, <value>SpamStatus.Ham</value> otherwise.</returns>
        SpamStatus CheckForSpam(CommentCheckContext context);
        /// Explicitely report some content as spam in order to improve the service.
        /// <param name="context">The comment to report as spam.</param>
        void ReportSpam(CommentCheckContext context);
        /// Explicitely report some content as ham in order to improve the service.
        /// <param name="context">The comment to report as ham (false positive).</param>
        void ReportHam(CommentCheckContext context);
    }
}
