using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Migration.Schema {
    public class DropIndexCommand : TableCommand {
        public string IndexName { get; set; }

        public DropIndexCommand(string tableName, string indexName)
            : base(tableName) {
            IndexName = indexName;
        }
    }
}
