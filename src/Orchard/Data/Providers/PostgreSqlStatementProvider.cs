using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Providers {
    public class PostgreSqlStatementProvider : ISqlStatementProvider {
        public string DataProvider {
            get { return "PostgreSql"; }
        }

        public string GetStatement(string command) {
            switch (command) {
                case "random":
                    return "random()";
                case "table_names":
                    return "select table_name from information_schema.tables where table_schema = 'public' and table_type = 'BASE TABLE'";
            }
            return null;
    }
}
