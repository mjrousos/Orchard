using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Specialized;
using System.Web;
using Orchard.DynamicForms.Models;

namespace Orchard.DynamicForms.Helpers {
    public static class SubmissionExtensions {
        public static NameValueCollection ToNameValues(this Submission submission) {
            return HttpUtility.ParseQueryString(submission.FormData);
        }
    }
}
