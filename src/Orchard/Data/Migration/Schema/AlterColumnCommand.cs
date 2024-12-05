using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System.Data;

namespace Orchard.Data.Migration.Schema {
    public class AlterColumnCommand : ColumnCommand {
        public AlterColumnCommand(string tableName, string columnName)
            : base(tableName, columnName) {
        }
        public new AlterColumnCommand WithType(DbType dbType) {
            base.WithType(dbType);
            return this;
        public AlterColumnCommand WithType(DbType dbType, int? length) {
            base.WithType(dbType).WithLength(length);
        public AlterColumnCommand WithType(DbType dbType, byte precision, byte scale) {
            Precision = precision;
            Scale = scale;
        public new AlterColumnCommand WithLength(int? length) {
            base.WithLength(length);
        
        public new AlterColumnCommand Unlimited() {
            return WithLength(10000);
    }
}
