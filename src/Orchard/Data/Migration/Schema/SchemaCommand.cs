using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Collections.Generic;

namespace Orchard.Data.Migration.Schema {
    public abstract class SchemaCommand : ISchemaBuilderCommand {
        protected SchemaCommand(string name, SchemaCommandType type ) {
            TableCommands = new List<TableCommand>();
            Type = type;
            WithName(name);
        }
        public string Name { get; private set; }
        public List<TableCommand> TableCommands { get; private set; }
        public SchemaCommandType Type { get; private set; }
        public SchemaCommand WithName(string name) {
            Name = name;
            return this;
    }
    public enum SchemaCommandType {
        CreateTable,
        DropTable,
        AlterTable,
        SqlStatement,
        CreateForeignKey,
        DropForeignKey
}
