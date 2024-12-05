using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.Glimpse.Services;
using Orchard.Glimpse.Tabs.Authorizer;
using Orchard.Security.Permissions;

namespace Orchard.Glimpse.AlternateImplementation {
    [OrchardFeature(FeatureNames.Authorizer)]
    public class GlimpseAuthorizerDecorator : IDecorator<IAuthorizer>, IAuthorizer {
        private readonly IAuthorizer _decoratedService;
        private readonly IGlimpseService _glimpseService;
        public GlimpseAuthorizerDecorator(IAuthorizer decoratedService, IGlimpseService glimpseService) {
            _decoratedService = decoratedService;
            _glimpseService = glimpseService;
        }
        public bool Authorize(Permission permission) {
            return _glimpseService.PublishTimedAction(() => _decoratedService.Authorize(permission),
                (r, t) => new AuthorizerMessage {
                    Permission = permission,
                    Result = r,
                    Duration = t.Duration
                }, TimelineCategories.Authorizer, "Authorize", permission.Name).ActionResult;
        public bool Authorize(Permission permission, LocalizedString message) {
            return _glimpseService.PublishTimedAction(() => _decoratedService.Authorize(permission, message),
                    Message = message.Text,
        public bool Authorize(Permission permission, IContent content) {
            return _glimpseService.PublishTimedAction(() => _decoratedService.Authorize(permission, content),
                    Content = content,
        public bool Authorize(Permission permission, IContent content, LocalizedString message) {
            return _glimpseService.PublishTimedAction(() => _decoratedService.Authorize(permission, content, message),
    }
}
