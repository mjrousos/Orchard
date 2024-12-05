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
    public class ColumnCommand : TableCommand {
        public string ColumnName { get; set; }
        public ColumnCommand(string tableName, string name)
            : base(tableName) {
            ColumnName = name;
            DbType = DbType.Object;
            Default = null;
            Length = null;
        }
        public byte Scale { get; protected set; }
        public byte Precision { get; protected set; }
        public DbType DbType { get; private set; }
        public object Default { get; private set; }
        public int? Length { get; private set; }
        public ColumnCommand WithType(DbType dbType) {
            DbType = dbType;
            return this;
        public ColumnCommand WithDefault(object @default) {
            Default = @default;
        public ColumnCommand WithLength(int? length) {
            Length = length;
        public ColumnCommand Unlimited() {
            return WithLength(10000);
    }
}
