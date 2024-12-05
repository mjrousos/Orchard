using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Users.Constants {
    public static class UsernameValidationResults {
        public const string UsernameIsTooShort = "UsernameIsTooShort";
        public const string UsernameIsTooLong = "UsernameIsTooLong";
        public const string UsernameContainsWhitespaces = "UsernameContainsWhitespaces";
        public const string UsernameContainsSpecialChars = "UsernameContainsSpecialChars";
        public const string UsernameAndEmailMustMatch = "UsernameAndEmailMustMatch";
    }
}

