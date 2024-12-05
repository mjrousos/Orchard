using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;
using System.IO;
using System.Text;

namespace Orchard.Environment.Configuration {
    public class ShellSettingsSerializer {
        public const char Separator = ':';
        public const string EmptyValue = "null";
        public const char ThemesSeparator = ';';
        public static ShellSettings ParseSettings(string text) {
            var shellSettings = new ShellSettings();
            if (String.IsNullOrEmpty(text))
                return shellSettings;
            var settings = new StringReader(text);
            string setting;
            while ((setting = settings.ReadLine()) != null) {
                if (string.IsNullOrWhiteSpace(setting)) continue;
                var separatorIndex = setting.IndexOf(Separator);
                if (separatorIndex == -1) {
                    continue;
                }
                string key = setting.Substring(0, separatorIndex).Trim();
                string value = setting.Substring(separatorIndex + 1).Trim();
                if (!value.Equals(EmptyValue, StringComparison.OrdinalIgnoreCase)) {
                    switch (key) {
                        case "Name":
                            shellSettings.Name = value;
                            break;
                        case "DataProvider":
                            shellSettings.DataProvider = value;
                        case "State":
                            TenantState state;
                            shellSettings.State = Enum.TryParse(value, true, out state) ? state : TenantState.Uninitialized;
                        case "DataConnectionString":
                            shellSettings.DataConnectionString = value;
                        case "DataPrefix":
                            shellSettings.DataTablePrefix = value;
                        case "RequestUrlHost":
                            shellSettings.RequestUrlHost = value;
                        case "RequestUrlPrefix":
                            shellSettings.RequestUrlPrefix = value;
                        case "EncryptionAlgorithm":
                            shellSettings.EncryptionAlgorithm = value;
                        case "EncryptionKey":
                            shellSettings.EncryptionKey = value;
                        case "HashAlgorithm":
                            shellSettings.HashAlgorithm = value;
                        case "HashKey":
                            shellSettings.HashKey = value;
                        case "Themes":
                            shellSettings.Themes = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        case "Modules":
                            shellSettings.Modules = value.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        default:
                            shellSettings[key] = value;
                    }
            }
            return shellSettings;
        }
        public static string ComposeSettings(ShellSettings settings) {
            if (settings == null)
                return "";
            var sb = new StringBuilder();
            foreach (var key in settings.Keys) {
                sb.AppendLine(key + ": " + (settings[key] ?? EmptyValue));
            return sb.ToString();
    }
}
