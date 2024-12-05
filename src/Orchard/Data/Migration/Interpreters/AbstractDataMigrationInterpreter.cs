using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Data.Migration.Schema;

namespace Orchard.Data.Migration.Interpreters {
    public abstract class AbstractDataMigrationInterpreter {
        public void Visit(ISchemaBuilderCommand command) {
            var schemaCommand = command as SchemaCommand;
            if (schemaCommand == null) {
                return;
            }
            switch ( schemaCommand.Type ) {
                case SchemaCommandType.CreateTable:
                    Visit((CreateTableCommand)schemaCommand);
                    break;
                case SchemaCommandType.AlterTable:
                    Visit((AlterTableCommand)schemaCommand);
                case SchemaCommandType.DropTable:
                    Visit((DropTableCommand)schemaCommand);
                case SchemaCommandType.SqlStatement:
                    Visit((SqlStatementCommand)schemaCommand);
                case SchemaCommandType.CreateForeignKey:
                    Visit((CreateForeignKeyCommand)schemaCommand);
                case SchemaCommandType.DropForeignKey:
                    Visit((DropForeignKeyCommand)schemaCommand);
        }
        public abstract void Visit(CreateTableCommand command);
        public abstract void Visit(AlterTableCommand command);
        public abstract void Visit(DropTableCommand command);
        public abstract void Visit(SqlStatementCommand command);
        public abstract void Visit(CreateForeignKeyCommand command);
        public abstract void Visit(DropForeignKeyCommand command);
    }
}
