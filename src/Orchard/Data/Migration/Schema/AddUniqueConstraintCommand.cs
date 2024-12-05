using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Migration.Schema {
    public class AddUniqueConstraintCommand : TableCommand {
        public string ConstraintName { get; set; }

        public AddUniqueConstraintCommand(string tableName, string constraintName, params string[] columnNames)
            : base(tableName) {
            ColumnNames = columnNames;
            ConstraintName = constraintName;
        }
        public string[] ColumnNames { get; private set; }
    }
}
