using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Autoroute.Models;

namespace Orchard.Autoroute.Services {
    public class AliasResolverSelector : IIdentityResolverSelector {
        private readonly IContentManager _contentManager;
        public AliasResolverSelector(IContentManager contentManager) {
            _contentManager = contentManager;
        }
        public IdentityResolverSelectorResult GetResolver(ContentIdentity contentIdentity) {
            if (contentIdentity.Has("alias")) {
                return new IdentityResolverSelectorResult {
                    Priority = 0,
                    Resolve = ResolveIdentity
                };
            }
            return null;
        private IEnumerable<ContentItem> ResolveIdentity(ContentIdentity identity) {
            var identifier = identity.Get("alias");
            if (identifier == null) {
                return null;
            return _contentManager
                .Query<AutoroutePart, AutoroutePartRecord>(VersionOptions.Latest)
                .Where(p => p.DisplayAlias == identifier)
                .List<ContentItem>();
    }
}
