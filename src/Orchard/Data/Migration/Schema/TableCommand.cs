using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Migration.Schema {
    public class TableCommand : ISchemaBuilderCommand{
        public string TableName { get; private set; }

        public TableCommand(string tableName) {
            TableName = tableName;
        }
    }
}
