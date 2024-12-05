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
    public static class SchemaUtils {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "System.Enum.TryParse<System.Data.DbType>(System.String,System.Boolean,System.Data.DbType@)")]
        public static DbType ToDbType(Type type) {
            DbType dbType;
            switch (Type.GetTypeCode(type)) {
                case TypeCode.String:
                    dbType = DbType.String;
                    break;
                case TypeCode.Int32:
                    dbType = DbType.Int32;
                case TypeCode.DateTime:
                    dbType = DbType.DateTime;
                case TypeCode.Boolean:
                    dbType = DbType.Boolean;
                default:
                    if (type == typeof(Guid))
                        dbType = DbType.Guid;
                    else if (type == typeof(byte[]))
                        dbType = DbType.Binary;
                    else
                        Enum.TryParse(Type.GetTypeCode(type).ToString(), true, out dbType);
            }
            return dbType;
        }
    }
}
