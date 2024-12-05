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
    public class CreateColumnCommand : ColumnCommand {
        public CreateColumnCommand(string tableName, string name) : base(tableName, name) {
            IsNotNull = false;
            IsUnique = false;
        }
        public bool IsUnique { get; protected set; }
        public bool IsNotNull { get; protected set; }
        public bool IsPrimaryKey { get; protected set; }
        public bool IsIdentity { get; protected set; }
        public CreateColumnCommand PrimaryKey() {
            IsPrimaryKey = true;
            return this;
        public CreateColumnCommand Identity() {
            IsIdentity = true;
        public CreateColumnCommand WithPrecision(byte precision) {
            Precision = precision;
        public CreateColumnCommand WithScale(byte scale) {
            Scale = scale;
        public CreateColumnCommand NotNull() {
            IsNotNull = true;
        public CreateColumnCommand Nullable() {
        public CreateColumnCommand Unique() {
            IsUnique = true;
            IsPrimaryKey = false;
            IsIdentity = false;
        public CreateColumnCommand NotUnique() {
        public new CreateColumnCommand WithLength(int? length) {
            base.WithLength(length);
        public new CreateColumnCommand Unlimited() {
            return WithLength(10000);
        public new CreateColumnCommand WithType(DbType dbType) {
            base.WithType(dbType);
        public new CreateColumnCommand WithDefault(object @default) {
            base.WithDefault(@default);
    }
}
