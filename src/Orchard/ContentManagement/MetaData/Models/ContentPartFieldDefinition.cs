using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using Orchard.Utility.Extensions;

namespace Orchard.ContentManagement.MetaData.Models {
    public class ContentPartFieldDefinition {
        public const string DisplayNameKey = "DisplayName";
        public ContentPartFieldDefinition(string name) {
            Name = name;
            FieldDefinition = new ContentFieldDefinition(null);
            Settings = new SettingsDictionary();
        }
        public ContentPartFieldDefinition( ContentFieldDefinition contentFieldDefinition, string name, SettingsDictionary settings) {
            FieldDefinition = contentFieldDefinition;
            Settings = settings;
        public string Name { get; private set; }
        
        public string DisplayName {
            get {
                // if none is defined, generate one from the technical name
                return Settings.ContainsKey(DisplayNameKey) ? Settings[DisplayNameKey] : Name.CamelFriendly();
            }
            set { Settings[DisplayNameKey] = value; }
        public ContentFieldDefinition FieldDefinition { get; private set; }
        public SettingsDictionary Settings { get; private set; }
    }
}
