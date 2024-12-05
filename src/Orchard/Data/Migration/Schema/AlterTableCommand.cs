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
    public class AlterTableCommand : SchemaCommand {
        public AlterTableCommand(string name)
            : base(name, SchemaCommandType.AlterTable) {
        }
        public void AddColumn(string columnName, DbType dbType, Action<AddColumnCommand> column = null) {
            var command = new AddColumnCommand(Name, columnName);
            command.WithType(dbType);
            
            if(column != null) {
                column(command);
            }
            TableCommands.Add(command);
        public void AddColumn<T>(string columnName, Action<AddColumnCommand> column = null) {
            var dbType = SchemaUtils.ToDbType(typeof(T));
            AddColumn(columnName, dbType, column);
        public void DropColumn(string columnName) {
            var command = new DropColumnCommand(Name, columnName);
        public void AlterColumn(string columnName, Action<AlterColumnCommand> column = null) {
            var command = new AlterColumnCommand(Name, columnName);
            if ( column != null ) {
        public void CreateIndex(string indexName, params string[] columnNames) {
            var command = new AddIndexCommand(Name, indexName, columnNames);
        public void DropIndex(string indexName) {
            var command = new DropIndexCommand(Name, indexName);
        public void AddUniqueConstraint(string constraintName, params string[] columnNames) {
            var command = new AddUniqueConstraintCommand(Name, constraintName, columnNames);
        public void DropUniqueConstraint(string constraintName) {
            var command = new DropUniqueConstraintCommand(Name, constraintName);
    }
}
