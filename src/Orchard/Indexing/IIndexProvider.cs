using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Indexing {
    public interface IIndexProvider : ISingletonDependency {
        /// <summary>
        /// Creates a new index
        /// </summary>
        void CreateIndex(string name);
        /// Checks whether an index is already existing or not
        bool Exists(string name);
        /// Lists all existing indexes
        IEnumerable<string> List();
        /// Deletes an existing index
        void DeleteIndex(string name);
        /// Whether an index is empty or not
        bool IsEmpty(string indexName);
        /// Gets the number of indexed documents
        int NumDocs(string indexName);
        /// Creates an empty document
        /// <returns></returns>
        IDocumentIndex New(int documentId);
        /// Adds a new document to the index
        void Store(string indexName, IDocumentIndex indexDocument);
        /// Adds a set of new document to the index
        void Store(string indexName, IEnumerable<IDocumentIndex> indexDocuments);
        /// Removes an existing document from the index
        void Delete(string indexName, int documentId);
        /// Removes a set of existing document from the index
        void Delete(string indexName, IEnumerable<int> documentIds);
        /// Creates a search builder for this provider
        /// <returns>A search builder instance</returns>
        ISearchBuilder CreateSearchBuilder(string indexName);
        /// Returns every field available in the specified index
        IEnumerable<string> GetFields(string indexName);
    }
}
