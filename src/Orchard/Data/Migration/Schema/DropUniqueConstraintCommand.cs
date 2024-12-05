using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Migration.Schema {
    public class DropUniqueConstraintCommand : TableCommand {
        public string ConstraintName { get; set; }

        public DropUniqueConstraintCommand(string tableName, string constraintName)
            : base(tableName) {
            ConstraintName = constraintName;
        }
    }
}
