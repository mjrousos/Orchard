using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using Orchard.Packaging.GalleryServer;
using Orchard.Packaging.Models;

namespace Orchard.Packaging.Services {
    /// <summary>
    /// Responsible for managing package sources and getting the list of packages from it.
    /// </summary>
    public interface IPackagingSourceManager : IDependency {
        /// <summary>
        /// Gets the different feed sources.
        /// </summary>
        /// <returns>The feeds.</returns>
        IEnumerable<PackagingSource> GetSources();
        /// Adds a new feed sources.
        /// <param name="feedTitle">The feed title.</param>
        /// <param name="feedUrl">The feed url.</param>
        /// <returns>The feed identifier.</returns>
        int AddSource(string feedTitle, string feedUrl);
        /// Removes a feed source.
        /// <param name="id">The feed identifier.</param>
        void RemoveSource(int id);
        /// Retrieves the list of extensions from a feed source.
        /// <param name="includeScreenshots">Specifies if screenshots should be included in the result.</param>
        /// <param name="packagingSource">The packaging source from where to get the extensions.</param>
        /// <param name="query">The optional query to retrieve the extensions.</param>
        /// <returns>The list of extensions.</returns>
        IEnumerable<PackagingEntry> GetExtensionList(bool includeScreenshots, PackagingSource packagingSource = null, Func<IQueryable<PublishedPackage>, IQueryable<PublishedPackage>> query = null);
        /// Retrieves the number of extensions from a feed source.
        /// <returns>The number of extensions from a feed source.</returns>
        int GetExtensionCount(PackagingSource packagingSource = null, Func<IQueryable<PublishedPackage>, IQueryable<PublishedPackage>> query = null);
    }
}
