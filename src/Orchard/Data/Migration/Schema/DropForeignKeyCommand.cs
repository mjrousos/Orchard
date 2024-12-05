using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Migration.Schema {
    public class DropForeignKeyCommand : SchemaCommand {
        public string SrcTable { get; private set; }

        public DropForeignKeyCommand(string srcTable, string name)
            : base(name, SchemaCommandType.DropForeignKey) {
            SrcTable = srcTable;
        }
    }
}
