using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Users.Models {
    public static class MessageTypes {
        public const string Moderation = "ORCHARD_USERS_MODERATION";
        public const string Validation = "ORCHARD_USERS_VALIDATION";
        public const string LostPassword = "ORCHARD_USERS_RESETPASSWORD";

    }
}
