using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;
using Orchard.Alias.Implementation.Map;

namespace Orchard.Alias.Implementation.Holder {
    /// <summary>
    /// Holds every alias in a tree structure, indexed by area
    /// </summary>
    public interface IAliasHolder : ISingletonDependency {
        /// <summary>
        /// Returns an <see cref="AliasMap"/> for a specific area
        /// </summary>
        AliasMap GetMap(string areaName);
        /// Returns all <see cref="AliasMap"/> instances
        IEnumerable<AliasMap> GetMaps();
        /// Adds or updates an alias in the tree
        void SetAlias(AliasInfo alias);
        /// Adds or updates a set of aliases in the tree
        void SetAliases(IEnumerable<AliasInfo> aliases);
        /// Removes an alias from the tree based on its path
        void RemoveAlias(AliasInfo aliasInfo);
    }
}
