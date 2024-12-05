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
using Orchard;

namespace Upgrade.Services {
    public interface IUpgradeService : IDependency {
        void CopyTable(string fromTableName, string toTableName, string[] ignoreColumns);
        void ExecuteReader(string sqlStatement, Action<IDataReader, IDbConnection> action);
        string GetPrefixedTableName(string tableName);
        bool TableExists(string tableName);
    }
}
