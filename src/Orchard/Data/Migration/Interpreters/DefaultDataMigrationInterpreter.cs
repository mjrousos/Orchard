using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.SqlTypes;
using Orchard.Data.Migration.Schema;
using Orchard.Environment.Configuration;
using Orchard.Logging;

namespace Orchard.Data.Migration.Interpreters {
    public class DefaultDataMigrationInterpreter : AbstractDataMigrationInterpreter, IDataMigrationInterpreter {
        private readonly ShellSettings _shellSettings;
        private readonly ITransactionManager _transactionManager;
        private readonly IEnumerable<ICommandInterpreter> _commandInterpreters;
        private readonly Lazy<Dialect> _dialectLazy;
        private readonly List<string> _sqlStatements;
        private const char Space = ' ';
        public DefaultDataMigrationInterpreter(
            ShellSettings shellSettings,
            ITransactionManager transactionManager,
            IEnumerable<ICommandInterpreter> commandInterpreters,
            ISessionFactoryHolder sessionFactoryHolder) {
            _shellSettings = shellSettings;
            _transactionManager = transactionManager;
            _commandInterpreters = commandInterpreters;
            _sqlStatements = new List<string>();
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
            _dialectLazy = new Lazy<Dialect>(() => Dialect.GetDialect(sessionFactoryHolder.GetConfiguration().Properties));
        }
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }
        public IEnumerable<string> SqlStatements {
            get { return _sqlStatements; }
        public override void Visit(CreateTableCommand command) {
            if (ExecuteCustomInterpreter(command)) {
                return;
            }
            var builder = new StringBuilder();
            builder.Append(_dialectLazy.Value.CreateMultisetTableString)
                .Append(' ')
                .Append(_dialectLazy.Value.QuoteForTableName(PrefixTableName(command.Name)))
                .Append(" (");
            var appendComma = false;
            foreach (var createColumn in command.TableCommands.OfType<CreateColumnCommand>()) {
                if (appendComma) {
                    builder.Append(", ");
                }
                appendComma = true;
                Visit(builder, createColumn);
            var primaryKeys = command.TableCommands.OfType<CreateColumnCommand>().Where(ccc => ccc.IsPrimaryKey).Select(ccc => ccc.ColumnName).ToArray();
            if (primaryKeys.Any()) {
                var primaryKeysQuoted = new List<string>(primaryKeys.Length);
                foreach (string pk in primaryKeys) {
                    primaryKeysQuoted.Add(_dialectLazy.Value.QuoteForColumnName(pk));
                builder.Append(_dialectLazy.Value.PrimaryKeyString)
                    .Append(" ( ")
                    .Append(String.Join(", ", primaryKeysQuoted.ToArray()))
                    .Append(" )");
            builder.Append(" )");
            _sqlStatements.Add(builder.ToString());
            RunPendingStatements();
        public string PrefixTableName(string tableName) {
            if (string.IsNullOrEmpty(_shellSettings.DataTablePrefix))
                return tableName;
            return _shellSettings.DataTablePrefix + "_" + tableName;
        public string RemovePrefixFromTableName(string prefixedTableName) {
                return prefixedTableName;
            return prefixedTableName.Substring(_shellSettings.DataTablePrefix.Length + 1);
        public override void Visit(DropTableCommand command) {
            builder.Append(_dialectLazy.Value.GetDropTableString(PrefixTableName(command.Name)));
        public override void Visit(AlterTableCommand command) {
            if (command.TableCommands.Count == 0) {
            // Drop columns.
            foreach (var dropColumn in command.TableCommands.OfType<DropColumnCommand>()) {
                var builder = new StringBuilder();
                Visit(builder, dropColumn);
                RunPendingStatements();
            // Add columns.
            foreach (var addColumn in command.TableCommands.OfType<AddColumnCommand>()) {
                Visit(builder, addColumn);
            // Alter columns.
            foreach (var alterColumn in command.TableCommands.OfType<AlterColumnCommand>()) {
                Visit(builder, alterColumn);
            // Add index.
            foreach (var addIndex in command.TableCommands.OfType<AddIndexCommand>()) {
                Visit(builder, addIndex);
            // Drop index.
            foreach (var dropIndex in command.TableCommands.OfType<DropIndexCommand>()) {
                Visit(builder, dropIndex);
            // Add unique constraint.
            foreach (var addUniqueConstraint in command.TableCommands.OfType<AddUniqueConstraintCommand>()) {
                Visit(builder, addUniqueConstraint);
            // Drop unique constraint.
            foreach (var dropUniqueConstraint in command.TableCommands.OfType<DropUniqueConstraintCommand>()) {
                Visit(builder, dropUniqueConstraint);
        public void Visit(StringBuilder builder, AddColumnCommand command) {
            builder.AppendFormat("alter table {0} add ", _dialectLazy.Value.QuoteForTableName(PrefixTableName(command.TableName)));
            Visit(builder, (CreateColumnCommand)command);
        public void Visit(StringBuilder builder, DropColumnCommand command) {
            builder.AppendFormat("alter table {0} drop column {1}",
                _dialectLazy.Value.QuoteForTableName(PrefixTableName(command.TableName)),
                _dialectLazy.Value.QuoteForColumnName(command.ColumnName));
        public void Visit(StringBuilder builder, AlterColumnCommand command) {
            builder.AppendFormat("alter table {0} alter column {1} ",
            // type
            if (command.DbType != DbType.Object) {
                builder.Append(GetTypeName(_dialectLazy.Value, command.DbType, command.Length, command.Precision, command.Scale));
            else {
                if(command.Length > 0 || command.Precision > 0 || command.Scale > 0) {
                    throw new OrchardException(T("Error while executing data migration: you need to specify the field's type in order to change its properties"));
            // [default value]
            if (command.Default != null) {
                builder.Append(" set default ").Append(ConvertToSqlValue(command.Default)).Append(Space);
        public void Visit(StringBuilder builder, AddIndexCommand command) {
            builder.AppendFormat("create index {1} on {0} ({2}) ",
                _dialectLazy.Value.QuoteForColumnName(PrefixTableName(command.IndexName)),
                String.Join(", ", command.ColumnNames));
        public void Visit(StringBuilder builder, DropIndexCommand command) {
            builder.AppendFormat("drop index {0} ON {1}",
                _dialectLazy.Value.QuoteForTableName(PrefixTableName(command.TableName)));
        public void Visit(StringBuilder builder, AddUniqueConstraintCommand command) {
            builder.AppendFormat("alter table {0} add constraint {1} unique ({2})",
                _dialectLazy.Value.QuoteForColumnName(PrefixTableName(command.ConstraintName)),
        public void Visit(StringBuilder builder, DropUniqueConstraintCommand command) {
            builder.AppendFormat("alter table {0} drop constraint {1}",
                _dialectLazy.Value.QuoteForColumnName(PrefixTableName(command.ConstraintName)));
        public override void Visit(SqlStatementCommand command) {
            if (command.Providers.Count != 0 && !command.Providers.Contains(_shellSettings.DataProvider)) {
            _sqlStatements.Add(command.Sql);
        public override void Visit(CreateForeignKeyCommand command) {
            builder.Append("alter table ")
                .Append(_dialectLazy.Value.QuoteForTableName(PrefixTableName(command.SrcTable)));
            builder.Append(_dialectLazy.Value.GetAddForeignKeyConstraintString(PrefixTableName(command.Name),
                command.SrcColumns,
                _dialectLazy.Value.QuoteForTableName(PrefixTableName(command.DestTable)),
                command.DestColumns,
                false));
        public override void Visit(DropForeignKeyCommand command) {
                .Append(_dialectLazy.Value.QuoteForTableName(PrefixTableName(command.SrcTable)))
                .Append(_dialectLazy.Value.GetDropForeignKeyConstraintString(PrefixTableName(command.Name)));
        public static string GetTypeName(Dialect dialect, DbType dbType, int? length, byte precision, byte scale) {
            return precision > 0
                       ? dialect.GetTypeName(new SqlType(dbType, precision, scale))
                       : length.HasValue
                             ? dialect.GetTypeName(new SqlType(dbType, length.Value))
                             : dialect.GetTypeName(new SqlType(dbType));
        private void Visit(StringBuilder builder, CreateColumnCommand command) {
            // name
            builder.Append(_dialectLazy.Value.QuoteForColumnName(command.ColumnName)).Append(Space);
            if (!command.IsIdentity || _dialectLazy.Value.HasDataTypeInIdentityColumn) {
            // append identity if handled
            if (command.IsIdentity && _dialectLazy.Value.SupportsIdentityColumns) {
                builder.Append(Space).Append(_dialectLazy.Value.IdentityColumnString);
                builder.Append(" default ").Append(ConvertToSqlValue(command.Default)).Append(Space);
            // nullable
            builder.Append(command.IsNotNull
                               ? " not null"
                               : !command.IsPrimaryKey && !command.IsUnique
                                     ? _dialectLazy.Value.NullColumnString
                                     : string.Empty);
            // append unique if handled, otherwise at the end of the satement
            if (command.IsUnique && _dialectLazy.Value.SupportsUnique) {
                builder.Append(" unique");
        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Nothing comes from user input.")]
        private void RunPendingStatements() {
            var session = _transactionManager.GetSession();
            try {
                foreach (var sqlStatement in _sqlStatements) {
                    Logger.Debug("Executing SQL query: {0}", sqlStatement);
                    using (var command = session.Connection.CreateCommand()) {
                        command.CommandText = sqlStatement;
                        var transaction = session.GetCurrentTransaction();
                        if (transaction != null) {
                            transaction.Enlist(command);
                            command.ExecuteNonQuery();
                        }
                    }
            finally {
                _sqlStatements.Clear();
        private bool ExecuteCustomInterpreter<T>(T command) where T : ISchemaBuilderCommand {
            var interpreter = _commandInterpreters
                .Where(ici => ici.DataProvider == _shellSettings.DataProvider)
                .OfType<ICommandInterpreter<T>>()
                .FirstOrDefault();
            if (interpreter != null) {
                _sqlStatements.AddRange(interpreter.CreateStatements(command));
                return true;
            return false;
        public string ConvertToSqlValue(object value) {
            if ( value == null ) {
                return "null";
            TypeCode typeCode = Type.GetTypeCode(value.GetType());
            switch (typeCode) {
                case TypeCode.Empty:
                case TypeCode.Object:
                case TypeCode.DBNull:
                case TypeCode.String:
                case TypeCode.Char:
                    return String.Concat("'", Convert.ToString(value).Replace("'", "''"), "'");
                case TypeCode.Boolean:
                    return this._dialectLazy.Value.ToBooleanValueString((bool)value);
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return Convert.ToString(value, CultureInfo.InvariantCulture);
                case TypeCode.DateTime:
                    return String.Concat("'", ((DateTime)value).ToString("yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture), "'");
            return "null";
    }
}
