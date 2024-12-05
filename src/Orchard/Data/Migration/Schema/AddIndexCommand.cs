using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Migration.Schema {
    public class AddIndexCommand : TableCommand {
        public string IndexName { get; set; }

        public AddIndexCommand(string tableName, string indexName, params string[] columnNames)
            : base(tableName) {
            ColumnNames = columnNames;
            IndexName = indexName;
        }
        public string[] ColumnNames { get; private set; }
    }
}
