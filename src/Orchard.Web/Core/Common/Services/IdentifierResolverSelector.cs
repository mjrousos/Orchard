using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using System.Linq;
using Orchard.Core.Common.Models;

namespace Orchard.Core.Common.Services {
    public class IdentifierResolverSelector : IIdentityResolverSelector {
        private readonly IContentManager _contentManager;
        public IdentifierResolverSelector(IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public IdentityResolverSelectorResult GetResolver(ContentIdentity contentIdentity) {
            if (contentIdentity.Has("Identifier")) {
                return new IdentityResolverSelectorResult {
                    Priority = 5,
                    Resolve = ResolveIdentity
                };
            }
            return null;
        private IEnumerable<ContentItem> ResolveIdentity(ContentIdentity identity) {
            var identifier = identity.Get("Identifier");
            if (identifier == null) {
                return null;
            return _contentManager
                .Query<IdentityPart, IdentityPartRecord>(VersionOptions.Latest)
                .Where(p => p.Identifier == identifier)
                .List<ContentItem>()
                .Where(c => ContentIdentity.ContentIdentityEqualityComparer.AreEquivalent(
                    identity, _contentManager.GetItemMetadata(c).Identity));
    }
}
