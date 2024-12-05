using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿namespace Orchard.Data.Providers {
    public class SqlServerStatementProvider : ISqlStatementProvider {
        public string DataProvider {
            get { return "SqlServer"; }
        }

        public string GetStatement(string command) {
            switch (command) {
                case "random":
                    return "newid()";
                case "table_names":
                    return "select name from sys.tables";
            }
            return null;
    }
}
