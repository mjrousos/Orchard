using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Migration.Schema {
    public class CreateForeignKeyCommand : SchemaCommand {

        public string[] DestColumns { get; private set; }
        public string DestTable { get; private set; }
        public string[] SrcColumns { get; private set; }
        public string SrcTable { get; private set; }
        public CreateForeignKeyCommand(string name, string srcTable, string[] srcColumns, string destTable, string[] destColumns) : base(name, SchemaCommandType.CreateForeignKey) {
            SrcColumns = srcColumns;
            DestTable = destTable;
            DestColumns = destColumns;
            SrcTable = srcTable;
        }
    }
}
