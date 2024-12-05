using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Users.Constants {
    public static class UserPasswordValidationResults {
        public const string PasswordIsTooShort = "PasswordIsTooShort";
        public const string PasswordDoesNotContainNumbers = "PasswordDoesNotContainNumbers";
        public const string PasswordDoesNotContainUppercase = "PasswordDoesNotContainUppercase";
        public const string PasswordDoesNotContainLowercase = "PasswordDoesNotContainLowercase";
        public const string PasswordDoesNotContainSpecialCharacters = "PasswordDoesNotContainSpecialCharacters";
        public const string PasswordDoesNotMeetHistoryPolicy = "PasswordDoesNotMeetHistoryPolicy";
    }
}
