using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Data;

namespace Orchard.Data.Migration.Schema {
    public class CreateTableCommand : SchemaCommand {
        public CreateTableCommand(string name)
            : base(name, SchemaCommandType.CreateTable) {
        }
        public CreateTableCommand Column(string columnName, DbType dbType, Action<CreateColumnCommand> column = null) {
            var command = new CreateColumnCommand(Name, columnName);
            command.WithType(dbType);
            if ( column != null ) {
                column(command);
            }
            TableCommands.Add(command);
            return this;
        public CreateTableCommand Column<T>(string columnName, Action<CreateColumnCommand> column = null) {
            var dbType = SchemaUtils.ToDbType(typeof (T));
            return Column(columnName, dbType, column);
        /// <summary>
        /// Defines a primary column as for content parts
        /// </summary>
        public CreateTableCommand ContentPartRecord() {
            Column<int>("Id", column => column.PrimaryKey().NotNull());
        /// Defines a primary column as for versionnable content parts
        public CreateTableCommand ContentPartVersionRecord() {
            Column<int>("ContentItemRecord_id");
    }
}
