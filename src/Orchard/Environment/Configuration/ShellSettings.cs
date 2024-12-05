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
using System.Linq;

namespace Orchard.Environment.Configuration {
    /// <summary>
    /// Represents the minimalistic set of fields stored for each tenant. This 
    /// model is obtained from the IShellSettingsManager, which by default reads this
    /// from the App_Data settings.txt files.
    /// </summary>
    public class ShellSettings {
        public const string DefaultName = "Default";
        private TenantState _tenantState;
        private string[] _themes;
        private string[] _modules;
        private readonly IDictionary<string, string> _values;
        public ShellSettings() {
            _values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            State = TenantState.Invalid;
            Themes = new string[0];
            Modules = new string[0];
        }
        public ShellSettings(ShellSettings settings) {
            _values = new Dictionary<string, string>(settings._values, StringComparer.OrdinalIgnoreCase);
            Name = settings.Name;
            DataProvider = settings.DataProvider;
            DataConnectionString = settings.DataConnectionString;
            DataTablePrefix = settings.DataTablePrefix;
            RequestUrlHost = settings.RequestUrlHost;
            RequestUrlPrefix = settings.RequestUrlPrefix;
            EncryptionAlgorithm = settings.EncryptionAlgorithm;
            EncryptionKey = settings.EncryptionKey;
            HashAlgorithm = settings.HashAlgorithm;
            HashKey = settings.HashKey;
            State = settings.State;
            Themes = settings.Themes;
            Modules = settings.Modules;
        public string this[string key] {
            get {
                string retVal;
                return _values.TryGetValue(key, out retVal) ? retVal : null;
            }
            set { _values[key] = value; }
        /// <summary>
        /// Gets all keys held by this shell settings.
        /// </summary>
        public IEnumerable<string> Keys { get { return _values.Keys; } }
        /// The name of the tenant
        public string Name {
            get { return this["Name"] ?? ""; } 
            set { this["Name"] = value; }
        /// The database provider for the tenant
        public string DataProvider {
            get { return this["DataProvider"] ?? ""; }
            set { this["DataProvider"] = value; }
        /// The database connection string
        public string DataConnectionString {
            get { return this["DataConnectionString"]; }
            set { this["DataConnectionString"] = value; }
        /// The data table prefix added to table names for this tenant
        public string DataTablePrefix {
            get { return this["DataTablePrefix"]; }
            set { this["DataTablePrefix"] = value; }
        /// The host name of the tenant
        public string RequestUrlHost {
            get { return this["RequestUrlHost"]; }
            set { this["RequestUrlHost"] = value; }
        /// The request url prefix of the tenant
        public string RequestUrlPrefix {
            get { return this["RequestUrlPrefix"]; } 
            set { _values["RequestUrlPrefix"] = value; }
        /// The encryption algorithm used for encryption services
        public string EncryptionAlgorithm {
            get { return this["EncryptionAlgorithm"]; }
            set { this["EncryptionAlgorithm"] = value; }
        /// The encryption key used for encryption services
        public string EncryptionKey {
            get { return this["EncryptionKey"]; } 
            set { _values["EncryptionKey"] = value; }
        /// The hash algorithm used for encryption services
        public string HashAlgorithm {
            get { return this["HashAlgorithm"]; }
            set { this["HashAlgorithm"] = value; }
        /// The hash key used for encryption services
        public string HashKey {
            get { return this["HashKey"]; }
            set { this["HashKey"] = value; }
        /// List of available themes for this tenant
        public string[] Themes {
            get { 
                return _themes ?? (Themes = (_values["Themes"] ?? "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                                                                     .Select(t => t.Trim())
                                                                     .ToArray(); 
            set {
                _themes = value;
                this["Themes"] = string.Join(";", value);
        /// List of available modules for this tenant
        public string[] Modules {
                return _modules ?? (Modules = (_values["Modules"] ?? "").Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                                                                     .ToArray();
                _modules = value;
                this["Modules"] = string.Join(";", value);
        /// The state is which the tenant is
        public TenantState State {
            get { return _tenantState; } 
                _tenantState = value;
                this["State"] = value.ToString();
    }
}
