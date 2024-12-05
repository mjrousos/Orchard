using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.ContentPicker.Models;

namespace Orchard.ContentPicker.Security {
    public class ContentMenuItemAuthorizationEventHandler : IAuthorizationServiceEventHandler{
        private readonly IAuthorizationService _authorizationService;
        public ContentMenuItemAuthorizationEventHandler(IAuthorizationService authorizationService) {
            _authorizationService = authorizationService;
        }
        public void Checking(CheckAccessContext context) { }
        public void Adjust(CheckAccessContext context) { }
        public void Complete(CheckAccessContext context) {
            if (context.Content == null) {
                return;
            }
            var part = context.Content.As<ContentMenuItemPart>();
            // if the content item has no right attached, check on the container
            if (part == null) {
            context.Granted = _authorizationService.TryCheckAccess(context.Permission, context.User, part.Content);
            context.Adjusted = true;
    }
}
