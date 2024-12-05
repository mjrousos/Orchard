using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
using System;

namespace Orchard.Tasks.Indexing {
    public interface IIndexingTaskManager : IDependency {
        /// <summary>
        /// Adds a new entry in the index task table in order to create an index for the specified content item.
        /// </summary>
        void CreateUpdateIndexTask(ContentItem contentItem);
        /// Adds a new entry in the index task table in order to delete an existing index for the specified content item.
        void CreateDeleteIndexTask(ContentItem contentItem);
    }
}
