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
    public class SQLiteCommandInterpreter :
        ICommandInterpreter<DropColumnCommand>,
        ICommandInterpreter<AlterColumnCommand>,
        ICommandInterpreter<CreateForeignKeyCommand>,
        ICommandInterpreter<DropForeignKeyCommand>,
        ICommandInterpreter<AddIndexCommand>,
        ICommandInterpreter<DropIndexCommand> {
        public string[] CreateStatements(DropColumnCommand command) {
            return new string[0];
        }
        public string[] CreateStatements(AlterColumnCommand command) {
        public string[] CreateStatements(CreateForeignKeyCommand command) {
        public string[] CreateStatements(DropForeignKeyCommand command) {
        public string[] CreateStatements(AddIndexCommand command) {
        public string[] CreateStatements(DropIndexCommand command) {
        public string DataProvider {
            get { return "SQLite"; }
    }
}
